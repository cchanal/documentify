using documentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace documentify.ViewModel
{
    public class PageViewModel
    {

        public projet projet;
        public string titre;
        public string description;

        public IEnumerable<page> pages;
        public IEnumerable<section> sections;
    }
}