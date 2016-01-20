using documentify.Models;
using documentify.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace documentify.Controllers
{
    public class HomeController : Controller
    {
        private documentifyDataEntities db = new documentifyDataEntities();
        public ActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            IEnumerable<ProjetViewModel> projets = db.projets.Select(p => new ProjetViewModel { 
                projet = p,
                projet_homepage_url = "/pages/Details/" + p.pages.Where(pa => pa.numero == 0).FirstOrDefault().id_page.ToString(),
                deletion_url = "/home/DeleteProject/" + p.id_projet
            }).ToList();
            model.projets = projets;

            return View(model);
        }

        // POST: projets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject([Bind(Include = "id_projet,nom,description")] projet projet)
        {
            HomePageViewModel model = new HomePageViewModel();
            IEnumerable<ProjetViewModel> projets = new List<ProjetViewModel>();

            if (ModelState.IsValid)
            {
                page homePage = new page
                {
                    titre = "HomePage",
                    numero = 0
                };

                projet.pages.Add(homePage);
                db.projets.Add(projet);

                db.SaveChanges();

                projets = db.projets.Select(p => new ProjetViewModel
                {
                    projet = p,
                    projet_homepage_url = "/pages/Details/" + p.pages.Where(pa => pa.numero == 0).FirstOrDefault().id_page.ToString(),
                    deletion_url = "/home/DeleteProject/" + p.id_projet
                }).ToList();

                model.projets = projets;
                model.validation = true;
                model.validationMessage = "Projet crée avec succès";

                return View("Index", model);
            }

            projets = projets = db.projets.Select(p => new ProjetViewModel
            {
                projet = p
            }).ToList();           
            model.projets = projets;
            model.projet = projet;
            model.validation = false;

            return View("Index", model);
        }

        // GET: projets/Delete/5
        public ActionResult DeleteProject(int? id)
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

            HomePageViewModel model = new HomePageViewModel();
            IEnumerable<ProjetViewModel> projets = db.projets.Select(p => new ProjetViewModel
            {
                projet = p,
                projet_homepage_url = "/pages/Details/" + p.pages.Where(pa => pa.numero == 0).FirstOrDefault().id_page.ToString(),
                deletion_url = "/home/DeleteProject/" + p.id_projet
            }).ToList();

            model.projets = projets;
            model.projetToDelete = projet;
            
            return View("Index", model);
        }

        public ActionResult DeleteProjectConfirmed(int? id)
        {
            projet projet = db.projets.Find(id);

            projet.pages.ToList().ForEach(x => x.sections.ToList().ForEach(y => y.sous_section.ToList().ForEach(z => db.sous_section.Remove(z))));
            projet.pages.ToList().ForEach(x => x.sections.ToList().ForEach(y => db.sections.Remove(y)));
            projet.pages.ToList().ForEach(x => db.pages.Remove(x));
            db.projets.Remove(projet);

            db.SaveChanges();

            HomePageViewModel model = new HomePageViewModel();
            IEnumerable<ProjetViewModel> projets = db.projets.Select(p => new ProjetViewModel
            {
                projet = p,
                projet_homepage_url = "/pages/Details/" + p.pages.Where(pa => pa.numero == 0).FirstOrDefault().id_page.ToString(),
                deletion_url = "/home/DeleteProject/" + p.id_projet
            }).ToList();

            model.projets = projets;
            model.validation = true;
            model.validationMessage = "Projet supprimé avec succès";

            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}