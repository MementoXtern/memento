USE [MementoDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventGet] 
	@EventID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		E.EventID,
		E.EventTypeID,
		E.CompanyID,
		E.EventName
	FROM [Event] E
	WHERE E.EventID = @EventID;

	
END
