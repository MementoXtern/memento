USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MementoItemCreate] 
	@VendorID INT,
	@ItemName VARCHAR(50),
	@CompanyID INT,
	@SpecialInstruction VARCHAR(MAX)
	
AS
BEGIN

	SET NOCOUNT ON;
	INSERT INTO CustomItem --(WRITE OUT THE SHIT BRO)
	VALUES (@VendorID, @ItemName, @CompanyID, @SpecialInstruction)
	SELECT @@IDENTITY

		
	
	
END