using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrologie.Data.Migrations
{
    public partial class Double : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Note",
                table: "NoteCriteres",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Note",
                table: "NoteCriteres",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
