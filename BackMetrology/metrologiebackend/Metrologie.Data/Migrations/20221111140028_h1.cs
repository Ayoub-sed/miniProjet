using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrologie.Data.Migrations
{
    public partial class h1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipements_FraisInterventions_FkFraisIntervention",
                table: "Equipements");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipements_Prestataires_FkPrestataire",
                table: "Equipements");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipementTypeInterventions_TypeInterventions_FkTypeIntervention",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropTable(
                name: "EquipementFiliales");

            migrationBuilder.DropTable(
                name: "FraisInterventions");

            migrationBuilder.DropTable(
                name: "PrestataireDomaines");

            migrationBuilder.DropTable(
                name: "TypeInterventions");

            migrationBuilder.DropTable(
                name: "Emplacements");

            migrationBuilder.DropTable(
                name: "Domaines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipementTypeInterventions",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropIndex(
                name: "IX_EquipementTypeInterventions_FkTypeIntervention",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropIndex(
                name: "IX_Equipements_FkFraisIntervention",
                table: "Equipements");

            migrationBuilder.DropIndex(
                name: "IX_Equipements_FkPrestataire",
                table: "Equipements");

            migrationBuilder.DropColumn(
                name: "EquipementTypeInterventionId",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropColumn(
                name: "FkTypeIntervention",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropColumn(
                name: "FkFraisIntervention",
                table: "Equipements");

            migrationBuilder.DropColumn(
                name: "FkPrestataire",
                table: "Equipements");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipementInterventionId",
                table: "EquipementTypeInterventions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FkIntervention",
                table: "EquipementTypeInterventions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "grandeur",
                table: "Equipements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipementTypeInterventions",
                table: "EquipementTypeInterventions",
                column: "EquipementInterventionId");

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    IdInterventions = table.Column<Guid>(nullable: false),
                    DateIntervention = table.Column<DateTime>(nullable: false),
                    Frais = table.Column<int>(nullable: false),
                    LibelleIntervention = table.Column<string>(nullable: true),
                    TypeIntervention = table.Column<int>(nullable: false),
                    commentaire = table.Column<string>(nullable: true),
                    DatePlannifiée = table.Column<DateTime>(nullable: false),
                    FkPrestataire = table.Column<Guid>(nullable: true),
                    FkFiliale = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.IdInterventions);
                    table.ForeignKey(
                        name: "FK_Interventions_Prestataires_FkPrestataire",
                        column: x => x.FkPrestataire,
                        principalTable: "Prestataires",
                        principalColumn: "PrestataireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipementTypeInterventions_FkIntervention",
                table: "EquipementTypeInterventions",
                column: "FkIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_FkPrestataire",
                table: "Interventions",
                column: "FkPrestataire");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipementTypeInterventions_Interventions_FkIntervention",
                table: "EquipementTypeInterventions",
                column: "FkIntervention",
                principalTable: "Interventions",
                principalColumn: "IdInterventions",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipementTypeInterventions_Interventions_FkIntervention",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipementTypeInterventions",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropIndex(
                name: "IX_EquipementTypeInterventions_FkIntervention",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropColumn(
                name: "EquipementInterventionId",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropColumn(
                name: "FkIntervention",
                table: "EquipementTypeInterventions");

            migrationBuilder.DropColumn(
                name: "grandeur",
                table: "Equipements");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipementTypeInterventionId",
                table: "EquipementTypeInterventions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FkTypeIntervention",
                table: "EquipementTypeInterventions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FkFraisIntervention",
                table: "Equipements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FkPrestataire",
                table: "Equipements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipementTypeInterventions",
                table: "EquipementTypeInterventions",
                column: "EquipementTypeInterventionId");

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    DomaineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibelleDomaine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.DomaineId);
                });

            migrationBuilder.CreateTable(
                name: "Emplacements",
                columns: table => new
                {
                    EmplacementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplacements", x => x.EmplacementId);
                });

            migrationBuilder.CreateTable(
                name: "FraisInterventions",
                columns: table => new
                {
                    FraisInterventionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateIntervention = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkFiliale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Frais = table.Column<int>(type: "int", nullable: false),
                    LibelleIntervention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIntervention = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FraisInterventions", x => x.FraisInterventionId);
                });

            migrationBuilder.CreateTable(
                name: "TypeInterventions",
                columns: table => new
                {
                    TypeInterventionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AxeIntervention = table.Column<int>(type: "int", nullable: false),
                    LibelleTypeInterv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInterventions", x => x.TypeInterventionId);
                });

            migrationBuilder.CreateTable(
                name: "PrestataireDomaines",
                columns: table => new
                {
                    PrestataireDomaineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accredite = table.Column<bool>(type: "bit", nullable: false),
                    Agree = table.Column<bool>(type: "bit", nullable: false),
                    FkDomaine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FkPrestataire = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "EquipementFiliales",
                columns: table => new
                {
                    EquipementFilialeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkEmplacement = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fkEquipementTypeIntervention = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "IX_EquipementTypeInterventions_FkTypeIntervention",
                table: "EquipementTypeInterventions",
                column: "FkTypeIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_FkFraisIntervention",
                table: "Equipements",
                column: "FkFraisIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_FkPrestataire",
                table: "Equipements",
                column: "FkPrestataire");

            migrationBuilder.CreateIndex(
                name: "IX_EquipementFiliales_FkEmplacement",
                table: "EquipementFiliales",
                column: "FkEmplacement");

            migrationBuilder.CreateIndex(
                name: "IX_EquipementFiliales_fkEquipementTypeIntervention",
                table: "EquipementFiliales",
                column: "fkEquipementTypeIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_PrestataireDomaines_FkDomaine",
                table: "PrestataireDomaines",
                column: "FkDomaine");

            migrationBuilder.CreateIndex(
                name: "IX_PrestataireDomaines_FkPrestataire",
                table: "PrestataireDomaines",
                column: "FkPrestataire");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipements_FraisInterventions_FkFraisIntervention",
                table: "Equipements",
                column: "FkFraisIntervention",
                principalTable: "FraisInterventions",
                principalColumn: "FraisInterventionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipements_Prestataires_FkPrestataire",
                table: "Equipements",
                column: "FkPrestataire",
                principalTable: "Prestataires",
                principalColumn: "PrestataireId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipementTypeInterventions_TypeInterventions_FkTypeIntervention",
                table: "EquipementTypeInterventions",
                column: "FkTypeIntervention",
                principalTable: "TypeInterventions",
                principalColumn: "TypeInterventionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
