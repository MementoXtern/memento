USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ItemGet] 
	@ItemName VARCHAR(50),
	@VendorID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		I.ItemName,
		I.VendorID,
		I.ItemDesc,
		I.ItemPrice,
		I.ItemProcessingTime
	FROM Item I
	WHERE I.ItemName = @ItemName
	and I.VendorID = @VendorID;

	
END