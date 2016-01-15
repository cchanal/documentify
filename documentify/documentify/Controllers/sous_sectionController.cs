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
    public class sous_sectionController : Controller
    {
        private documentifyDataEntities db = new documentifyDataEntities();

        // GET: sous_section
        public ActionResult Index()
        {
            var sous_section = db.sous_section.Include(s => s.section);
            return View(sous_section.ToList());
        }

        // GET: sous_section/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sous_section sous_section = db.sous_section.Find(id);
            if (sous_section == null)
            {
                return HttpNotFound();
            }
            return View(sous_section);
        }

        // GET: sous_section/Create
        public ActionResult Create()
        {
            ViewBag.id_section = new SelectList(db.sections, "id_section", "titre");
            return View();
        }

        // POST: sous_section/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sous_section,id_section,titre,contenu,ordre")] sous_section sous_section)
        {
            if (ModelState.IsValid)
            {
                db.sous_section.Add(sous_section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_section = new SelectList(db.sections, "id_section", "titre", sous_section.id_section);
            return View(sous_section);
        }

        // GET: sous_section/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sous_section sous_section = db.sous_section.Find(id);
            if (sous_section == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_section = new SelectList(db.sections, "id_section", "titre", sous_section.id_section);
            return View(sous_section);
        }

        // POST: sous_section/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sous_section,id_section,titre,contenu,ordre")] sous_section sous_section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sous_section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_section = new SelectList(db.sections, "id_section", "titre", sous_section.id_section);
            return View(sous_section);
        }

        // GET: sous_section/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sous_section sous_section = db.sous_section.Find(id);
            if (sous_section == null)
            {
                return HttpNotFound();
            }
            return View(sous_section);
        }

        // POST: sous_section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sous_section sous_section = db.sous_section.Find(id);
            db.sous_section.Remove(sous_section);
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
