using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrologie.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipementTypeInterventions");

            migrationBuilder.DropTable(
                name: "NoteCriterePrestataires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interventions",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "FkPrestataire",
                table: "NoteCriteres");

            migrationBuilder.DropColumn(
                name: "IdInterventions",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "DateIntervention",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "Frais",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "TypeIntervention",
                table: "Interventions");

            migrationBuilder.AddColumn<int>(
                name: "TypeAccredite",
                table: "Prestataires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "IdIntervention",
                table: "Interventions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInterventionReelle",
                table: "Interventions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "EquipementId",
                table: "Interventions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FkEquipement",
                table: "Interventions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FktypeIntervention",
                table: "Interventions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "FraisIntervention",
                table: "Interventions",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeInterventionId",
                table: "Interventions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtatEquipement",
                table: "Equipements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interventions",
                table: "Interventions",
                column: "IdIntervention");

            migrationBuilder.CreateTable(
                name: "TypeInterventions",
                columns: table => new
                {
                    TypeInterventionId = table.Column<Guid>(nullable: false),
                    LibelleTypeInterv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInterventions", x => x.TypeInterventionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_EquipementId",
                table: "Interventions",
                column: "EquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_TypeInterventionId",
                table: "Interventions",
                column: "TypeInterventionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_Equipements_EquipementId",
                table: "Interventions",
                column: "EquipementId",
                principalTable: "Equipements",
                principalColumn: "EquipementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_TypeInterventions_TypeInterventionId",
                table: "Interventions",
                column: "TypeInterventionId",
                principalTable: "TypeInterventions",
                principalColumn: "TypeInterventionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_Equipements_EquipementId",
                table: "Interventions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_TypeInterventions_TypeInterventionId",
                table: "Interventions");

            migrationBuilder.DropTable(
                name: "TypeInterventions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interventions",
                table: "Interventions");

            migrationBuilder.DropIndex(
                name: "IX_Interventions_EquipementId",
                table: "Interventions");

            migrationBuilder.DropIndex(
                name: "IX_Interventions_TypeInterventionId",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "TypeAccredite",
                table: "Prestataires");

            migrationBuilder.DropColumn(
                name: "IdIntervention",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "DateInterventionReelle",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "EquipementId",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "FkEquipement",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "FktypeIntervention",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "FraisIntervention",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "TypeInterventionId",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "EtatEquipement",
                table: "Equipements");

            migrationBuilder.AddColumn<Guid>(
                name: "FkPrestataire",
                table: "NoteCriteres",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdInterventions",
                table: "Interventions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIntervention",
                table: "Interventions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Frais",
                table: "Interventions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeIntervention",
                table: "Interventions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interventions",
                table: "Interventions",
                column: "IdInterventions");

            migrationBuilder.CreateTable(
                name: "EquipementTypeInterventions",
                columns: table => new
                {
                    EquipementInterventionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkEquipement = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FkIntervention = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipementTypeInterventions", x => x.EquipementInterventionId);
                    table.ForeignKey(
                        name: "FK_EquipementTypeInterventions_Equipements_FkEquipement",
                        column: x => x.FkEquipement,
                        principalTable: "Equipements",
                        principalColumn: "EquipementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipementTypeInterventions_Interventions_FkIntervention",
                        column: x => x.FkIntervention,
                        principalTable: "Interventions",
                        principalColumn: "IdInterventions",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteCriterePrestataires",
                columns: table => new
                {
                    FkNoteCritere = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkPrestataire = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateNotePrestataire = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_EquipementTypeInterventions_FkEquipement",
                table: "EquipementTypeInterventions",
                column: "FkEquipement");

            migrationBuilder.CreateIndex(
                name: "IX_EquipementTypeInterventions_FkIntervention",
                table: "EquipementTypeInterventions",
                column: "FkIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCriterePrestataires_FkPrestataire",
                table: "NoteCriterePrestataires",
                column: "FkPrestataire");
        }
    }
}
