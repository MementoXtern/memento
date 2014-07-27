USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MementoEventItemCreate] 

	@EmployeeID INT,
	@EventID INT,
	@CustomItemID INT,
	@Qty INT


AS
BEGIN

	SET NOCOUNT ON;
	

	
	INSERT INTO EventItem --(WRITE SHIT OUT BRO)
	VALUES (@EmployeeID, @EventID, @CustomItemID, @Qty)
		
	
	
END