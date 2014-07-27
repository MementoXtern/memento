USE [MementoDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EmployeeEventGet] 
	@EmployeeID INT,
	@EventID INT 

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		EE.EmployeeID,
		EE.EventID,
		EE.DeliveryDate
	FROM EmployeeEvent EE
	WHERE EE.EmployeeID = @EmployeeID
	and EE.EventID = @EventID;

	
END
