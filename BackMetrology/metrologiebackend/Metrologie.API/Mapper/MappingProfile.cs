using AutoMapper;
using Metrologie.Domain.Dtos;
using Metrologie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrologie.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Prestataire, PrestataireDto>()
               .ReverseMap();

            //CreateMap<PrestataireDomaine, PrestataireDomaineDto>()
            //    .ForMember(src => src.LibelleDomaine, src => src.MapFrom(src => src.Domaine.LibelleDomaine))
            //   .ReverseMap();
            
            CreateMap<NoteCritere, NoteCritereDTO>()
             .ForMember(src => src.LibelleCritere, src => src.MapFrom(src => src.Critere.LibelleCritere))
             .ForMember(src => src.Axe, src => src.MapFrom(src => src.Critere.Axe)).ReverseMap();

            CreateMap<Critere, CritereNoteDto>()
          .ReverseMap();


            CreateMap<Intervention,InterventionDto>()
          .ForMember(src => src.NomPrenom, src => src.MapFrom(src => src.Prestataire.NomPrenom))
          .ForMember(src => src.Libelle, src => src.MapFrom(src => src.Equipement.Libelle))
          .ForMember(src => src.LibelleTypeInterv, src => src.MapFrom(src => src.TypeIntervention.LibelleTypeInterv)).ReverseMap();



            CreateMap<Equipement, EquipementDto>()
             //.ForMember(d => d.Libelle, i => i.MapFrom(src => src.GetType().Name))
             //.ForMember(d => d.Type, i => i.MapFrom(src => src.GetType().Name))
             .ReverseMap();

            CreateMap<Bain, EquipementDto>()
            .ReverseMap();
            CreateMap<BalanceDePrecision, EquipementDto>()
           .ReverseMap();
            CreateMap<PhMetre, EquipementDto>()
           .ReverseMap();
            CreateMap<BalanceElectronique, EquipementDto>()
           .ReverseMap();
            CreateMap<CapteurDePression, EquipementDto>()
           .ReverseMap();
            CreateMap<ChambreFroide, EquipementDto>()
           .ReverseMap();
            CreateMap<Conductivimetre, EquipementDto>()
           .ReverseMap();
            CreateMap<DebimetreMassique, EquipementDto>()
           .ReverseMap();
            CreateMap<DebimetreVolumetrique, EquipementDto>()
           .ReverseMap();
            CreateMap<Etuve, EquipementDto>()
           .ReverseMap();
            CreateMap<Four, EquipementDto>()
            .ReverseMap();
            CreateMap<ManometreDePression, EquipementDto>()
             .ReverseMap();
            CreateMap<PontsBasculeElectronique, EquipementDto>()
            .ReverseMap();
            CreateMap<Refrigerateur, EquipementDto>()
            .ReverseMap();
            CreateMap<SondeRedox, EquipementDto>()
            .ReverseMap();
            CreateMap<Thermohygometre, EquipementDto>()
            .ReverseMap();
             CreateMap<Thermometre, EquipementDto>()
            . ReverseMap();
              CreateMap<TransmtteurDePression, EquipementDto>()
            . ReverseMap();
              CreateMap<TunnelDeRefroidissement, EquipementDto>()
            .ReverseMap();


        }
    }
    
}
