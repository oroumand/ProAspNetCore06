using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleEfConficurationSamples.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ef1");

            migrationBuilder.EnsureSchema(
                name: "ef2");

            migrationBuilder.CreateTable(
                name: "BackingFiledSample",
                schema: "ef1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherName = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackingFiledSample", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "ef1",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    customerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempIntWithStringValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "IndexUsingAttributes",
                schema: "ef1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexUsingAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndexUsingFluents",
                schema: "ef1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Filtered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexUsingFluents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                schema: "ef1",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    DeleteBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "ef1",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryKeyAttributes",
                schema: "ef1",
                columns: table => new
                {
                    MyPrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryKeyAttributes", x => x.MyPrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "primaryKeyFluents",
                schema: "ef1",
                columns: table => new
                {
                    Pk01 = table.Column<int>(type: "int", nullable: false),
                    Pk02 = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primaryKeyFluents", x => new { x.Pk01, x.Pk02 });
                });

            migrationBuilder.CreateTable(
                name: "ReadonlyAttributes",
                schema: "ef1",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReadonlyFluents",
                schema: "ef1",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_car",
                schema: "ef2",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_car", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_train",
                schema: "ef2",
                columns: table => new
                {
                    TrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_TrainName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_train", x => x.TrainId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "ef1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeAndNameWithAttributes",
                schema: "ef1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: false),
                    Code = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeAndNameWithAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAndNameWithFluent",
                schema: "ef1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAndNameWithFluent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_Name_Using_Attribute",
                schema: "ef1",
                table: "IndexUsingAttributes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndexUsingFluents_Name",
                schema: "ef1",
                table: "IndexUsingFluents",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackingFiledSample",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "IndexUsingAttributes",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "IndexUsingFluents",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "News",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "People",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "PrimaryKeyAttributes",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "primaryKeyFluents",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "ReadonlyAttributes",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "ReadonlyFluents",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "tbl_car",
                schema: "ef2");

            migrationBuilder.DropTable(
                name: "tbl_train",
                schema: "ef2");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "typeAndNameWithAttributes",
                schema: "ef1");

            migrationBuilder.DropTable(
                name: "TypeAndNameWithFluent",
                schema: "ef1");
        }
    }
}
