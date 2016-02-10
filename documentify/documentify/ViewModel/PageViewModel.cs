using documentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace documentify.ViewModel
{
    public class PageViewModel
    {

        public int id_projet;
        public string titre;
        public string description;

        public IEnumerable<PageLinkViewModel> pages;
        public IEnumerable<section> sections;

        public bool? validation = null;
        public bool creation = false;
        public string validationMessage = "";

        public page page;
    }
}