using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Models
{
    public class Intervention
    {
        public Guid IdIntervention { get; set; }
        public DateTime DateInterventionReelle { get; set; }
        public float FraisIntervention { get; set; }
        public string LibelleIntervention { get; set; }
        public string commentaire { get; set; }
        public DateTime DatePlannifiée { get; set; }
        public Guid? FkPrestataire { get; set; }
        public virtual Prestataire Prestataire { get; set; }
         public Guid? FkFiliale { get; set; }

        public Guid? FkEquipement { get; set; }
        public virtual Equipement Equipement { get; set; }


        public Guid? FktypeIntervention { get; set; }
        public virtual TypeIntervention TypeIntervention { get; set; }


        // ( Hatem ) 
        //public virtual ICollection<EquipementIntervention> EquipementInterventions { get; set; }
        //public Guid ? fkEquipementIntervention { get; set; }
        //public virtual EquipementIntervention EquipementIntervention { get; set; }

    }



}
