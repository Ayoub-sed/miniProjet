using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
    public class GroupedCritereDTO
    {
        public string Axe { get; set; }

        public List<Critere> Critere { get; set; }


    }
}
