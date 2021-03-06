USE [MementoDB]
GO
/****** Object:  StoredProcedure [dbo].[VendorSave]    Script Date: 07/27/2014 09:08:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EmployeeSave] 
	@EmployeeId INT = NULL,
	@CompanyID INT,
	@EmployeeFName VARCHAR(50) = NULL,
	@EmployeeLName VARCHAR(50) = NULL,
	@EmployeeDOB DATE = NULL,
	@EmployeeStartDate DATE = NULL,
	@EmployeeShipAddress VARCHAR(50) = NULL,
	@EmployeeShipCity VARCHAR(50) = NULL,
	@EmployeeShipState VARCHAR(2) = NULL,
	@EmployeeShipZip VARCHAR(9) = NULL
AS
BEGIN

	SET NOCOUNT ON;

	IF @EmployeeId IS NULL
	BEGIN
		IF NOT EXISTS(SELECT EmployeeId FROM Employee WHERE CompanyID = @CompanyID AND EmployeeFName = @EmployeeFName
						AND EmployeeLName = @EmployeeLName AND EmployeeShipAddress = @EmployeeShipAddress)
		BEGIN
			INSERT INTO Employee(CompanyID, EmployeeFName, EmployeeLName, EmployeeDOB, EmployeeStartDate, EmployeeShipAddress,
				EmployeeShipCity, EmployeeShipState, EmployeeShipZip)
			VALUES(@CompanyID, @EmployeeFName, @EmployeeLName, @EmployeeDOB, @EmployeeStartDate, @EmployeeShipAddress,
				@EmployeeShipCity, @EmployeeShipState, @EmployeeShipZip)
		
			SELECT @@IDENTITY
		END
	END
	ELSE
	BEGIN
		UPDATE Employee
		SET
			CompanyID = @CompanyID,
			EmployeeFName = @EmployeeFName,
			EmployeeLName = @EmployeeLName,
			EmployeeDOB = @EmployeeDOB,
			EmployeeStartDate = @EmployeeStartDate,
			EmployeeShipAddress = @EmployeeShipAddress,
			EmployeeShipCity = @EmployeeShipCity,
			EmployeeShipState = @EmployeeShipState,
			EmployeeShipZip = @EmployeeShipZip
		WHERE EmployeeID = @EmployeeId
		
		SELECT @EmployeeId
	END
END
