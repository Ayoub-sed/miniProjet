using Metrologie.Data.Repository;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Metrologie.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Critere>, GenericRepository<Critere>>();
            // ( Hatem ) services.AddTransient<IGenericRepository<Domaine>, GenericRepository<Domaine>>();
            services.AddTransient<IGenericRepository<Prestataire>, GenericRepository<Prestataire>>();
          services.AddTransient<IGenericRepository<TypeIntervention>, GenericRepository<TypeIntervention>>();
            services.AddTransient<IGenericRepository<Equipement>, GenericRepository<Equipement>>();
            //services.AddTransient<IGenericRepository<EquipementIntervention>, GenericRepository<EquipementIntervention>>();
            // ( Hatem ) services.AddTransient<IGenericRepository<PrestataireDomaine>, GenericRepository<PrestataireDomaine>>();
            services.AddTransient<IGenericRepository<NoteCritere>, GenericRepository<NoteCritere>>();
            // ( Hatem ) services.AddTransient<IGenericRepository<Emplacement>, GenericRepository<Emplacement>>();
            // ( Hatem ) services.AddTransient<IGenericRepository<EquipementFiliale>, GenericRepository<EquipementFiliale>>();
            // ( Hatem ) services.AddTransient<IGenericRepository<FraisIntervention>, GenericRepository<FraisIntervention>>(); 
            services.AddTransient<IGenericRepository<Bain>, GenericRepository<Bain>>();
            services.AddTransient<IGenericRepository<PhMetre>, GenericRepository<PhMetre>>();
            services.AddTransient<IGenericRepository<BalanceDePrecision>, GenericRepository<BalanceDePrecision>>();
            services.AddTransient<IGenericRepository<BalanceElectronique>, GenericRepository<BalanceElectronique>>();
            services.AddTransient<IGenericRepository<CapteurDePression>, GenericRepository<CapteurDePression>>();
            services.AddTransient<IGenericRepository<ChambreFroide>, GenericRepository<ChambreFroide>>();
            services.AddTransient<IGenericRepository<Conductivimetre>, GenericRepository<Conductivimetre>>();
            services.AddTransient<IGenericRepository<DebimetreMassique>, GenericRepository<DebimetreMassique>>();
            services.AddTransient<IGenericRepository<DebimetreVolumetrique>, GenericRepository<DebimetreVolumetrique>>();
            services.AddTransient<IGenericRepository<Ensacheuse>, GenericRepository<Ensacheuse>>();
            services.AddTransient<IGenericRepository<Etuve>, GenericRepository<Etuve>>();
            services.AddTransient<IGenericRepository<Four>, GenericRepository<Four>>();
            services.AddTransient<IGenericRepository<ManometreDePression>, GenericRepository<ManometreDePression>>();
            services.AddTransient<IGenericRepository<PontsBasculeElectronique>, GenericRepository<PontsBasculeElectronique>>();
            services.AddTransient<IGenericRepository<Refrigerateur>, GenericRepository<Refrigerateur>>();
            services.AddTransient<IGenericRepository<SondeRedox>, GenericRepository<SondeRedox>>();
            services.AddTransient<IGenericRepository<Thermohygometre>, GenericRepository<Thermohygometre>>();
            services.AddTransient<IGenericRepository<Thermometre>, GenericRepository<Thermometre>>();
            services.AddTransient<IGenericRepository<TunnelDeRefroidissement>, GenericRepository<TunnelDeRefroidissement>>();
            services.AddTransient<IGenericRepository<TransmtteurDePression>, GenericRepository<TransmtteurDePression>>();
            // ( Hatem ) 
            services.AddTransient<IGenericRepository<Intervention>, GenericRepository<Intervention>>();
        }
    }
}
