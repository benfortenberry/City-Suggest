
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/05/2016 18:30:57
-- Generated from EDMX file: C:\Users\Ben\Documents\Visual Studio 2015\Projects\GG\GG\Models\GGModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_66141_finalwishes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VenueTag_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTag] DROP CONSTRAINT [FK_VenueTag_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTag] DROP CONSTRAINT [FK_VenueTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTime_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTime] DROP CONSTRAINT [FK_VenueTime_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueTime_Time]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueTime] DROP CONSTRAINT [FK_VenueTime_Time];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueType_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueType] DROP CONSTRAINT [FK_VenueType_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueType_Type]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenueType] DROP CONSTRAINT [FK_VenueType_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_VenuePrice_Venue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenuePrice] DROP CONSTRAINT [FK_VenuePrice_Venue];
GO
IF OBJECT_ID(N'[dbo].[FK_VenuePrice_Price]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VenuePrice] DROP CONSTRAINT [FK_VenuePrice_Price];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_VenueImage];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueVideo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Videos] DROP CONSTRAINT [FK_VenueVideo];
GO
IF OBJECT_ID(N'[dbo].[FK_VenueHours]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hours] DROP CONSTRAINT [FK_VenueHours];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Venues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Venues];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[Prices1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices1];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Times]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Times];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[Videos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Videos];
GO
IF OBJECT_ID(N'[dbo].[Hours]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hours];
GO
IF OBJECT_ID(N'[dbo].[FeatureImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeatureImages];
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
IF OBJECT_ID(N'[dbo].[VenuePrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VenuePrice];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Venues'
CREATE TABLE [dbo].[Venues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [State] nvarchar(max)  NULL,
    [Website] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [Zip] varchar(50)  NULL,
    [Instagram] varchar(250)  NULL,
    [Facebook] varchar(250)  NULL,
    [Twitter] varchar(250)  NULL,
    [Contact] varchar(250)  NULL,
    [Email] varchar(250)  NULL,
    [Neighborhood] varchar(250)  NULL,
    [Parking] varchar(50)  NULL,
    [Phone] varchar(50)  NULL,
    [Notes] varchar(max)  NULL
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
    [ImageData] varbinary(max)  NULL,
    [VenueId] int  NOT NULL,
    [url] varchar(max)  NULL
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

-- Creating table 'Videos'
CREATE TABLE [dbo].[Videos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VenueId] int  NOT NULL,
    [url] varchar(max)  NULL
);
GO

-- Creating table 'Hours'
CREATE TABLE [dbo].[Hours] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VenueId] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FeatureImages'
CREATE TABLE [dbo].[FeatureImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [PK_Videos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hours'
ALTER TABLE [dbo].[Hours]
ADD CONSTRAINT [PK_Hours]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeatureImages'
ALTER TABLE [dbo].[FeatureImages]
ADD CONSTRAINT [PK_FeatureImages]
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

-- Creating foreign key on [VenueId] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [FK_VenueVideo]
    FOREIGN KEY ([VenueId])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenueVideo'
CREATE INDEX [IX_FK_VenueVideo]
ON [dbo].[Videos]
    ([VenueId]);
GO

-- Creating foreign key on [VenueId] in table 'Hours'
ALTER TABLE [dbo].[Hours]
ADD CONSTRAINT [FK_VenueHours]
    FOREIGN KEY ([VenueId])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VenueHours'
CREATE INDEX [IX_FK_VenueHours]
ON [dbo].[Hours]
    ([VenueId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------