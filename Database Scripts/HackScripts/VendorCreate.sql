USE MementoDB;

CREATE TABLE Vendor(
VendorID INT IDENTITY(1,1),
VendorName VARCHAR(50),
VendorAddress VARCHAR(50),
VendorCity VARCHAR(50),
VendorState VARCHAR(2),
VendorZipCode VARCHAR(9),
VendorPhone VARCHAR(10),
VendorEmail VARCHAR(50),
VendorContactName VARCHAR(100),
CONSTRAINT Vendor_PK PRIMARY KEY (VendorID));