USE MementoDB;

CREATE TABLE [Event] (
EventID INT IDENTITY(1,1),
EventTypeID INT,
CompanyID INT,
EventName VARCHAR(50),
CONSTRAINT Event_PK PRIMARY KEY (EventID),
CONSTRAINT Event_EventType_FK FOREIGN KEY (EventTypeID) REFERENCES dbo.EventType (EventTypeID),
CONSTRAINT Event_Company_FK FOREIGN KEY (CompanyID) REFERENCES dbo.Company (CompanyID),
); 