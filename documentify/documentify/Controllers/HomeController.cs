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
            IEnumerable<ProjetViewModel> projets = db.projets.Select(p => new ProjetViewModel { 
                projet = p,
                projet_homepage_url = "/pages/Details/" + p.pages.Where(pa => pa.numero == 0).FirstOrDefault().id_page.ToString()
            }).ToList();
            model.projets = projets;

            return View(model);
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