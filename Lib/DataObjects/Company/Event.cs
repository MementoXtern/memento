using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects.Company
{
    public class Event
    {
        /// <summary>
        /// Creates an event
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="eventName"></param>
        /// <param name="eventTypeId"></param>
        /// <param name="employeeId"></param>
        /// <param name="allEmployees"></param>
        /// <returns></returns>
        public static int Create(int companyId, string eventName, int eventTypeId, int? employeeId, bool allEmployees = false)
        {
            int newEventId = 0;

            //DataTable dt = null;
            //Query query = new Query("AccountCheckLogin");
            //query.AddParameter("@Username", email);
            //query.AddParameter("@Password", password);
            //DBManager.Execute(query, ref dt);

            return newEventId;
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="eventId"></param>
        public static void Delete(int eventId)
        {
            //Query query = new Query("EventDelete");
            //query.AddParameter("@EventID", eventId);
            //DBManager.Execute(query);
        }

        /// <summary>
        /// Adds a custom item to an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="vendorId"></param>
        /// <param name="itemName"></param>
        /// <param name="companyId"></param>
        /// <param name="specialInstructions"></param>
        /// <returns></returns>
        public static int AddCustomItem(int eventId, int vendorId, string itemName, int companyId, string specialInstructions)
        {
            int newCustomItemId = 0;

            //DataTable dt = null;
            //Query query = new Query("CustomItemAdd");
            //query.AddParameter("@EventID", eventId);
            //query.AddParameter("@VendorID", vendorId);
            //query.AddParameter("@ItemName", itemName);
            //query.AddParameter("@CompanyID", companyId);
            //query.AddParameter("@SpecialInstructions", specialInstructions);
            //DBManager.Execute(query, ref dt);

            return newCustomItemId;
        }
    }
}
