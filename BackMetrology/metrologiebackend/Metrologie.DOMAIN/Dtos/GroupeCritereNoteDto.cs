using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Dtos
{
   public  class GroupeCritereNoteDto
    {
        public string Axe { get; set; }

        public List<CritereNoteDto> Critere { get; set; }
        public double NoteAxe { get; set; }

    }
}
