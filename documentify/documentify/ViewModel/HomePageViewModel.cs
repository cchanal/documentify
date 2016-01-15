using documentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace documentify.ViewModel
{
    public class HomePageViewModel
    {
        public IEnumerable<projet> projets = new List<projet>();
        public projet projet = new projet();
        public bool? validation = null;
    }
}