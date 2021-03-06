USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 08:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompanySave] 
	@CompanyId INT = NULL,
	@CompanyName VARCHAR(50) = NULL,
	@CompanyAddress VARCHAR(50) = NULL,
	@CompanyCity VARCHAR(50) = NULL,
	@CompanyState VARCHAR(2) = NULL,
	@CompanyZip VARCHAR(9) = NULL,
	@CompanyPhone VARCHAR(10) = NULL,
	@CompanyEmail VARCHAR(50) = NULL,
	@CompanyContactName VARCHAR(100) = NULL

AS
BEGIN

	SET NOCOUNT ON;

	IF @CompanyId IS NULL
	BEGIN
		IF NOT EXISTS(Select CompanyID FROM Company WHERE CompanyName = @CompanyName AND CompanyAddress = @CompanyAddress)
		BEGIN
			INSERT INTO Company(CompanyName, CompanyAddress, CompanyCity, CompanyState, CompanyZip, CompanyPhone, CompanyEmail, CompanyContactName)
			VALUES (@CompanyName, @CompanyAddress, @CompanyCity, @CompanyState, @CompanyZip, @CompanyPhone, @CompanyEmail, @CompanyContactName)
		
			SELECT @@IDENTITY
		END
	END
	ELSE
	BEGIN
		UPDATE Company
		SET
			CompanyName = @CompanyName,
			CompanyAddress = @CompanyAddress,
			CompanyCity = @CompanyCity,
			CompanyState = @CompanyState,
			CompanyZip = @CompanyZip,
			CompanyPhone = @CompanyPhone,
			CompanyEmail = @CompanyEmail,
			CompanyContactName = @CompanyContactName
		WHERE CompanyID = @CompanyId
		
		SELECT @CompanyId
	END
END
