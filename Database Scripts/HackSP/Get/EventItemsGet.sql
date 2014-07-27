USE [MementoDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventItemGet] 
	@EmployeeID INT,
	@EventID INT,
	@CustomItemID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		EI.EmployeeID,
		EI.EventID,
		EI.CustomItemID,
		EI.Qty
	FROM EventItem EI
	WHERE EI.EmployeeID = @EmployeeID
	AND EI.EventID = @EventID
	AND EI.CustomItemID = @CustomItemID;

	
END
