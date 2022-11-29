using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Models
{
    public class Equipement
    {
        public Guid EquipementId { get; set; }
        public string IdentifiantInterne { get; set; }
        public string NumeroSerie { get; set; }
        public string Marque { get; set; }


        public Grandeur grandeur { get; set; }
        public Etat EtatEquipement { get; set; }
        public TypeEquipement Type { get; set; }



        public LibelleEquipement Libelle { get; set; }
        public Guid? FkFiliale { get; set; }

        public float? Temperature { get; set; }
        public DateTime? DateEtalonnage { get; set; }
        public DateTime? DateVerification { get; set; }
        public float? PorteMax { get; set; }
        public float? PorteMin { get; set; }

        public int? NumApprobation { get; set; }

        public int? NumVignette { get; set; }
        public DateTime? DatePoinconnage { get; set; }

        public float? PressionMesuree { get; set; }

        public int? EchellonDeVerification { get; set; }

        public int? NombreCapteurs { get; set; }

        public DateTime? DateReparation { get; set; }
      


        public enum Grandeur
        {
            Pesage,
            Temperature,
            Pression,
            Autre
        }
        public enum Etat
        {
            Panne,
            Reparation,
            Fonction
        }


        public enum TypeEquipement
        {
            NonReglementaire,
            Reglementaire
        }







        // ( Hatem ) public Guid? FkFraisIntervention { get; set; }
        //public virtual FraisIntervention FraisIntervention { get; set; }
        //public Guid? FkPrestataire { get; set; }
        //public virtual Prestataire Prestataire { get; set; }

    }
}
