//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace documentify.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class page
    {
        public page()
        {
            this.sections = new HashSet<section>();
        }
    
        public int id_page { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public int numero { get; set; }
        public int id_projet { get; set; }
    
        public virtual projet projet { get; set; }
        public virtual ICollection<section> sections { get; set; }
    }
}
