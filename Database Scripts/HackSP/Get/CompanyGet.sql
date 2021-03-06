USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompanyGet] 
	@CompanyID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		C.CompanyID,
		C.CompanyName,
		C.CompanyAddress,
		C.CompanyCity,
		C.CompanyState,
		C.CompanyZip,
		C.CompanyEmail,
		C.CompanyPhone,
		C.CompanyContactName
	FROM Company C
	WHERE C.CompanyID = @CompanyID;

	
END
