USE master
GO

IF DB_ID('Control') IS NOT NULL
BEGIN
	ALTER DATABASE [Control] SET RESTRICTED_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [Control]
END
GO

CREATE DATABASE [Control]
GO