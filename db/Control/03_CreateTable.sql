USE [Control]
GO

IF OBJECT_ID('dbo.VersionsControl','U') IS NOT NULL
BEGIN
	DROP TABLE dbo.VersionsControl
END
GO

CREATE TABLE dbo.VersionsControl
(
	nuVersion		INT			NOT NULL,
	nmDatabase		SYSNAME		NOT NULL,
	user_execute	SYSNAME		NOT NULL,
	dateTimeExecute	DATETIME	NOT NULL,
	CONSTRAINT PKVersionsControl01 PRIMARY KEY(nuVersion, nmDatabase)
)
GO