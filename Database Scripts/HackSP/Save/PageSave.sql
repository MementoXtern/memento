USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 09:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PageSave] 
	@PageId INT = NULL,
	@PageName VARCHAR(50) = NULL,
	@PageUrl VARCHAR(MAX) = NULL

AS
BEGIN

	SET NOCOUNT ON;

	IF @PageId IS NULL
	BEGIN
		IF NOT EXISTS(SELECT PageID FROM Page WHERE PageName = @PageName AND PageUrl = @PageUrl)
		BEGIN
			INSERT INTO Page(PageName, PageUrl)
			VALUES(@PageName, @PageUrl)
			
			SELECT @@IDENTITY
		END
	END
	ELSE
	BEGIN
		UPDATE Page
		SET
			PageName = @PageName,
			PageUrl = @PageUrl
		WHERE PageID = @PageId
		
		SELECT @PageId
	END
END
