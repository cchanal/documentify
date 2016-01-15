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
    public class pagesController : Controller
    {
        private documentifyDataEntities db = new documentifyDataEntities();

        // GET: pages
        public ActionResult Index()
        {
            var pages = db.pages.Include(p => p.projet);
            return View(pages.ToList());
        }

        // GET: pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = db.pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: pages/Create
        public ActionResult Create()
        {
            ViewBag.id_projet = new SelectList(db.projets, "id_projet", "nom");
            return View();
        }

        // POST: pages/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_page,titre,description,numero,id_projet")] page page)
        {
            if (ModelState.IsValid)
            {
                db.pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_projet = new SelectList(db.projets, "id_projet", "nom", page.id_projet);
            return View(page);
        }

        // GET: pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = db.pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_projet = new SelectList(db.projets, "id_projet", "nom", page.id_projet);
            return View(page);
        }

        // POST: pages/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_page,titre,description,numero,id_projet")] page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_projet = new SelectList(db.projets, "id_projet", "nom", page.id_projet);
            return View(page);
        }

        // GET: pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = db.pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            page page = db.pages.Find(id);

            page.sections.ToList().ForEach(x => x.sous_section.ToList().ForEach(y => db.sous_section.Remove(y)));
            page.sections.ToList().ForEach(x => db.sections.Remove(x));
            db.pages.Remove(page);

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
