USE MementoDB;

CREATE TABLE Item (
ItemName VARCHAR(50),
ItemDesc VARCHAR (MAX),
ItemPrice DECIMAL(18,2),
ItemProcessingTime INT,
VendorID INT,
CONSTRAINT Item_PK PRIMARY KEY (ItemName,VendorID),
CONSTRAINT Item_FK FOREIGN KEY (VendorID) REFERENCES dbo.Vendor (VendorID));
