USE [MementoDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventItemDelete] 
	@EmployeeID INT,
	@EventID INT,
	@CustomItemID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	DELETE FROM EventItem
	WHERE EmployeeID = @EmployeeID
	AND EventID = @EventID
	AND CustomItemID = @CustomItemID;

	
END
