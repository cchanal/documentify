﻿using documentify.Models;
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
            IEnumerable<projet> projet = new List<projet>();
            projet = db.projets.ToList();
            return View(projet);
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