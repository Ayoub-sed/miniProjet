using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrologie.Data.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Criteres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Criteres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
