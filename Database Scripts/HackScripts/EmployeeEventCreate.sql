USE MementoDB;

CREATE TABLE EmployeeEvent (
EmployeeID INT,
EventID INT,
DeliveryDate DATE,
CONSTRAINT EmployeeEvent_PK PRIMARY KEY (EmployeeID, EventID),
CONSTRAINT EmployeeEvent_Employee_FK FOREIGN KEY (EmployeeID) REFERENCES dbo.Employee (EmployeeID),
CONSTRAINT EmployeeEvent_Event_FK FOREIGN KEY (EventID) REFERENCES dbo.Event (EventID));