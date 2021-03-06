USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[AccountCheckLogin]    Script Date: 07/27/2014 11:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PageCheckAccess] 
	@PageId INT, 
	@AccountTypeId INT

AS
BEGIN

	SET NOCOUNT ON;

	SELECT PageId
	FROM AcctTypePageAccess
	WHERE PageID = @PageId
	And AccountTypeID = @AccountTypeId
END
