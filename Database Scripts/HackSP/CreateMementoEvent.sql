USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MementoEventCreate] 
	@CompanyID INT,
	@EmployeeID INT,
	@EventTypeID INT,
	@EventName VARCHAR(50),
	@DeliveryDate DATE

AS
BEGIN

	SET NOCOUNT ON;
	DECLARE @EventID INT = NULL 
	INSERT INTO [Event] (EventTypeID, CompanyID, EventName)
	VALUES(@EventTypeID, @CompanyID, @EventName)
	
	SET @EventID = @@IDENTITY
	INSERT INTO EmployeeEvent
	VALUES (@EmployeeID, @EventID, @DeliveryDate)
		
	
	
END