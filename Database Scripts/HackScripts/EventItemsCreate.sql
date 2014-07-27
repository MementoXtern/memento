USE MementoDB;

CREATE TABLE EventItems (
EventTypeID INT,
ItemID INT,
TaskID INT,
Qty INT,
CONSTRAINT EventItems_PK PRIMARY KEY (EventTypeID, ItemID, TaskID),
CONSTRAINT EventItems_EventType_FK FOREIGN KEY (EventTypeID) REFERENCES dbo.EventType (EventTypeID),
CONSTRAINT EventItems_Item_FK FOREIGN KEY (ItemID) REFERENCES dbo.Item (ItemID),
CONSTRAINT EventItems_Task_FK FOREIGN KEY (TaskID) REFERENCES dbo.Task (TaskID)); 