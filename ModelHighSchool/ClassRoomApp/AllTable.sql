﻿/*
Deployment script for ModelHighSchool

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ModelHighSchool"
:setvar DefaultFilePrefix "ModelHighSchool"
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
PRINT N'Creating [dbo].[student_tb]...';


GO
CREATE TABLE [dbo].[school_tb] ( 
	[school_id] INT NOT NULL,
	[school_name] VARCHAR(50) NOT NULL,
	[school_cityname] VARCHAR(20) NOT NULL,
	[school_country] VARCHAR(20) NOT NULL,
	[school_date_created] DATE NOT NULL,
	[school_date_deleted] DATE NULL,
	PRIMARY KEY ([school_id] ASC));

GO
CREATE TABLE [dbo].[relationship_tb] (
    [relationship_id]           INT          NOT NULL UNIQUE,
    [relationship_name]         VARCHAR (10) NOT NULL,
    [relationship_remarks]      VARCHAR (45) NULL,
    [relationship_date_created] DATE         NOT NULL,
    [relationship_date_deleted] DATE         NULL,
    PRIMARY KEY CLUSTERED ([relationship_name] ASC)
);
GO
CREATE TABLE [dbo].[parent_tb] (
    [parent_id]                 INT          NOT NULL,
    [parent_father_firstname]   VARCHAR (45) NOT NULL,
    [parent_father_middlename]  VARCHAR (45) NULL,
    [parent_father_surname]     VARCHAR (45) NOT NULL,
    [parent_mother_firstname]   VARCHAR (45) NOT NULL,
    [parent_mother_middlename]  VARCHAR (45) NULL,
    [parent_mother_surname]     VARCHAR (45) NOT NULL,
    [parent_gardian_firstname]  VARCHAR (45) NULL,
    [parent_gardian_middlename] VARCHAR (45) NULL,
    [parent_gardian_lastname]   VARCHAR (45) NULL,
    [parent_phone]              VARCHAR (15) NOT NULL,
    [parent_mobile]             VARCHAR (15) NULL,
    [reationship_id]            INT          NOT NULL,
    [parent_date_created]       DATE         NOT NULL,
    [parent_date_deleted]       DATE         NULL,
    PRIMARY KEY CLUSTERED ([parent_father_firstname] ASC, [parent_phone] ASC),
    UNIQUE NONCLUSTERED ([parent_id] ASC)
);

GO
CREATE TABLE [dbo].[address_tb] (
    [address_id]           INT          NOT NULL,
    [address_line1]        VARCHAR (45) NOT NULL,
    [address_line2]        VARCHAR (45) NULL,
    [address_city]         VARCHAR (45) NOT NULL,
    [address_state]        VARCHAR (45) NOT NULL,
    [address_country]      VARCHAR (45) NOT NULL,
    [address_postalcode]   VARCHAR (15) NOT NULL,
    [parent_id]            INT          NOT NULL,
    [address_date_created] DATE         NOT NULL,
    [address_date_deleted] DATE         NULL,
    PRIMARY KEY CLUSTERED ([parent_id] ASC),
    UNIQUE NONCLUSTERED ([address_id] ASC)
);

GO
CREATE TABLE [dbo].[gender_tb](
[gender_id] INT NOT NULL,
[gender_name] VARCHAR(6) NOT NULL,
PRIMARY KEY ([gender_id] ASC)
);

GO
DROP TABLE [dbo].[student_tb];
CREATE TABLE [dbo].[student_tb] (
    [student_id]              INT           NOT NULL,
    [student_firstname]       VARCHAR (45)  NOT NULL,
    [student_middlename]      VARCHAR (45)  NULL,
    [student_surname]         VARCHAR (45)  NOT NULL,
    [student_dob]             DATE          NOT NULL,
    [parent_id]               INT           NOT NULL,
    [gender_id]               INT           NOT NULL,
    [student_date_of_join]    DATE          NULL,
    [student_date_created]    DATE          NOT NULL,
    [student_date_deleted]    DATE          NULL,
    PRIMARY KEY CLUSTERED ([parent_id] ASC, [student_firstname] ASC)
);

GO
CREATE TABLE  [dbo].[teacher_tb] (
  [teacher_id] INT NOT NULL ,
  [teacher_firstname] VARCHAR(45) NOT NULL,
  [teacher_middlename] VARCHAR(45) NULL,
  [teacher_surname] VARCHAR(45) NOT NULL,
  [teacher_email] VARCHAR(100) NOT NULL,
  [teacher_password] VARCHAR(45) NOT NULL,
  [teacher_dob] DATE NULL,
  [teacher_phone] VARCHAR(15) NOT NULL,
  [teacher_mobile] VARCHAR(15) NULL,
  [teacher_status] TINYINT NOT NULL,
  [teacher_last_login_date] DATE NOT NULL,
  [teacher_last_login_ip] VARCHAR(45) NULL,
  [teacher_date_created] DATE NOT NULL,
  [teacher_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([teacher_firstname] ASC, [teacher_phone] ASC),
  UNIQUE NONCLUSTERED ([teacher_id] ASC));

  GO
CREATE TABLE  [dbo].[classroom_tb] (
  [classroom_id] INT NOT NULL ,
  [classroom_year] VARCHAR(45) NOT NULL,
  [classroom_grade] VARCHAR(45) NOT NULL,
  [classroom_section] VARCHAR(45) NOT NULL,
  [classroom_status] TINYINT NOT NULL,
  [classroom_remarks] VARCHAR(100) NULL,
  [classroom_date_created] DATE NOT NULL,
  [classroom_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([classroom_year] ASC, [classroom_grade] ASC, [classroom_section] ASC),
  UNIQUE NONCLUSTERED ([classroom_id] ASC));

  GO
CREATE TABLE  [dbo].[classteacher_tb] (
  [classteacher_id] INT NOT NULL ,
  [classroom_id] INT NOT NULL,
  [teacher_id] INT NOT NULL,
  [classteacher_date_created] DATE NOT NULL,
  [classteacher_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([classroom_id] ASC, [teacher_id] ASC),
  UNIQUE NONCLUSTERED([classteacher_id]));

  GO
  DROP TABLE [dbo].[classroomstudent_tb];
  GO
CREATE TABLE  [dbo].[classroomstudent_tb] (
  [classroomstudent_id] INT NOT NULL ,
  [classroom_id] INT NOT NULL,
  [student_id] INT NOT NULL,
  [classroomstudent_rollno] INT NOT NULL,
  [classroomstudent_date_created] DATE NOT NULL,
  [classroomstudent_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([classroom_id] ASC, [student_id] ASC),
  UNIQUE NONCLUSTERED ([classroomstudent_id] ASC));

  GO
CREATE TABLE  [dbo].[attendance_tb] (
  [attendance_id] INT NOT NULL ,
  [attendance_date] DATE NOT NULL,
  [student_id] INT NOT NULL,
  [attendance_status] TINYINT NOT NULL,
  [attendance_remarks] VARCHAR(100) NULL,
  [attendance_date_created] DATE NOT NULL,
  [attendance_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([attendance_date] ASC, [student_id] ASC),
  UNIQUE NONCLUSTERED([attendance_id] ASC));

  GO
CREATE TABLE  [dbo].[studentdiary_tb] (
  [studentdiary_id] INT NOT NULL,
  [studentdiary_year] VARCHAR(10),
  [student_id] INT NOT NULL,
  [studentdiary_date] DATE NOT NULL,
  [diarynotes_id] INT NOT NULL,
  [studentdiary_statusl] TINYINT NOT NULL,
  [studentdiary_date_created] DATE NOT NULL,
  [studentdiary_date_deleted] DATE NULL,
  PRIMARY KEY ([studentdiary_year] ASC,[student_id] ASC),
  UNIQUE NONCLUSTERED([studentdiary_id] ASC)
  );

  GO
 DROP TABLE [dbo].[diarynotes_tb];
 CREATE TABLE [dbo].[diarynotes_tb] ( 
	[diarynotes_id] INT NOT NULL,
	[diarynotes_value] VARBINARY(MAX),
	[teacher_id] INT NOT NULL,
	[dairynotes_timestamp] DATETIME NOT NULL,
	[diarynotes_date_created] DATE NOT NULL,
	[diarynotes_date_deleted] DATE NULL,
	PRIMARY KEY CLUSTERED ([diarynotes_id] ASC));

  GO
CREATE TABLE  [dbo].[subjectcatagory_tb] (
  [subjectcatagory_id] INT NOT NULL ,
  [subjectcatagory_name] VARCHAR(45) NOT NULL,
  [subjectcatagory_date_created] DATE NOT NULL,
  [subjectcatagory_date_deleted] DATE NULL,
  PRIMARY KEY ([subjectcatagory_name] ASC),
  UNIQUE NONCLUSTERED([subjectcatagory_id] ASC))
;
GO
CREATE TABLE  [dbo].[subject_tb] (
  [subject_id] INT NOT NULL ,
  [subject_name] VARCHAR(45) NOT NULL,
  [subjectcatagory_id] INT NOT NULL,
  [subject_date_created] DATE NOT NULL,
  [subject_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([subjectcatagory_id] ASC, [subject_name] ASC),
  UNIQUE NONCLUSTERED ([subject_id] ASC))
;

GO
CREATE TABLE  [dbo].[faculty_tb] (
  [faculty_id] INT NOT NULL ,
  [subject_id] INT NOT NULL,
  [teacher_id] INT NOT NULL,
  [classroom_id] INT NOT NULL,
  [faculty_date_created] DATE NOT NULL,
  [faculty_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED ([classroom_id] ASC, [subject_id] ASC, [teacher_id] ASC),
  UNIQUE NONCLUSTERED ([faculty_id]))
;
GO
CREATE TABLE  [dbo].[examtype_tb] (
  [examtype_id] INT NOT NULL ,
  [examtype_name] VARCHAR(45) NOT NULL,
  [examtype_desc] VARCHAR(100) NULL,
  [examtype_date_created] DATE NOT NULL,
  [examtype_date_deleted] DATE NULL,
  PRIMARY KEY ([examtype_name] ASC),
  UNIQUE NONCLUSTERED ([examtype_id]))
;
GO
CREATE TABLE  [dbo].[exam_tb] (
  [exam_id] INT NOT NULL ,
  [examtype_id] INT NOT NULL,
  [exam_startdate] DATE NOT NULL,
  [exam_desc] VARCHAR(100) NULL,
  [exam_date_created] DATE NOT NULL,
  [exam_date_deleted] DATE NULL DEFAULT NULL,
  PRIMARY KEY CLUSTERED([examtype_id] ASC, [exam_startdate] ASC),
  UNIQUE NONCLUSTERED ([exam_id] ASC))
;
GO
CREATE TABLE  [dbo].[examresult_tb] (
  [examresult_id] INT NOT NULL ,
  [exam_id] INT NOT NULL,
  [student_id] INT NOT NULL,
  [subject_id] INT NOT NULL,
  [examresult_marks] INT NOT NULL,
  [examresult_grade] VARCHAR(2) NOT NULL,
  [examresult_desc] VARCHAR(45) NULL,
  [examresult_date_created] DATE NOT NULL,
  [examresult_date_deleted] DATE NULL,
  PRIMARY KEY CLUSTERED([exam_id] ASC, [subject_id] ASC, [student_id] ASC),
  UNIQUE NONCLUSTERED ([examresult_id] ASC))
;

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
