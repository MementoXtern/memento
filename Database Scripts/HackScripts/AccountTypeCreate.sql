USE MementoDB;

CREATE TABLE AccountType (
AccountTypeID INT IDENTITY(1,1),
AccountTypeName VARCHAR(50),
AccountTypeDesc VARCHAR(MAX),
AccountTypeLandingUrl VARCHAR(MAX),
CONSTRAINT AccountType_PK PRIMARY KEY (AccountTypeID));

