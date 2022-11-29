using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
    public class InterventionDto
    {

        public Guid IdIntervention { get; set; }
        public DateTime DateInterventionReelle { get; set; }
        public float FraisIntervention { get; set; }
        public string LibelleIntervention { get; set; }
        public string commentaire { get; set; }
        public DateTime DatePlannifiée { get; set; }

        public string NomPrenom { get; set; }

        public LibelleEquipement Libelle { get; set; }


        public string LibelleTypeInterv { get; set; }

    }
}
