using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfAdvancedConfigSample.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence(
                name: "Sample",
                schema: "dbo",
                incrementBy: 20,
                cyclic: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Sample",
                schema: "dbo");
        }
    }
}
