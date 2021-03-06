USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[AccountCheckLogin]    Script Date: 07/27/2014 08:42:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorSave] 
	@VendorID INT = NULL,
	@VendorName VARCHAR(50) = NULL,
	@VendorAddress VARCHAR(50) = NULL,
	@VendorCity VARCHAR(50) = NULL,
	@VendorState VARCHAR(50) = NULL,
	@VendorZip VARCHAR(9) = NULL,
	@VendorPhone VARCHAR(10) = NULL,
	@VendorEmail VARCHAR(50) = NULL,
	@VendorContactName VARCHAR(100) = NULL

AS
BEGIN

	SET NOCOUNT ON;

	IF @VendorID IS NULL
	BEGIN
		IF NOT EXISTS(SELECT VendorID FROM Vendor WHERE VendorName = @VendorName AND VendorAddress = @VendorAddress)
		BEGIN
			INSERT INTO Vendor(VendorName, VendorAddress, VendorCity, VendorState, VendorZipCode, VendorPhone, VendorEmail, VendorContactName)
			VALUES (@VendorName, @VendorAddress, @VendorCity, @VendorState, @VendorZip, @VendorPhone, @VendorEmail, @VendorContactName)
			
			SELECT @@IDENTITY
		END
	END
	ELSE
	BEGIN
		UPDATE Vendor
		SET
			VendorName = @VendorName,
			VendorAddress = @VendorAddress,
			VendorCity = @VendorCity,
			VendorState = @VendorState,
			VendorZipCode = @VendorZip,
			VendorPhone = @VendorPhone,
			VendorEmail = @VendorEmail,
			VendorContactName = @VendorContactName
		WHERE VendorID = @VendorID
		
		SELECT @VendorID
	END
END
