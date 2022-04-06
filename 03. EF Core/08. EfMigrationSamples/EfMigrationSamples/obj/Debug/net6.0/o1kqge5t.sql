BEGIN TRANSACTION;
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [ISBN] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220406123728_Books', N'6.0.3');
GO

COMMIT;
GO

