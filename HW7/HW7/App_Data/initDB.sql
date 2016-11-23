-- Create tables and populate with seed data
--    follow naming convention: "Users" table contains rows that are each "User" objects

-- ***********  Attach ***********
CREATE DATABASE [HW7] ON
PRIMARY (NAME=[HW7], FILENAME='$(dbdir)\HW7.mdf')
LOG ON (NAME=[HW7_log], FILENAME='$(dbdir)\HW7_log.ldf');
--FOR ATTACH;
GO

USE [HW7];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Request','U') IS NOT NULL
	DROP TABLE [dbo].[Request];
GO


-- ########### Users ###########
CREATE TABLE [dbo].[Request] (
    [ID] INT IDENTITY (1, 1) NOT NULL,
    [RequestType] NVARCHAR (MAX) NULL,
    [SourceIP] NVARCHAR (MAX) NULL,
    [BrowserType] NVARCHAR (MAX) NULL,
    [Date] DATETIME NULL,

    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);



-- ***********  Detach ***********
USE master;
GO

ALTER DATABASE [HW7] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db 'HW7', 'true'
