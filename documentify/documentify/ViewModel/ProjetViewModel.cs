using documentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace documentify.ViewModel
{
    public class ProjetViewModel
    {
        public projet projet = new projet();
        public string projet_homepage_url;
        public string deletion_url;
        public string edition_url;
    }
}