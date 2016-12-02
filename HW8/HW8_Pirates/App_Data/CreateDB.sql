-- Create tables and populate with seed data
--    This version is customized for initializing the db on Azure
--    Seed data is in populate.sql

CREATE DATABASE HW8
GO

USE [HW8]
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Pirate','U') IS NOT NULL
	DROP TABLE [dbo].[Pirate];
GO

IF OBJECT_ID('dbo.Ship','U') IS NOT NULL
	DROP TABLE [dbo].[Ship];
GO

IF OBJECT_ID('dbo.Crew','U') IS NOT NULL
	DROP TABLE [dbo].[Crew];
GO

CREATE TABLE [dbo].[Pirate]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[DateConscripted] DATETIME,
	CONSTRAINT [PK_dbo.Pirate] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Ship]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Type] NVARCHAR (100) NOT NULL,
	[tonnage] INT,
	CONSTRAINT [PK_dbo.Ship] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Crew]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[PirateID] INT NOT NULL,
	[ShipID] INT NOT NULL,
	[Booty] DECIMAL,
	CONSTRAINT [PK_dbo.Crew] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Crew_dbo.Pirate_ID] FOREIGN KEY ([PirateID]) REFERENCES [dbo].[Pirate] ([ID]),
	CONSTRAINT [FK_dbo.Crew_dbo.Ship_ID] FOREIGN KEY ([ShipID]) REFERENCES [dbo].[Ship] ([ID])
);