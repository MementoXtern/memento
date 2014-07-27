USE MementoDB;

CREATE TABLE EventItem (
EmployeeID INT,
EventID INT,
CustomItemID INT,
Qty INT,
CONSTRAINT EventItem_PK PRIMARY KEY (EmployeeID, EventID, CustomItemID),
CONSTRAINT EventItem_Employee_FK FOREIGN KEY (EmployeeID) REFERENCES dbo.Employee (EmployeeID),
CONSTRAINT EventItem_Event_FK FOREIGN KEY (EventID) REFERENCES dbo.[Event] (EventID),
CONSTRAINT EventItem_CustomItem_FK FOREIGN KEY (CustomItemID) REFERENCES dbo.CustomItem (CustomItemID));