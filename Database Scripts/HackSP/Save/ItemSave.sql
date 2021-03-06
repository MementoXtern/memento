USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 09:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ItemSave] 
	@VendorID INT = NULL,
	@ItemName VARCHAR(50) = NULL,
	@ItemDesc VARCHAR(MAX) = Null,
	@ItemPrice DECIMAL(18,2) = NULL,
	@ItemProcessingTime INT = NULL

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Item(VendorID, ItemName, ItemDesc, ItemPrice, ItemProcessingTime)
	VALUES(@VendorID, @ItemName, @ItemDesc, @ItemPrice, @ItemProcessingTime)
END
