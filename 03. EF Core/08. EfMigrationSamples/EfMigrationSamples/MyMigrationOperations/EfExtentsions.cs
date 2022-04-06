
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

#nullable disable

namespace EfMigrationSamples.Migrations
{
    public static class EfExtentsions
    {
        public static OperationBuilder<SqlOperation> CreateUser(this MigrationBuilder migrationBuilder, string userName, string password)
        {


            return migrationBuilder.Sql($"Create User {userName} WITH PASSWORD {password}");
        }
    }
}
