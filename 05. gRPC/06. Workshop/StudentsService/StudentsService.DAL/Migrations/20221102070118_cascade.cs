using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsService.DAL.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
