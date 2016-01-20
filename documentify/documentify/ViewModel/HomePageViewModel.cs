using documentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace documentify.ViewModel
{
    public class HomePageViewModel
    {
        public IEnumerable<ProjetViewModel> projets = new List<ProjetViewModel>();
        public projet projet = new projet();

        public bool creation = false;
        public projet projetToDelete = null;
        public projet projetToEdit = null;

        public bool? validation = null;
        public string validationMessage = "";
    }
}