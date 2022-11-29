using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Metrologie.Domain.Models.Prestataire;

namespace Metrologie.Domain.Dtos
{
    public class PrestataireDto
    {
        public Guid PrestataireId { get; set; }
        public string Matricule { get; set; }
        public string NomPrenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public TypePrestataire TypeAccredite { get; set; }
    }
}
