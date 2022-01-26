using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFQuerySample.Hir.Migrations
{
    public partial class includesample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type01s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type01s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type02s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type01Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type02s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type02s_Type01s_Type01Id",
                        column: x => x.Type01Id,
                        principalTable: "Type01s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Type03s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type02Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type03s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type03s_Type02s_Type02Id",
                        column: x => x.Type02Id,
                        principalTable: "Type02s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Type02s_Type01Id",
                table: "Type02s",
                column: "Type01Id");

            migrationBuilder.CreateIndex(
                name: "IX_Type03s_Type02Id",
                table: "Type03s",
                column: "Type02Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Type03s");

            migrationBuilder.DropTable(
                name: "Type02s");

            migrationBuilder.DropTable(
                name: "Type01s");
        }
    }
}
