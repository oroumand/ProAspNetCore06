using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelBindingSamples.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AAAId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_AAAId",
                table: "Category",
                column: "AAAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Temp_AAAId",
                table: "Category",
                column: "AAAId",
                principalTable: "Temp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Temp_AAAId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "Temp");

            migrationBuilder.DropIndex(
                name: "IX_Category_AAAId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "AAAId",
                table: "Category");
        }
    }
}
