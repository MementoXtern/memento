USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[AccountCheckLogin]    Script Date: 07/26/2014 23:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AccountCheckLogin] 
	@Username VARCHAR(50), 
	@Password VARCHAR(15)

AS
BEGIN

	SET NOCOUNT ON;

	SELECT AT.AccountTypeID, AT.AccountTypeLandingUrl, A.AccountID
	FROM AccountType AT
	INNER JOIN Account A
	ON AT.AccountTypeID = A.AccountTypeID
	WHERE A.AccountUsername = @Username 
	AND A.AccountPassword = @Password;

	
END
