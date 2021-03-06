USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 08:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AccountSave] 
	@AccountId INT,
	@AccountTypeId INT,
	@AccountUsername VARCHAR(50),
	@AccountPassword VARCHAR(15)

AS
BEGIN

	SET NOCOUNT ON;
	
	IF NOT EXISTS(SELECT AccountID FROM Account WHERE AccountUsername = @AccountUsername AND AccountPassword = @AccountPassword)
	BEGIN
		INSERT INTO Account(AccountID, AccountTypeID, AccountUsername, AccountPassword)
		VALUES(@AccountId, @AccountTypeId, @AccountUsername, @AccountPassword)
	END
END
