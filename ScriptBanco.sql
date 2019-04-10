IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Autores] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Sobrenome] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Autores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(200) NOT NULL,
    [Senha] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Livros] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(150) NOT NULL,
    [NumeroDePaginas] int NOT NULL,
    [Edicao] int NOT NULL,
    [Ano] datetime2 NOT NULL,
    [Descricao] nvarchar(4000) NULL,
    [AutorId] int NOT NULL,
    CONSTRAINT [PK_Livros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Livros_Autores_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [Autores] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Livros_AutorId] ON [Livros] ([AutorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190410123517_CriacaoDoBancoLivraria', N'2.2.3-servicing-35854');

GO

