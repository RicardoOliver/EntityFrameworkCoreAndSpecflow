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

CREATE TABLE [Clientes] (
    [ClienteId] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Telefone] nvarchar(20) NOT NULL,
    [Endereco] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([ClienteId])
);
GO

CREATE TABLE [Funcionarios] (
    [FuncionarioId] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Funcao] nvarchar(100) NOT NULL,
    [Telefone] nvarchar(20) NOT NULL,
    [Salario] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Funcionarios] PRIMARY KEY ([FuncionarioId])
);
GO

CREATE TABLE [Servicos] (
    [ServicoId] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Descricao] nvarchar(200) NOT NULL,
    [Preco] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY ([ServicoId])
);
GO

CREATE TABLE [Agendamentos] (
    [AgendamentoId] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [FuncionarioId] int NOT NULL,
    [ServicoId] int NOT NULL,
    [DataHora] datetime2 NOT NULL,
    CONSTRAINT [PK_Agendamentos] PRIMARY KEY ([AgendamentoId]),
    CONSTRAINT [FK_Agendamentos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([ClienteId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Agendamentos_Funcionarios_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [Funcionarios] ([FuncionarioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Agendamentos_Servicos_ServicoId] FOREIGN KEY ([ServicoId]) REFERENCES [Servicos] ([ServicoId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Agendamentos_ClienteId] ON [Agendamentos] ([ClienteId]);
GO

CREATE INDEX [IX_Agendamentos_FuncionarioId] ON [Agendamentos] ([FuncionarioId]);
GO

CREATE INDEX [IX_Agendamentos_ServicoId] ON [Agendamentos] ([ServicoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230605001134_CreateTableBarbearia', N'7.0.5');
GO

COMMIT;
GO

