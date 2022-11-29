using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
    public class NoteCritereDTO
    {
        public Guid NoteCritereId { get; set; }
        public double Note { get; set; }
        public DateTime DateDebut { get; set; }
        public Guid? FkCritere { get; set; }
        public Guid? FkFiliale { get; set; }
        public Guid? FkNoteAxe { get; set; }
        public string LibelleCritere { get; set; }
        public string Axe { get; set; }
        public Boolean Done { get; set; }
    }
}
