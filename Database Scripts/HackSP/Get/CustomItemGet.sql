USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustomItemGet] 
	@CustomItemID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		CI.CustomItemID,
		CI.VendorID,
		CI.ItemName,
		CI.CompanyID,
		CI.SpecialInstructions		
	FROM CustomItem CI
	WHERE CI.CustomItemID = @CustomItemID;

	
END