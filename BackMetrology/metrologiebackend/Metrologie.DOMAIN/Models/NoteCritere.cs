using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Metrologie.Domain.Models
{
    public class NoteCritere
    {
        public Guid NoteCritereId { get; set; }
        public double Note { get; set; }
        public DateTime DateDebut { get; set; }
        public virtual Critere Critere { get; set; }
        public Guid? FkCritere { get; set; }
        public Guid? FkFiliale { get; set; }
        public string Axe { get; set; }
        public Boolean? Done { get; set; }

        //public Guid FkPrestataire { get; set; }
        //public virtual ICollection<NoteCriterePrestataire> NoteCriterePrestataires { get; set; }

    }
}
