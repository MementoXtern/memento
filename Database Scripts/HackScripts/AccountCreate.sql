USE MementoDB;

CREATE TABLE Account (
AccountID INT,
AccountTypeID INT,
AccountUsername VARCHAR(50),
AccountPassword VARCHAR(15),
CONSTRAINT Account_PK PRIMARY KEY (AccountID, AccountTypeID),
CONSTRAINT Account_FK FOREIGN KEY (AccountTypeID) REFERENCES dbo.AccountType (AccountTypeID));