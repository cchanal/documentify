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
    public class projetsController : Controller
    {
        private documentifyDataEntities db = new documentifyDataEntities();

        // GET: projets
        public ActionResult Index()
        {
            return View(db.projets.ToList());
        }

        // GET: projets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet projet = db.projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: projets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: projets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_projet,nom,description")] projet projet)
        {
            if (ModelState.IsValid)
            {
                db.projets.Add(projet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projet);
        }

        // GET: projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet projet = db.projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: projets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_projet,nom,description")] projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projet);
        }

        // GET: projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet projet = db.projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projet projet = db.projets.Find(id);

            projet.pages.ToList().ForEach(x => x.sections.ToList().ForEach(y => y.sous_section.ToList().ForEach(z => db.sous_section.Remove(z))));
            projet.pages.ToList().ForEach(x => x.sections.ToList().ForEach(y => db.sections.Remove(y)));
            projet.pages.ToList().ForEach(x => db.pages.Remove(x));
            db.projets.Remove(projet);

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
