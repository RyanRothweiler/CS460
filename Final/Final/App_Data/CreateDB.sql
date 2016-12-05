-- Create tables and populate with seed data
--    This version is customized for initializing the db on Azure
--    Seed data is in populate.sql

USE [HW9Database]
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.TestTable','U') IS NOT NULL
	DROP TABLE [dbo].[TestTable];
GO

CREATE TABLE [dbo].[TestTable]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[DateConscripted] DATETIME,
	CONSTRAINT [PK_dbo.TestTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);