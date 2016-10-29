-- Create tables and populate with seed data
--    follow naming convention: "Users" table contains rows that are each "User" objects

-- ***********  Attach ***********
CREATE DATABASE [Example] ON
PRIMARY (NAME=[Example], FILENAME='$(dbdir)\Example.mdf')
LOG ON (NAME=[Example_log], FILENAME='$(dbdir)\Example_log.ldf');
--FOR ATTACH;
GO

USE [Example];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Users','U') IS NOT NULL
	DROP TABLE [dbo].[Users];
GO


-- ########### Users ###########
CREATE TABLE [dbo].[Users] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NULL,
    [LastName]    NVARCHAR (MAX) NULL,
    [Date]        DATETIME       NULL,
    [PhoneNumber] VARCHAR(50)            NULL,
    [CatalogYear] VARCHAR(50)            NULL,
    [VNumber]     INT            NULL,
    [EMail]       VARCHAR (50)   NULL,
    [Major]       VARCHAR (50)   NULL,
    [Minor]       VARCHAR (50)   NULL,
    [Advisor]     VARCHAR (50)   NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);



-- ***********  Detach ***********
USE master;
GO

ALTER DATABASE [Example] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db 'Example', 'true'
