
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2014 10:42:51
-- Generated from EDMX file: C:\DropBox\Cours iPhone\Session 6 Projet synthèse\projet_synthese\projet_synthese\projet_synthese\Data_synthese\Data_synthese\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OiseauCriOiseau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CriOiseau] DROP CONSTRAINT [FK_OiseauCriOiseau];
GO
IF OBJECT_ID(N'[dbo].[FK_OiseauObservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_OiseauObservation];
GO
IF OBJECT_ID(N'[dbo].[FK_OiseauPhoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photo] DROP CONSTRAINT [FK_OiseauPhoto];
GO
IF OBJECT_ID(N'[dbo].[FK_PhotoObservationObservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhotoObservationSet] DROP CONSTRAINT [FK_PhotoObservationObservation];
GO
IF OBJECT_ID(N'[dbo].[FK_SonObservationObservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SonObservationSet] DROP CONSTRAINT [FK_SonObservationObservation];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageUsagerUsager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_MessageUsagerUsager];
GO
IF OBJECT_ID(N'[dbo].[FK_ObservationMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_ObservationMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_AlertesUsagersAlerte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alerte] DROP CONSTRAINT [FK_AlertesUsagersAlerte];
GO
IF OBJECT_ID(N'[dbo].[FK_AlertesUsagersUsager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usager] DROP CONSTRAINT [FK_AlertesUsagersUsager];
GO
IF OBJECT_ID(N'[dbo].[FK_AlerteOiseau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alerte] DROP CONSTRAINT [FK_AlerteOiseau];
GO
IF OBJECT_ID(N'[dbo].[FK_Usager_Observation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Usager_Observation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CriOiseau]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CriOiseau];
GO
IF OBJECT_ID(N'[dbo].[Observation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Observation];
GO
IF OBJECT_ID(N'[dbo].[Oiseau]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Oiseau];
GO
IF OBJECT_ID(N'[dbo].[Photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photo];
GO
IF OBJECT_ID(N'[dbo].[usager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usager];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[Alerte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alerte];
GO
IF OBJECT_ID(N'[dbo].[PhotoObservationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhotoObservationSet];
GO
IF OBJECT_ID(N'[dbo].[SonObservationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SonObservationSet];
GO
IF OBJECT_ID(N'[dbo].[AlertesUsagersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlertesUsagersSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CriOiseau'
CREATE TABLE [dbo].[CriOiseau] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Son] longblob  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [IDOiseau] int  NOT NULL
);
GO

-- Creating table 'Observation'
CREATE TABLE [dbo].[Observation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateObservation] datetime  NOT NULL,
    [Position] int  NOT NULL,
    [IDUsager] int  NOT NULL,
    [IDOiseau] int  NOT NULL,
    [UsagerId] int  NOT NULL
);
GO

-- Creating table 'Oiseau'
CREATE TABLE [dbo].[Oiseau] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Espece] varchar(1000)  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [IDPhoto] int  NOT NULL
);
GO

-- Creating table 'Photo'
CREATE TABLE [dbo].[Photo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Image] longblob  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [IDOiseau] int  NOT NULL,
    [ImageMiniature] longblob  NOT NULL
);
GO

-- Creating table 'usager'
CREATE TABLE [dbo].[usager] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomUsager] varchar(20)  NOT NULL,
    [MotPasse] varchar(20)  NOT NULL,
    [Administrateur] bool  NOT NULL,
    [Courriel] varchar(1000)  NOT NULL,
    [AlertesUsagers_IDUsager] int  NOT NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Texte] varchar(1000)  NOT NULL,
    [DateHeure] datetime  NOT NULL,
    [IDUsager] int  NOT NULL,
    [IDObservation] int  NULL,
    [Usager_Id] int  NULL
);
GO

-- Creating table 'Alerte'
CREATE TABLE [dbo].[Alerte] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IDObservation] int  NOT NULL,
    [AlertesUsagers_IDUsager] int  NOT NULL,
    [Oiseau_Id] int  NOT NULL
);
GO

-- Creating table 'PhotoObservationSet'
CREATE TABLE [dbo].[PhotoObservationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Image] longblob  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [IDObservation] int  NOT NULL,
    [ImageMiniature] longblob  NOT NULL,
    [Commentaire] varchar(1000)  NOT NULL,
    [Observation_Id] int  NULL
);
GO

-- Creating table 'SonObservationSet'
CREATE TABLE [dbo].[SonObservationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Son] longblob  NOT NULL,
    [Description] varchar(1000)  NOT NULL,
    [IDObservation] int  NOT NULL,
    [Observation_Id] int  NOT NULL
);
GO

-- Creating table 'AlertesUsagersSet'
CREATE TABLE [dbo].[AlertesUsagersSet] (
    [IDUsager] int  NOT NULL,
    [IDAlerte] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CriOiseau'
ALTER TABLE [dbo].[CriOiseau]
ADD CONSTRAINT [PK_CriOiseau]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Observation'
ALTER TABLE [dbo].[Observation]
ADD CONSTRAINT [PK_Observation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Oiseau'
ALTER TABLE [dbo].[Oiseau]
ADD CONSTRAINT [PK_Oiseau]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Photo'
ALTER TABLE [dbo].[Photo]
ADD CONSTRAINT [PK_Photo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'usager'
ALTER TABLE [dbo].[usager]
ADD CONSTRAINT [PK_Usager]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Alerte'
ALTER TABLE [dbo].[Alerte]
ADD CONSTRAINT [PK_Alerte]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhotoObservationSet'
ALTER TABLE [dbo].[PhotoObservationSet]
ADD CONSTRAINT [PK_PhotoObservationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SonObservationSet'
ALTER TABLE [dbo].[SonObservationSet]
ADD CONSTRAINT [PK_SonObservationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IDUsager] in table 'AlertesUsagersSet'
ALTER TABLE [dbo].[AlertesUsagersSet]
ADD CONSTRAINT [PK_AlertesUsagersSet]
    PRIMARY KEY CLUSTERED ([IDUsager] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDOiseau] in table 'CriOiseau'
ALTER TABLE [dbo].[CriOiseau]
ADD CONSTRAINT [FK_OiseauCriOiseau]
    FOREIGN KEY ([IDOiseau])
    REFERENCES [dbo].[Oiseau]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OiseauCriOiseau'
CREATE INDEX [IX_FK_OiseauCriOiseau]
ON [dbo].[CriOiseau]
    ([IDOiseau]);
GO

-- Creating foreign key on [IDOiseau] in table 'Observation'
ALTER TABLE [dbo].[Observation]
ADD CONSTRAINT [FK_OiseauObservation]
    FOREIGN KEY ([IDOiseau])
    REFERENCES [dbo].[Oiseau]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OiseauObservation'
CREATE INDEX [IX_FK_OiseauObservation]
ON [dbo].[Observation]
    ([IDOiseau]);
GO

-- Creating foreign key on [IDOiseau] in table 'Photo'
ALTER TABLE [dbo].[Photo]
ADD CONSTRAINT [FK_OiseauPhoto]
    FOREIGN KEY ([IDOiseau])
    REFERENCES [dbo].[Oiseau]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OiseauPhoto'
CREATE INDEX [IX_FK_OiseauPhoto]
ON [dbo].[Photo]
    ([IDOiseau]);
GO

-- Creating foreign key on [Observation_Id] in table 'PhotoObservationSet'
ALTER TABLE [dbo].[PhotoObservationSet]
ADD CONSTRAINT [FK_PhotoObservationObservation]
    FOREIGN KEY ([Observation_Id])
    REFERENCES [dbo].[Observation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoObservationObservation'
CREATE INDEX [IX_FK_PhotoObservationObservation]
ON [dbo].[PhotoObservationSet]
    ([Observation_Id]);
GO

-- Creating foreign key on [Observation_Id] in table 'SonObservationSet'
ALTER TABLE [dbo].[SonObservationSet]
ADD CONSTRAINT [FK_SonObservationObservation]
    FOREIGN KEY ([Observation_Id])
    REFERENCES [dbo].[Observation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SonObservationObservation'
CREATE INDEX [IX_FK_SonObservationObservation]
ON [dbo].[SonObservationSet]
    ([Observation_Id]);
GO

-- Creating foreign key on [Usager_Id] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_MessageUsagerUsager]
    FOREIGN KEY ([Usager_Id])
    REFERENCES [dbo].[usager]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageUsagerUsager'
CREATE INDEX [IX_FK_MessageUsagerUsager]
ON [dbo].[Message]
    ([Usager_Id]);
GO

-- Creating foreign key on [IDObservation] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_ObservationMessage]
    FOREIGN KEY ([IDObservation])
    REFERENCES [dbo].[Observation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObservationMessage'
CREATE INDEX [IX_FK_ObservationMessage]
ON [dbo].[Message]
    ([IDObservation]);
GO

-- Creating foreign key on [AlertesUsagers_IDUsager] in table 'Alerte'
ALTER TABLE [dbo].[Alerte]
ADD CONSTRAINT [FK_AlertesUsagersAlerte]
    FOREIGN KEY ([AlertesUsagers_IDUsager])
    REFERENCES [dbo].[AlertesUsagersSet]
        ([IDUsager])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlertesUsagersAlerte'
CREATE INDEX [IX_FK_AlertesUsagersAlerte]
ON [dbo].[Alerte]
    ([AlertesUsagers_IDUsager]);
GO

-- Creating foreign key on [AlertesUsagers_IDUsager] in table 'usager'
ALTER TABLE [dbo].[usager]
ADD CONSTRAINT [FK_AlertesUsagersUsager]
    FOREIGN KEY ([AlertesUsagers_IDUsager])
    REFERENCES [dbo].[AlertesUsagersSet]
        ([IDUsager])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlertesUsagersUsager'
CREATE INDEX [IX_FK_AlertesUsagersUsager]
ON [dbo].[usager]
    ([AlertesUsagers_IDUsager]);
GO

-- Creating foreign key on [Oiseau_Id] in table 'Alerte'
ALTER TABLE [dbo].[Alerte]
ADD CONSTRAINT [FK_AlerteOiseau]
    FOREIGN KEY ([Oiseau_Id])
    REFERENCES [dbo].[Oiseau]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlerteOiseau'
CREATE INDEX [IX_FK_AlerteOiseau]
ON [dbo].[Alerte]
    ([Oiseau_Id]);
GO

-- Creating foreign key on [UsagerId] in table 'Observation'
ALTER TABLE [dbo].[Observation]
ADD CONSTRAINT [FK_Usager_Observation]
    FOREIGN KEY ([UsagerId])
    REFERENCES [dbo].[usager]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usager_Observation'
CREATE INDEX [IX_FK_Usager_Observation]
ON [dbo].[Observation]
    ([UsagerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------