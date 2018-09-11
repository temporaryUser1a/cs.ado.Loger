-- event_type
-- event_date
-- machine_name
-- user_name
-- duration NULL

CREATE DATABASE Loger
ON
(
	NAME = Loger_dat,
	FILENAME = 'F:\C#\current\cs.ado.net.DbLoger\sql\loger.mdf'
)
LOG ON
(
	NAME = Loger_log,
	FILENAME = 'F:\C#\current\cs.ado.net.DbLoger\sql\loger.ldf'
);
GO

USE Loger;
GO

CREATE SCHEMA Main;
GO

CREATE SCHEMA Tools;
GO

-- event types table
CREATE TABLE Main.EventTypes (
	event_id int NOT NULL PRIMARY KEY IDENTITY,
	event_type nvarchar(128) NOT NULL UNIQUE
);
GO

-- inforamtion types table
CREATE TABLE Main.Info (
	record_id		int NOT NULL PRIMARY KEY IDENTITY,
	event_id		int FOREIGN KEY REFERENCES Main.EventTypes (event_id),
	event_date		datetime NOT NULL,
	machine_name	nvarchar(128) NOT NULL,
	user_name		nvarchar(256) NOT NULL,
	duration		int NULL
);
GO

-- default event types insert
INSERT INTO Main.EventTypes(event_type)
VALUES ('Login'), ('Logout');
GO

CREATE FUNCTION Tools.GetEventIdFromType (
	@event_type nvarchar(128)
)
RETURNS INT
BEGIN
	DECLARE @event_id int;
	SELECT
		@event_id = event_id
	FROM
		Main.EventTypes
	WHERE
		event_type = @event_type
	RETURN @event_id;
END

-- procedure for insert into Main.Info
CREATE PROCEDURE Main.AddToInfo (
	@event_type nvarchar(128),
	@event_date datetime,
	@machine_name nvarchar(128),
	@user_name nvarchar(256),
	@duration int
)
AS SET NOCOUNT ON
	DECLARE @event_id int = Tools.GetEventIdFromType (@event_type);
	INSERT INTO Main.Info (event_id, event_date, machine_name, user_name, duration)
	VALUES (@event_id, @event_date, @machine_name, @user_name, @duration);
GO