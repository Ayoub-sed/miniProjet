using Metrologie.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Data.Context
{
    public class MetrologieContext : DbContext
    {
        public MetrologieContext(DbContextOptions<MetrologieContext> options)
           : base(options)
        {
        }
        public DbSet<PhMetre> PhMetre { get; set; }
        public DbSet<Critere> Criteres { get; set; }
        public DbSet<Prestataire> Prestataires { get; set; }
        public DbSet<TypeIntervention> TypeInterventions { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<NoteCritere> NoteCriteres { get; set; }
        public DbSet<Intervention> Interventions { get; set; }

        #region equipements DbSet
        public DbSet<Ensacheuse> Ensacheuses { get; set; }
        public DbSet<PontsBasculeElectronique> PontsBasculeElectroniques { get; set; }
        public DbSet<Thermometre> Thermometres { get; set; }
        public DbSet<Thermohygometre> Thermohygometres { get; set; }
        public DbSet<Bain> Bains { get; set; }
        public DbSet<Four> Fours { get; set; }
        public DbSet<Etuve> Etuves { get; set; }
        public DbSet<Refrigerateur> Refrigerateurs { get; set; }
        public DbSet<ChambreFroide> ChambreFroides { get; set; }
        public DbSet<TunnelDeRefroidissement> TunnelDeRefroidissements { get; set; }
        public DbSet<Conductivimetre> Conductivimetres { get; set; }
        public DbSet<SondeRedox> SondeRedoxes { get; set; }
        public DbSet<DebimetreMassique> DebimetreMassiques { get; set; }
        public DbSet<DebimetreVolumetrique> DebimetreVolumetriques { get; set; }
        public DbSet<ManometreDePression> ManometreDePressions { get; set; }
        public DbSet<CapteurDePression> CapteurDePressions { get; set; }
  
        public DbSet<TransmtteurDePression> TransmtteurDePressions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Critere>()
                .HasKey(e => e.CritereId);

  

            modelBuilder.Entity<Prestataire>()
                .HasKey(e => e.PrestataireId);

         modelBuilder.Entity<TypeIntervention>()
             .HasKey(e => e.TypeInterventionId);

            modelBuilder.Entity<Equipement>()
                .HasKey(e => e.EquipementId);

            
            modelBuilder.Entity<NoteCritere>()
                .HasKey(e => e.NoteCritereId);

            modelBuilder.Entity<Intervention>()
               .HasKey(e => e.IdIntervention);


            modelBuilder.Entity<NoteCritere>()
             .HasOne(e => e.Critere)
             .WithMany(e => e.NoteCriteres)
             .HasForeignKey(e => e.FkCritere);


            modelBuilder.Entity<Intervention>()
               .HasOne(e => e.Prestataire)
               .WithMany(e => e.Interventions)
               .HasForeignKey(e => e.FkPrestataire);



            // ( Hatem ) modelBuilder.Entity<EquipementFiliale> ()
            //   .HasOne(e => e.Emplacement)
            //   .WithMany(e => e.EquipementFiliale)
            //   .HasForeignKey(e => e.FkEmplacement);

            //modelBuilder.Entity<ChElectrique>()
            //    .Property(p => p.PrixUnitaire).HasColumnType("decimal(18, 6)");
            // ( Hatem ) 
            //modelBuilder.Entity<EquipementIntervention>()
            //    .HasKey(e => e.EquipementInterventionId);

            // ( Hatem ) modelBuilder.Entity<PrestataireDomaine>()
            //    .HasKey(e => e.PrestataireDomaineId);

            //modelBuilder.Entity<EquipementFiliale>()
            //    .HasKey(e => e.EquipementFilialeId); 

            // ( Hatem ) modelBuilder.Entity<Interventions>()
            // .HasOne(e => e.Prestataire)
            // .WithMany(e => e.Interventions)
            // .HasForeignKey(e => e.FkPrestataire);
            //// ( Hatem ) 

            //modelBuilder.Entity<Interventions>()
            // .HasOne(e => e.EquipementIntervention)
            // .WithMany(e => e.Interventions)
            // .HasForeignKey(e => e.fkEquipementIntervention);
            // ( Hatem ) 

            //modelBuilder.Entity<NoteCriterePrestataire>()
            //    .HasKey(n => new { n.FkNoteCritere, n.FkPrestataire });

            // ( Hatem ) modelBuilder.Entity<Emplacement>()
            //   .HasKey(e => e.EmplacementId);

            // ( Hatem )modelBuilder.Entity<FraisIntervention>()
            //   .HasKey(e => e.FraisInterventionId);

            // ( Hatem ) modelBuilder.Entity<Equipement>()
            // .HasOne(e => e.FraisIntervention)
            // .WithMany(e => e.Equipements)
            // .HasForeignKey(e => e.FkFraisIntervention);

            // ( Hatem ) modelBuilder.Entity<Equipement>()
            // .HasOne(e => e.Prestataire)
            // .WithMany(e => e.Equipements)
            // .HasForeignKey(e => e.FkPrestataire);

            //modelBuilder.Entity<NoteCriterePrestataire>()
            // .HasOne(e => e.NoteCritere)
            // .WithMany(e => e.NoteCriterePrestataires)
            // .HasForeignKey(e => e.FkNoteCritere);

            //modelBuilder.Entity<NoteCriterePrestataire>()
            //  .HasOne(e => e.Prestataire)
            //  .WithMany(e => e.NoteCriterePrestataires)
            //  .HasForeignKey(e => e.FkPrestataire);




            // ( Hatem ) 




            //modelBuilder.Entity<EquipementIntervention>()
            //    .HasOne(e => e.Equipement)
            //    .WithMany(e => e.EquipementInterventions)
            //    .HasForeignKey(e => e.FkEquipement);

            //modelBuilder.Entity<EquipementIntervention>()
            //   .HasOne(e => e.Interventions)
            //   .WithMany(e => e.EquipementInterventions)
            //   .HasForeignKey(e => e.FkIntervention);

            // ( Hatem ) modelBuilder.Entity<PrestataireDomaine>()
            //  .HasOne(e => e.Prestataire)
            //  .WithMany(e => e.PrestataireDomaines)
            //  .HasForeignKey(e => e.FkPrestataire);

            // ( Hatem ) modelBuilder.Entity<PrestataireDomaine>()
            //.HasOne(e => e.Domaine)
            //.WithMany(e => e.PrestataireDomaines)
            //.HasForeignKey(e => e.FkDomaine);

            //modelBuilder.Entity<EquipementFiliale>()
            //   .HasOne(e => e.EquipementTypeIntervention)
            //   .WithMany(e => e.EquipementFiliales)
            //   .HasForeignKey(e => e.fkEquipementTypeIntervention); 

        }
    }
}
