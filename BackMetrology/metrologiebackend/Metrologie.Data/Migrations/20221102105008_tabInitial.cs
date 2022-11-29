using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrologie.Data.Migrations
{
    public partial class tabInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criteres",
                columns: table => new
                {
                    CritereId = table.Column<Guid>(nullable: false),
                    CodeCritere = table.Column<int>(nullable: false),
                    LibelleCritere = table.Column<string>(nullable: true),
                    Axe = table.Column<string>(nullable: true),
                    Coefficient = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteres", x => x.CritereId);
                });

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    DomaineId = table.Column<Guid>(nullable: false),
                    LibelleDomaine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.DomaineId);
                });

            migrationBuilder.CreateTable(
                name: "Emplacements",
                columns: table => new
                {
                    EmplacementId = table.Column<Guid>(nullable: false),
                    Localisation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplacements", x => x.EmplacementId);
                });

            migrationBuilder.CreateTable(
                name: "FraisInterventions",
                columns: table => new
                {
                    FraisInterventionId = table.Column<Guid>(nullable: false),
                    FkFiliale = table.Column<Guid>(nullable: false),
                    DateIntervention = table.Column<DateTime>(nullable: false),
                    Frais = table.Column<int>(nullable: false),
                    LibelleIntervention = table.Column<string>(nullable: true),
                    TypeIntervention = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FraisInterventions", x => x.FraisInterventionId);
                });

            migrationBuilder.CreateTable(
                name: "Prestataires",
                columns: table => new
                {
                    PrestataireId = table.Column<Guid>(nullable: false),
                    Matricule = table.Column<string>(nullable: true),
                    NomPrenom = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestataires", x => x.PrestataireId);
                });

            migrationBuilder.CreateTable(
                name: "TypeInterventions",
                columns: table => new
                {
                    TypeInterventionId = table.Column<Guid>(nullable: false),
                    LibelleTypeInterv = table.Column<string>(nullable: true),
                    AxeIntervention = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInterventions", x => x.TypeInterventionId);
                });

            migrationBuilder.CreateTable(
                name: "NoteCriteres",
                columns: table => new
                {
                    NoteCritereId = table.Column<Guid>(nullable: false),
                    Note = table.Column<float>(nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    FkCritere = table.Column<Guid>(nullable: true),
                    FkFiliale = table.Column<Guid>(nullable: true),
                    Axe = table.Column<string>(nullable: true),
                    FkPrestataire = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteCriteres", x => x.NoteCritereId);
                    table.ForeignKey(
                        name: "FK_NoteCriteres_Criteres_FkCritere",
                        column: x => x.FkCritere,
                        principalTable: "Criteres",
                        principalColumn: "CritereId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    EquipementId = table.Column<Guid>(nullable: false),
                    IdentifiantInterne = table.Column<string>(nullable: true),
                    NumeroSerie = table.Column<string>(nullable: true),
                    Marque = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Libelle = table.Column<int>(nullable: false),
                    FkFiliale = table.Column<Guid>(nullable: true),
                    FkFraisIntervention = table.Column<Guid>(nullable: true),
                    FkPrestataire = table.Column<Guid>(nullable: true),
                    Temperature = table.Column<float>(nullable: true),
                    DateEtalonnage = table.Column<DateTime>(nullable: true),
                    DateVerification = table.Column<DateTime>(nullable: true),
                    PorteMax = table.Column<float>(nullable: true),
                    PorteMin = table.Column<float>(nullable: true),
                    EchelonDeVerification = table.Column<float>(nullable: true),
                    NumApprobation = table.Column<int>(nullable: true),
                    NumVignette = table.Column<int>(nullable: true),
                    DatePoinconnage = table.Column<DateTime>(nullable: true),
                    PressionMesuree = table.Column<float>(nullable: true),
                    EchellonDeVerification = table.Column<int>(nullable: true),
                    NombreCapteurs = table.Column<int>(nullable: true),
                    DateReparation = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.EquipementId);
                    table.ForeignKey(
                        name: "FK_Equipements_FraisInterventions_FkFraisIntervention",
                        column: x => x.FkFraisIntervention,
                        principalTable: "FraisInterventions",
                        principalColumn: "FraisInterventionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipements_Prestataires_FkPrestataire",
                        column: x => x.FkPrestataire,
                        principalTable: "Prestataires",
                        principalColumn: "PrestataireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrestataireDomaines",
                columns: table => new
                {
                    PrestataireDomaineId = table.Column<Guid>(nullable: false),
                    FkPrestataire = table.Column<Guid>(nullable: true),
                    FkDomaine = table.Column<Guid>(nullable: true),
                    Accredite = table.Column<bool>(nullable: false),
                    Agree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestataireDomaines", x => x.PrestataireDomaineId);
                    table.ForeignKey(
                        name: "FK_PrestataireDomaines_Domaines_FkDomaine",
                        column: x => x.FkDomaine,
                        principalTable: "Domaines",
                        principalColumn: "DomaineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrestataireDomaines_Prestataires_FkPrestataire",
                        column: x => x.FkPrestataire,
                        principalTable: "Prestataires",
                        principalColumn: "PrestataireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteCriterePrestataires",
                columns: table => new
                {
                    FkNoteCritere = table.Column<Guid>(nullable: false),
                    FkPrestataire = table.Column<Guid>(nullable: false),
                    DateNotePrestataire = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteCriterePrestataires", x => new { x.FkNoteCritere, x.FkPrestataire });
                    table.ForeignKey(
                        name: "FK_NoteCriterePrestataires_NoteCriteres_FkNoteCritere",
                        column: x => x.FkNoteCritere,
                        principalTable: "NoteCriteres",
                        principalColumn: "NoteCritereId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteCriterePrestataires_Prestataires_FkPrestataire",
                        column: x => x.FkPrestataire,
                        principalTable: "Prestataires",
                        principalColumn: "PrestataireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipementTypeInterventions",
                columns: table => new
                {
                    EquipementTypeInterventionId = table.Column<Guid>(nullable: false),
                    FkEquipement = table.Column<Guid>(nullable: true),
                    FkTypeIntervention = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipementTypeInterventions", x => x.EquipementTypeInterventionId);
                    table.ForeignKey(
                        name: "FK_EquipementTypeInterventions_Equipements_FkEquipement",
                        column: x => x.FkEquipement,
                        principalTable: "Equipements",
                        principalColumn: "EquipementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipementTypeInterventions_TypeInterventions_FkTypeIntervention",
                        column: x => x.FkTypeIntervention,
                        principalTable: "TypeInterventions",
                        principalColumn: "TypeInterventionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipementFiliales",
                columns: table => new
                {
                    EquipementFilialeId = table.Column<Guid>(nullable: false),
                    fkEquipementTypeIntervention = table.Column<Guid>(nullable: true),
                    FkEmplacement = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipementFiliales", x => x.EquipementFilialeId);
                    table.ForeignKey(
                        name: "FK_EquipementFiliales_Emplacements_FkEmplacement",
                        column: x => x.FkEmplacement,
                        principalTable: "Emplacements",
                        principalColumn: "EmplacementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipementFiliales_EquipementTypeInterventions_fkEquipementTypeIntervention",
                        column: x => x.fkEquipementTypeIntervention,
                        principalTable: "EquipementTypeInterventions",
                        principalColumn: "EquipementTypeInterventionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipementFiliales_FkEmplacement",
                table: "EquipementFiliales",
                column: "FkEmplacement");

            migrationBuilder.CreateIndex(
                name: "IX_EquipementFiliales_fkEquipementTypeIntervention",
                table: "EquipementFiliales",
                column: "fkEquipementTypeIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_FkFraisIntervention",
                table: "Equipements",
                column: "FkFraisIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_FkPrestataire",
                table: "Equipements",
                column: "FkPrestataire");

            migrationBuilder.CreateIndex(
                name: "IX_EquipementTypeInterventions_FkEquipement",
                table: "EquipementTypeInterventions",
                column: "FkEquipement");

            migrationBuilder.CreateIndex(
                name: "IX_EquipementTypeInterventions_FkTypeIntervention",
                table: "EquipementTypeInterventions",
                column: "FkTypeIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCriterePrestataires_FkPrestataire",
                table: "NoteCriterePrestataires",
                column: "FkPrestataire");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCriteres_FkCritere",
                table: "NoteCriteres",
                column: "FkCritere");

            migrationBuilder.CreateIndex(
                name: "IX_PrestataireDomaines_FkDomaine",
                table: "PrestataireDomaines",
                column: "FkDomaine");

            migrationBuilder.CreateIndex(
                name: "IX_PrestataireDomaines_FkPrestataire",
                table: "PrestataireDomaines",
                column: "FkPrestataire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipementFiliales");

            migrationBuilder.DropTable(
                name: "NoteCriterePrestataires");

            migrationBuilder.DropTable(
                name: "PrestataireDomaines");

            migrationBuilder.DropTable(
                name: "Emplacements");

            migrationBuilder.DropTable(
                name: "EquipementTypeInterventions");

            migrationBuilder.DropTable(
                name: "NoteCriteres");

            migrationBuilder.DropTable(
                name: "Domaines");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "TypeInterventions");

            migrationBuilder.DropTable(
                name: "Criteres");

            migrationBuilder.DropTable(
                name: "FraisInterventions");

            migrationBuilder.DropTable(
                name: "Prestataires");
        }
    }
}
