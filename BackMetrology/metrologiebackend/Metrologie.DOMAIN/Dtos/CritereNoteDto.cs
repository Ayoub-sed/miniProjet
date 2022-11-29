using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
   public class CritereNoteDto
    {
        public Guid CritereId { get; set; }
        public int CodeCritere { get; set; }
        public string LibelleCritere { get; set; }
        public string Axe { get; set; }
        public int Coefficient { get; set; }
        public double note { get; set; }
        public Boolean? done { get; set; }

    }
}
