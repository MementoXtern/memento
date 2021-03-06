USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 09:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTypeSave] 
	@EventTypeID INT = NULL,
	@EventTypeName VARCHAR(50) = NULL,
	@EventTypeDesc VARCHAR(MAX) = NULL

AS
BEGIN

	SET NOCOUNT ON;

	IF @EventTypeID IS NULL
	BEGIN
		IF NOT EXISTS(SELECT EventTypeID FROM EventType WHERE EventTypeName = @EventTypeName AND EventTypeDesc = @EventTypeDesc)
		BEGIN
			INSERT INTO EventType(EventTypeName, EventTypeDesc)
			VALUES (@EventTypeName, @EventTypeDesc)
			
			SELECT @@IDENTITY
		END
	END
	ELSE
	BEGIN
		UPDATE EventType
		SET
			EventTypeName = @EventTypeName,
			EventTypeDesc = @EventTypeDesc
		WHERE EventTypeID = @EventTypeID
		
		SELECT @EventTypeID
	END
END
