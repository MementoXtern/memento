USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 08:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AccountTypeSave] 
	@AccountTypeId INT = NULL,
	@AccountTypeName VARCHAR(50) = NULL,
	@AccountTypeDesc VARCHAR(MAX) = NULL,
	@AccountTypeLandingUrl VARCHAR(MAX) = NULL

AS
BEGIN

	SET NOCOUNT ON;

	IF @AccountTypeId IS NULL
	BEGIN
		IF NOT EXISTS(SELECT @AccountTypeId FROM AccountType WHERE AccountTypeName = @AccountTypeName
						AND AccountTypeDesc = @AccountTypeDesc AND AccountTypeLandingUrl = @AccountTypeLandingUrl)
		BEGIN
			INSERT INTO AccountType(AccountTypeName, AccountTypeDesc, AccountTypeLandingUrl)
			VALUES(@AccountTypeName, @AccountTypeDesc, @AccountTypeLandingUrl)
			
			SELECT @@IDENTITY
		END
	END
	ELSE
	BEGIN
		UPDATE AccountType
		SET
			AccountTypeName = @AccountTypeName,
			AccountTypeDesc = @AccountTypeDesc,
			AccountTypeLandingUrl = @AccountTypeLandingUrl
		WHERE AccountTypeId = @AccountTypeId
		
		SELECT @AccountTypeId
	END
END
