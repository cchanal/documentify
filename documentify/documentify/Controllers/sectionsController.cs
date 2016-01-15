using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using documentify.Models;

namespace documentify.Controllers
{
    public class sectionsController : Controller
    {
        private documentifyDataEntities db = new documentifyDataEntities();

        // GET: sections
        public ActionResult Index()
        {
            var sections = db.sections.Include(s => s.page);
            return View(sections.ToList());
        }

        // GET: sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section section = db.sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: sections/Create
        public ActionResult Create()
        {
            ViewBag.id_page = new SelectList(db.pages, "id_page", "titre");
            return View();
        }

        // POST: sections/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_section,titre,contenu,ordre,id_page")] section section)
        {
            if (ModelState.IsValid)
            {
                db.sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_page = new SelectList(db.pages, "id_page", "titre", section.id_page);
            return View(section);
        }

        // GET: sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section section = db.sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_page = new SelectList(db.pages, "id_page", "titre", section.id_page);
            return View(section);
        }

        // POST: sections/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_section,titre,contenu,ordre,id_page")] section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_page = new SelectList(db.pages, "id_page", "titre", section.id_page);
            return View(section);
        }

        // GET: sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section section = db.sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            section section = db.sections.Find(id);

            section.sous_section.ToList().ForEach(x => db.sous_section.Remove(x));
            db.sections.Remove(section);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
