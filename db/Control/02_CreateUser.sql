USE [Control]
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.sysusers WHERE name = 'usr_dbcontrol')
BEGIN
	DROP USER usr_dbcontrol
END
GO

USE [master]
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.syslogins WHERE name = 'lgn_dbcontrol')
BEGIN
	DROP LOGIN lgn_dbcontrol
END
GO

CREATE LOGIN lgn_dbcontrol WITH PASSWORD = 'lgn_dbcontrol', CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF
GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER [lgn_dbcontrol]
ALTER SERVER ROLE [securityadmin] ADD MEMBER [lgn_dbcontrol]
GO

USE [Control]
GO

CREATE USER usr_dbcontrol FOR LOGIN lgn_dbcontrol
GO