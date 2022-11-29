    using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Models
{
    public class Critere
    {
        public Guid CritereId { get; set; }
        public int CodeCritere { get; set; }
        public string LibelleCritere { get; set; }
        public string Axe { get; set; }
        public int Coefficient { get; set; }
        public virtual ICollection<NoteCritere> NoteCriteres { get; set; }

    }
}
