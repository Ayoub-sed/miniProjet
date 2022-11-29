using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
    public class EquipementDto
    {
        public Guid EquipementId { get; set; }
        public string IdentifiantInterne { get; set; }
        public string NumeroSerie { get; set; }
        public string Marque { get; set; }
        public string Type { get; set; }
        public string Libelle { get; set; }
        public float Temperature
        {
            get; set;
        }
        public DateTime DateEtalonnage
        {
            get; set;
        }
        public DateTime DateVerification
        {
            get; set;
        }
        public float PressionMesuree
        {
            get; set;
        }
        public float PorteMax { get; set; }

        public float PorteMin { get; set; }

        public int EchellonDeVerification { get; set; }

        public int NumApprobation { get; set; }

        public int NumVignette { get; set; }

        public DateTime DatePoinconnage { get; set; }

        public int NombreCapteurs { get; set; }

        public DateTime DateReparation { get; set; }

        public Guid? FkFiliale { get; set; }
    }
}
