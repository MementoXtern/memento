USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorGet]    Script Date: 07/26/2014 23:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorGet] 
	@VendorID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		V.VendorID, 
		V.VendorName, 
		V.VendorAddress, 
		V.VendorCity, 
		V.VendorState, 
		V.VendorZipCode, 
		V.VendorPhone,
		V.VendorEmail,
		V.VendorContactName
	FROM Vendor V
	WHERE V.VendorID = @VendorID;

	
END
