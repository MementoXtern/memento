use MementoDB;


Create table Company 
(CompanyID INT IDENTITY(1,1),
CompanyName VARCHAR(50),
CompanyAddress VARCHAR(50),
CompanyCity VARCHAR(50),
CompanyState VARCHAR(2),
CompanyZip VARCHAR(9),
CompanyPhone VARCHAR(10),
CompanyEmail VARCHAR(50),
CompanyContactName VARCHAR(100),
CONSTRAINT Company_PK PRIMARY KEY (CompanyID));
