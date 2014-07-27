USE [MementoDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EmployeeGet] 
	@EmployeeID INT

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		E.EmployeeID,
		E.CompanyID,
		E.EmployeeFName,
		E.EmployeeLName,
		E.EmployeeDOB,
		E.EmployeeStartDate,
		E.EmployeeShipAddress,
		E.EmployeeShipCity,
		E.EmployeeShipState,
		E.EmployeeShipZip
	FROM Employee E
	WHERE E.EmployeeID = @EmployeeID;

	
END