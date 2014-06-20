
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/20/2014 11:51:38
-- Generated from EDMX file: C:\Users\jimrejnor\Desktop\MVCLibrary - StableV4\MVCLibrary.DAL\Models\LibraryModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MVCLibraryDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TownAuthor_Town]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TownAuthor] DROP CONSTRAINT [FK_TownAuthor_Town];
GO
IF OBJECT_ID(N'[dbo].[FK_TownAuthor_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TownAuthor] DROP CONSTRAINT [FK_TownAuthor_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_AuthorBook];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Towns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Towns];
GO
IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[TownAuthor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TownAuthor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Towns'
CREATE TABLE [dbo].[Towns] (
    [TownID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [AuthorID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [AuthorID] int  NOT NULL
);
GO

-- Creating table 'TownAuthor'
CREATE TABLE [dbo].[TownAuthor] (
    [Towns_TownID] int  NOT NULL,
    [Authors_AuthorID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TownID] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [PK_Towns]
    PRIMARY KEY CLUSTERED ([TownID] ASC);
GO

-- Creating primary key on [AuthorID] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([AuthorID] ASC);
GO

-- Creating primary key on [BookID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookID] ASC);
GO

-- Creating primary key on [Towns_TownID], [Authors_AuthorID] in table 'TownAuthor'
ALTER TABLE [dbo].[TownAuthor]
ADD CONSTRAINT [PK_TownAuthor]
    PRIMARY KEY NONCLUSTERED ([Towns_TownID], [Authors_AuthorID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Towns_TownID] in table 'TownAuthor'
ALTER TABLE [dbo].[TownAuthor]
ADD CONSTRAINT [FK_TownAuthor_Town]
    FOREIGN KEY ([Towns_TownID])
    REFERENCES [dbo].[Towns]
        ([TownID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authors_AuthorID] in table 'TownAuthor'
ALTER TABLE [dbo].[TownAuthor]
ADD CONSTRAINT [FK_TownAuthor_Author]
    FOREIGN KEY ([Authors_AuthorID])
    REFERENCES [dbo].[Authors]
        ([AuthorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TownAuthor_Author'
CREATE INDEX [IX_FK_TownAuthor_Author]
ON [dbo].[TownAuthor]
    ([Authors_AuthorID]);
GO

-- Creating foreign key on [AuthorID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_AuthorBook]
    FOREIGN KEY ([AuthorID])
    REFERENCES [dbo].[Authors]
        ([AuthorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorBook'
CREATE INDEX [IX_FK_AuthorBook]
ON [dbo].[Books]
    ([AuthorID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------