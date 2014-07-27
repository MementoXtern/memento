using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Lib.DataObjects;
using Lib.DataObjects.Company;
using Lib.DataObjects.Vendor;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            int vendorTypeId = 1;
            int companyTypeId = 2;
            int companyId = 1;
            int vendorId = 1;
            int vendorHomePageId = 1;
            int companyHomePageId = 2;

            // Create Company & Vendor
            try
            {
                vendorId = Vendor.Create("Cupcake Shop", "Cupcake lane", "Cupcake City", "FL", null, null, null, null);
            }
            catch { }

            try
            {
                companyId = Company.Create("Blizzard INC", "Your mom 123", null, null, null, null, null, null);
            }
            catch { }

            // Create Account Types
            try
            {
                vendorTypeId = AccountType.Create("Vendor", "Account for a vendor", "vendor/home.aspx");
            }
            catch { }

            try
            {
                companyTypeId = AccountType.Create("Company", "Account for a company", "company/home.aspx");
            }
            catch { }

            // Create Accounts
            try
            {
                Account.Create(vendorId, vendorTypeId, "vendor", "password");
            }
            catch { }

            try
            {
                Account.Create(companyId, companyTypeId, "company", "password");
            }
            catch { }

            // Pages
            try
            {
                vendorHomePageId = Page.Create("Vendor Home", "vendor/home.aspx");
            }
            catch { }

            try
            {
                companyHomePageId = Page.Create("Company Home", "company/home.aspx");
            }
            catch { }

            // Page Access
            try
            {
                Page.AddAccountTypeAccess(vendorHomePageId, vendorTypeId);
            }
            catch { }

            try
            {
                Page.AddAccountTypeAccess(companyHomePageId, companyTypeId);
            }
            catch { }

            // Items
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Item.Create(vendorId, "Cupcake-" + i, "Cupcake Description - " + i, (decimal)(10.00 * (i + 1.2)), 500 + i * 1000);
                }
                catch { }
            }

            // Employees
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    DateTime DOB = DateTime.Parse("02/03/1990");
                    DateTime startDate = DateTime.Parse("05/20/2006");

                    Employee.Create(companyId, "Empl Name - " + i, "Depp", DOB.AddDays(i * 3), startDate.AddDays(i * 2), "123 Mom blvd", "Shit uh.. no", "OH", "40922");
                }
                catch { }
            }

            // Event Type
            try
            {
                EventType.Create("Birthday", "Event for employee's birthdays");
            }
            catch { }

            try
            {
                EventType.Create("Anniversary", "Employee work anniversary");
            }
            catch { }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
