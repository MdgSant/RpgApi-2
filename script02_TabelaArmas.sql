BEGIN TRANSACTION;
DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_PERSONAGENS]') AND [c].[name] = N'Nome');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [TB_PERSONAGENS] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [TB_PERSONAGENS] ALTER COLUMN [Nome] varchar(200) NULL;

CREATE TABLE [TB_ARMAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_TB_ARMAS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] ON;
INSERT INTO [TB_ARMAS] ([Id], [Dano], [Nome])
VALUES (1, 10, 'Rabaddon'),
(2, 10, 'Rei destruido'),
(3, 10, 'Cutelo Negro'),
(4, 10, 'Mascara de Liandry'),
(5, 10, 'LeBron James'),
(6, 10, 'Faquinha de cortar pão'),
(7, 10, 'Chinelo de mãe');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250924003431_MigracaoArma', N'9.0.9');

COMMIT;
GO

