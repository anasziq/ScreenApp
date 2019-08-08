using Microsoft.EntityFrameworkCore.Migrations;

namespace ScreenProject.Migrations
{
    public partial class typePro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyType",
                table: "TemplatesFields",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "TemplatesFields");
        }
    }
}
