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
