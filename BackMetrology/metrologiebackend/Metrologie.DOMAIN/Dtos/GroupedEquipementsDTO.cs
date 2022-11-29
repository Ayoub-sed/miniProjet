using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
   public class GroupedEquipementsDTO
    {
        public string Libelle { get; set; }

        public List<EquipementDto> EquipementDto { get; set; }
    }
}
