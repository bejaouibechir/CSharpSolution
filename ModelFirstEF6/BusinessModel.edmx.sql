
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2023 15:35:38
-- Generated from EDMX file: C:\Users\DELL\source\workspace\CSharpSolution\ModelFirstEF6\BusinessModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BusinessDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Produits'
CREATE TABLE [dbo].[Produits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Label] nvarchar(max)  NOT NULL,
    [Prix] decimal(18,0)  NOT NULL,
    [EmployeeId] int  NOT NULL,
    [CategorieId] int  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Salaire] decimal(18,0)  NOT NULL,
    [Recrutement] datetime  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Status] bit  NOT NULL,
    [Adresse] nvarchar(max)  NOT NULL,
    [Contact] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Label] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [PK_Produits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [FK_EmployeeProduit]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProduit'
CREATE INDEX [IX_FK_EmployeeProduit]
ON [dbo].[Produits]
    ([EmployeeId]);
GO

-- Creating foreign key on [CategorieId] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [FK_CategorieProduit]
    FOREIGN KEY ([CategorieId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategorieProduit'
CREATE INDEX [IX_FK_CategorieProduit]
ON [dbo].[Produits]
    ([CategorieId]);
GO

-- Creating foreign key on [ClientId] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [FK_ClientProduit]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientProduit'
CREATE INDEX [IX_FK_ClientProduit]
ON [dbo].[Produits]
    ([ClientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------