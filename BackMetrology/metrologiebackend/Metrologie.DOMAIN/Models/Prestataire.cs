using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Models
{
    public class Prestataire
    {
        public Guid PrestataireId { get; set; }
        public string Matricule { get; set; }
        public string NomPrenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }

        public TypePrestataire? TypeAccredite { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
  
        public enum TypePrestataire
        {
            Accredite,
            Agree,
        }











        // ( Hatem )  public virtual ICollection<PrestataireDomaine> PrestataireDomaines { get; set; }
        //public virtual ICollection<NoteCriterePrestataire> NoteCriterePrestataires { get; set; }
        // public virtual ICollection<Equipement> Equipements { get; set; }
        // ( Hatem ) 
    }







}
