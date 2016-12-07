-- Create tables and populate with seed data
--    This version is customized for initializing the db on Azure
--    Seed data is in populate.sql

--USE [C:\USERS\RYANROTHWEILER\DOCUMENTS\CS460\FINAL\FINAL\APP_DATA\FINAL.MDF]
--GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Artist','U') IS NOT NULL
	DROP TABLE [dbo].[Artist];
GO

IF OBJECT_ID('dbo.ArtWork','U') IS NOT NULL
	DROP TABLE [dbo].[ArtWork];
GO

IF OBJECT_ID('dbo.Genre','U') IS NOT NULL
	DROP TABLE [dbo].[Genre];
GO

IF OBJECT_ID('dbo.Classification','U') IS NOT NULL
	DROP TABLE [dbo].[Classification];
GO

CREATE TABLE [dbo].[Artist]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[BirthCity] NVARCHAR (50) NOT NULL,
	[BirthDate] DATETIME2,
	CONSTRAINT [PK_dbo.Artist] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Artwork]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Title] NVARCHAR (50) NOT NULL,
	[ArtistID] INT NOT NULL,
	CONSTRAINT [FK_dbo.Artwork_dbo.Artist_ID] FOREIGN KEY ([ArtistID]) REFERENCES [dbo].[Artist] ([ID]),
	CONSTRAINT [PK_dbo.Artwork] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Genre]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Classification]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ArtworkID] INT NOT NULL,
	[GenreID] INT NOT NULL,
	CONSTRAINT [FK_dbo.Artwork_dbo.ArtWork_ID] FOREIGN KEY ([ArtworkID]) REFERENCES [dbo].[Artwork] ([ID]),
	CONSTRAINT [FK_dbo.Artwork_dbo.Genre_ID] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genre] ([ID]),
	CONSTRAINT [PK_dbo.Classification] PRIMARY KEY CLUSTERED ([ID] ASC)
);