using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrologie.Data.Migrations
{
    public partial class tabInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EchelonDeVerification",
                table: "Equipements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "EchelonDeVerification",
                table: "Equipements",
                type: "real",
                nullable: true);
        }
    }
}
