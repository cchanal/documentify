using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace documentify.Models
{
    [MetadataType(typeof(projet.Metadata))]
    public partial class projet
    {
        private sealed class Metadata
        {
            [Required(ErrorMessage = "Le nom du projet est obligatoire")]
            public string nom { get; set; }
        }
    }
}