
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/01/2015 20:01:48
-- Generated from EDMX file: C:\Users\Ben\Documents\Visual Studio 2015\Projects\GG\GG\Models\GGModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GG];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VenueImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_VenueImage];
GO
IF OBJECT_ID(N'[dbo].[FK_VenuePrice_Price]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenuePrice] DROP CONSTRAINT [FK_VenuePrice_Price];
GO
IF OBJECT_ID(N'[dbo].[FK_VenuePrice_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenuePrice] DROP CONSTRAINT [FK_VenuePrice_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTag] DROP CONSTRAINT [FK_VenueTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTag_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTag] DROP CONSTRAINT [FK_VenueTag_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTime_Time]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTime] DROP CONSTRAINT [FK_VenueTime_Time];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTime_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTime] DROP CONSTRAINT [FK_VenueTime_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueType_Type]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueType] DROP CONSTRAINT [FK_VenueType_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueType_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueType] DROP CONSTRAINT [FK_VenueType_Venue];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Prices1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices1];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[Times]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Times];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[VenuePrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VenuePrice];
GO
IF OBJECT_ID(N'[dbo].[Venues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Venues];
GO
IF OBJECT_ID(N'[dbo].[VenueTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VenueTag];
GO
IF OBJECT_ID(N'[dbo].[VenueTime]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VenueTime];
GO
IF OBJECT_ID(N'[dbo].[VenueType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VenueType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Venues'
CREATE TABLE [dbo].[Venues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Website] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Hours] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Prices1'
CREATE TABLE [dbo].[Prices1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [VenueId] int  NOT NULL
);
GO

-- Creating table 'Times'
CREATE TABLE [dbo].[Times] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VenueTag'
CREATE TABLE [dbo].[VenueTag] (
    [Venues_Id] int  NOT NULL,
    [Tags_Id] int  NOT NULL
);
GO

-- Creating table 'VenueTime'
CREATE TABLE [dbo].[VenueTime] (
    [Venues_Id] int  NOT NULL,
    [Times_Id] int  NOT NULL
);
GO

-- Creating table 'VenueType'
CREATE TABLE [dbo].[VenueType] (
    [Venues_Id] int  NOT NULL,
    [Types_Id] int  NOT NULL
);
GO

-- Creating table 'VenuePrice'
CREATE TABLE [dbo].[VenuePrice] (
    [Venues_Id] int  NOT NULL,
    [Prices_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Venues'
ALTER TABLE [dbo].[Venues]
ADD CONSTRAINT [PK_Venues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices1'
ALTER TABLE [dbo].[Prices1]
ADD CONSTRAINT [PK_Prices1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Times'
ALTER TABLE [dbo].[Times]
ADD CONSTRAINT [PK_Times]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Venues_Id], [Tags_Id] in table 'VenueTag'
ALTER TABLE [dbo].[VenueTag]
ADD CONSTRAINT [PK_VenueTag]
    PRIMARY KEY CLUSTERED ([Venues_Id], [Tags_Id] ASC);
GO

-- Creating primary key on [Venues_Id], [Times_Id] in table 'VenueTime'
ALTER TABLE [dbo].[VenueTime]
ADD CONSTRAINT [PK_VenueTime]
    PRIMARY KEY CLUSTERED ([Venues_Id], [Times_Id] ASC);
GO

-- Creating primary key on [Venues_Id], [Types_Id] in table 'VenueType'
ALTER TABLE [dbo].[VenueType]
ADD CONSTRAINT [PK_VenueType]
    PRIMARY KEY CLUSTERED ([Venues_Id], [Types_Id] ASC);
GO

-- Creating primary key on [Venues_Id], [Prices_Id] in table 'VenuePrice'
ALTER TABLE [dbo].[VenuePrice]
ADD CONSTRAINT [PK_VenuePrice]
    PRIMARY KEY CLUSTERED ([Venues_Id], [Prices_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Venues_Id] in table 'VenueTag'
ALTER TABLE [dbo].[VenueTag]
ADD CONSTRAINT [FK_VenueTag_Venue]
    FOREIGN KEY ([Venues_Id])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tags_Id] in table 'VenueTag'
ALTER TABLE [dbo].[VenueTag]
ADD CONSTRAINT [FK_VenueTag_Tag]
    FOREIGN KEY ([Tags_Id])
    REFERENCES [dbo].[Tags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenueTag_Tag'
CREATE INDEX [IX_FK_VenueTag_Tag]
ON [dbo].[VenueTag]
    ([Tags_Id]);
GO

-- Creating foreign key on [Venues_Id] in table 'VenueTime'
ALTER TABLE [dbo].[VenueTime]
ADD CONSTRAINT [FK_VenueTime_Venue]
    FOREIGN KEY ([Venues_Id])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Times_Id] in table 'VenueTime'
ALTER TABLE [dbo].[VenueTime]
ADD CONSTRAINT [FK_VenueTime_Time]
    FOREIGN KEY ([Times_Id])
    REFERENCES [dbo].[Times]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenueTime_Time'
CREATE INDEX [IX_FK_VenueTime_Time]
ON [dbo].[VenueTime]
    ([Times_Id]);
GO

-- Creating foreign key on [Venues_Id] in table 'VenueType'
ALTER TABLE [dbo].[VenueType]
ADD CONSTRAINT [FK_VenueType_Venue]
    FOREIGN KEY ([Venues_Id])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Types_Id] in table 'VenueType'
ALTER TABLE [dbo].[VenueType]
ADD CONSTRAINT [FK_VenueType_Type]
    FOREIGN KEY ([Types_Id])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenueType_Type'
CREATE INDEX [IX_FK_VenueType_Type]
ON [dbo].[VenueType]
    ([Types_Id]);
GO

-- Creating foreign key on [Venues_Id] in table 'VenuePrice'
ALTER TABLE [dbo].[VenuePrice]
ADD CONSTRAINT [FK_VenuePrice_Venue]
    FOREIGN KEY ([Venues_Id])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Prices_Id] in table 'VenuePrice'
ALTER TABLE [dbo].[VenuePrice]
ADD CONSTRAINT [FK_VenuePrice_Price]
    FOREIGN KEY ([Prices_Id])
    REFERENCES [dbo].[Prices1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenuePrice_Price'
CREATE INDEX [IX_FK_VenuePrice_Price]
ON [dbo].[VenuePrice]
    ([Prices_Id]);
GO

-- Creating foreign key on [VenueId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_VenueImage]
    FOREIGN KEY ([VenueId])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenueImage'
CREATE INDEX [IX_FK_VenueImage]
ON [dbo].[Images]
    ([VenueId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------