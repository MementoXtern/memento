USE MementoDB;

CREATE TABLE Employee(
EmployeeID INT IDENTITY(1,1),
EmployeeFName VARCHAR(50),
EmployeeLName VARCHAR(50),
EmployeeDOB DATE,
EmployeeStartDate DATE,
EmployeeShipAddress VARCHAR(50),
EmployeeShipCity VARCHAR(50),
EmployeeShipState VARCHAR(2),
EmployeeShipZip VARCHAR(9),
CompanyID INT,
CONSTRAINT Employee_PK PRIMARY KEY (EmployeeID),
CONSTRAINT Employee_FK FOREIGN KEY (CompanyID) REFERENCES dbo.Company (CompanyID));