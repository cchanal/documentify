using documentify.Models;
using documentify.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<projet> projet = new List<projet>();
            projet = db.projets.ToList();
            model.projets = projet;

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
            IEnumerable<projet> projets = new List<projet>();

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

                projets = db.projets.ToList();
                model.projets = projets;
                model.validation = true;
                //return RedirectToAction("Index");
                //return RedirectToAction("Index", "Home", new { area = "" });
                return View("Index", model);
            }

            projets = db.projets.ToList();           
            model.projets = projets;
            model.projet = projet;
            model.validation = false;

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