USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ItemDelete] 
	@ItemName VARCHAR(50),
	@VendorID INT,
	@CustomItemID INT,
	--@EmployeeID INT
	@EventID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	DELETE FROM EventItem
	WHERE EventItem.CustomItemID IN (
		SELECT CustomItemID
		FROM CustomItem
		WHERE ItemName = @ItemName
		AND VendorID = @VendorID)
		
	DELETE FROM CustomItem
	WHERE ItemName = @ItemName
	AND VendorID = @VendorID
	
	DELETE FROM Item
	WHERE ItemName = @ItemName
	AND VendorID = @VendorID
	
END