using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfMigrationSamples.MyMigrationOperations;

public class CreateUserOperation:MigrationOperation
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public static class EFExtention
{
    public static OperationBuilder<CreateUserOperation> CreateUser2(this MigrationBuilder builder, string userName, string password)
    {
        var operation = new CreateUserOperation
        {
            UserName = userName,
            Password = password
        };
        builder.Operations.Add(operation);
        return new OperationBuilder<CreateUserOperation>(operation);
    }
}

public class MySqlMigrationGenerator : SqlServerMigrationsSqlGenerator
{
    public MySqlMigrationGenerator([NotNullAttribute] MigrationsSqlGeneratorDependencies dependencies, [NotNullAttribute] IRelationalAnnotationProvider migrationsAnnotations) : base(dependencies, migrationsAnnotations)
    {
    }

    protected override void Generate(MigrationOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        if (operation is CreateUserOperation createUserOperation)
        {

        }
        else
        {
            base.Generate(operation, model, builder);
        }
    }

}
