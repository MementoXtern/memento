USE MementoDB;

CREATE TABLE CustomItem (
CustomItemID INT IDENTITY(1,1),
VendorID INT,
ItemName VARCHAR(50),
CompanyID INT,
SpecialInstructions VARCHAR(MAX),
CONSTRAINT CustomItem_PK PRIMARY KEY (CustomItemID),
CONSTRAINT CustomItem_ItemName_FK FOREIGN KEY (ItemName, VendorID) REFERENCES dbo.Item (ItemName, VendorID),
CONSTRAINT CustomItem_Company_FK FOREIGN KEY (CompanyID) REFERENCES dbo.Company (CompanyID));