IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210611233613_v1.0.0')
BEGIN
    CREATE TABLE [WorkersApsi] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [DocId] nvarchar(max) NOT NULL,
        [Job] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_WorkersApsi] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210611233613_v1.0.0')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210611233613_v1.0.0', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614141701_V1.5.0')
BEGIN
    CREATE TABLE [Login] (
        [Id] int NOT NULL IDENTITY,
        [User] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Mode] bit NOT NULL,
        CONSTRAINT [PK_Login] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614141701_V1.5.0')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210614141701_V1.5.0', N'5.0.7');
END;
GO

COMMIT;
GO

