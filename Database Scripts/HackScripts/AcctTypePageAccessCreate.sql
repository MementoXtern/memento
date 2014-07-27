USE MementoDB;

CREATE TABLE AcctTypePageAccess (
AccountTypeID INT,
PageID INT,
CONSTRAINT AcctTypePageAccess_PK PRIMARY KEY (AccountTypeID, PageID),
CONSTRAINT AcctTypePageAccess_AccountType_FK FOREIGN KEY (AccountTypeID) REFERENCES dbo.AccountType (AccountTypeID),
CONSTRAINT AcctTypePageAccess_Page_FK FOREIGN KEY (PageID) REFERENCES dbo.Page (PageID));