USE [MementoDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTypeGet] 
	@EventTypeID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		ET.EventTypeID,
		ET.EventTypeName,
		ET.EventTypeDesc
	FROM EventType ET
	WHERE ET.EventTypeID = @EventTypeID;

	
END
