USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 09:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PageAddAccess] 
	@PageId INT,
	@AccountTypeId INT

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO AcctTypePageAccess(PageID, AccountTypeID)
	VALUES (@PageId, @AccountTypeId)
END
