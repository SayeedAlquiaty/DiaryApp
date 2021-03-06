﻿/*
Deployment script for DiaryAppDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DiaryAppDB"
:setvar DefaultFilePrefix "DiaryAppDB"
:setvar DefaultDataPath "c:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "c:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[diaryapp_tb].[School] (SqlSimpleColumn) will not be renamed to school_name';


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[schools_tb]...';


GO
CREATE TABLE [dbo].[schools_tb] (
    [school_id]            INT          NOT NULL,
    [school_name]   NVARCHAR (50) NOT NULL,
    [city_name]     NVARCHAR (20) NOT NULL,
    [province_name] NVARCHAR (20) NULL,
    [country_name]  NVARCHAR (20) NOT NULL,
	[address] NVARCHAR(50) NOT NULL, 
    [phone] NCHAR(15) NOT NULL,
	[date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL
    PRIMARY KEY CLUSTERED ([school_id] ASC)
);

GO
PRINT N'Creating [dbo].[subsciption_tb]...';


GO
CREATE TABLE [dbo].[subsciption_tb] (
	[subscription_id]   INT          NOT NULL,
    [school_id]     INT          NOT NULL,
	[subscriptiontype] NCHAR NOT NULL, 
    [date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL,
    PRIMARY KEY CLUSTERED ([subscription_id] ASC),
	CONSTRAINT [FK_subscription_tb_school_tb] FOREIGN KEY ([school_id]) REFERENCES [dbo].[schools_tb]([school_id]) 
);

GO
PRINT N'Creating [dbo].[user_tb]...';
GO
CREATE TABLE [dbo].[user_tb]
(
	[user_id] INT NOT NULL , 
    [school_id] INT NOT NULL, 
    [user_name] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [firstname] NVARCHAR(50) NOT NULL, 
    [surname] NVARCHAR(50) NOT NULL, 
    [type] NCHAR NOT NULL, 
    [phoneno] NCHAR(15) NOT NULL, 
    [mobileno] NCHAR(15) NULL, 
    [address] NVARCHAR(100) NULL, 
    [relation] NCHAR(15) NULL, 
    [remarks] NCHAR(10) NULL,
	[date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL,
	PRIMARY KEY CLUSTERED ([user_id] ASC),
	CONSTRAINT [FK_user_tb_school_tb] FOREIGN KEY ([school_id]) REFERENCES [dbo].[schools_tb]([school_id]) 
);

GO
PRINT N'Creating [dbo].[student_tb]...';
GO
CREATE TABLE [dbo].[student_tb]
(
	[student_id] INT NOT NULL,
	[user_id] INT NOT NULL , 
    [firstname] NVARCHAR(50) NOT NULL, 
    [surname] NVARCHAR(50) NOT NULL, 
    [rollno] INT NOT NULL,
	[class_id] INT NOT NULL,
	[school_id] INT NOT NULL, 
    [address] NVARCHAR(100) NULL, 
    [relation] NCHAR(15) NULL, 
    [remarks] NCHAR(10) NULL,
	[date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL,
	PRIMARY KEY CLUSTERED ([student_id] ASC),
	CONSTRAINT [FK_student_tb_user_tb] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user_tb]([user_id])  
);
GO
PRINT N'Creating [dbo].[class_tb]...';
GO
CREATE TABLE [dbo].[class_tb]
(
	[class_id] INT NOT NULL, 
    [class] INT NOT NULL, 
    [section] NCHAR(1) NOT NULL,
	[school_id] INT NOT NULL,
	[date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL,
	PRIMARY KEY CLUSTERED ([class_id] ASC),
	CONSTRAINT [FK_class_tb_schools_tb] FOREIGN KEY ([school_id]) REFERENCES [dbo].[schools_tb]([school_id])
);

GO
PRINT N'Creating [dbo].[diary_tb]...';
GO
CREATE TABLE [dbo].[diary_tb]
(
	[diaryno] NCHAR(10) NOT NULL,
	[student_id] INT NOT NULL,
	[note_id] INT NOT NULL,
	[date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL,
	PRIMARY KEY CLUSTERED ([diaryno] ASC),
	CONSTRAINT [FK_diary_tb_student_tb] FOREIGN KEY ([student_id]) REFERENCES [dbo].[student_tb]([student_id])
);

GO
PRINT N'Creating [dbo].[note_tb]...';
GO
CREATE TABLE [dbo].[note_tb]
(
	[user_id] INT NOT NULL, 
    [note_id] INT NOT NULL,
	[school_id] INT NOT NULL, 
    [notehealine] NVARCHAR(50) NULL,
	[date_created] DATE NOT NULL, 
    [date_deleted] DATE NULL,
	PRIMARY KEY CLUSTERED ([note_id] ASC),
	CONSTRAINT [FK_note_tb_schools_tb] FOREIGN KEY ([school_id]) REFERENCES [dbo].[schools_tb]([school_id])
);

GO
PRINT N'Creating [dbo].[notedata_tb]...';
GO
CREATE TABLE [dbo].[notedata_tb]
(
	[note_id] INT NOT NULL, 
    [notetext] NVARCHAR(MAX) NULL,
	[noteimage] IMAGE NULL, 
    [notemedia] VARBINARY(MAX) NULL,
	CONSTRAINT [FK_notedata_tb_note_tb] FOREIGN KEY ([note_id]) REFERENCES [dbo].[note_tb]([note_id])
);

GO
PRINT N'Creating [dbo].[remark_tb]...';
GO
CREATE TABLE [dbo].[remark_tb]
(
	[user_id] INT NOT NULL, 
    [remark_id] INT NOT NULL, 
    [note_id] INT NOT NULL,
	[date_created] DATETIME NOT NULL, 
    [date_deleted] DATETIME NULL,
	PRIMARY KEY CLUSTERED ([remark_id] ASC),
	CONSTRAINT [FK_remark_tb_note_tb] FOREIGN KEY ([note_id]) REFERENCES [dbo].[note_tb]([note_id])
);
GO
PRINT N'Creating [dbo].[remarkdata_tb]...';
GO
CREATE TABLE [dbo].[remarkdata_tb]
(
	[remark_id] INT NOT NULL, 
    [remarktext] NVARCHAR(MAX) NULL,
	[remarkimage] IMAGE NULL, 
    [remarkmedia] VARBINARY(MAX) NULL,
	CONSTRAINT [FK_remarkdata_tb_remark_tb] FOREIGN KEY ([remark_id]) REFERENCES [dbo].[remark_tb]([remark_id])
);



GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
PRINT N'Update complete.';


GO
