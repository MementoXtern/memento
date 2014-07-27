using System;
using System.Collections.Generic;
using Lib.BusinessObjects.Vendor;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects.Vendor
{
    public class CalendarEvent
    {

        /// <summary>
        /// Returns the events based on vendorId
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public static List<CalendarEventObject> GetCalendarEvents(int vendorId)
        {
            List<CalendarEventObject> calendarEvents = new List<CalendarEventObject>();

            //DataTable dt = null;
            //Query query = new Query();
            //query.AddParameter("@AccountTypeId", testId);
            //DBManager.Execute(query, ref dt);

            calendarEvents.Add(new CalendarEventObject { id = 1, title = "Huge Ass Boobs", start = DateTime.Now.ToString(), originCompany = "Blizzard, Inc", location = "Jail", item="Butt Plug", quantity= 17, isComplete = true });
            calendarEvents.Add(new CalendarEventObject { id = 2, title = "Like seriously, fucking huge", start = DateTime.Now.ToString(), originCompany = "PornHub Inc", location="Alterac Valley", item="Stolen Music", quantity=1092, isComplete = false });

            return calendarEvents;
        }

        public static void CompleteEvent(int eventId, bool complete)
        {
            //Query query = new Query(SqlQueryType.SqlStoredProc, "VendorCompleteEvent");
            //query.AddParameter("@EventID", eventId);
            //query.AddParameter("@Complete", complete);

            //DBManager.Execute(query);
        }
    }
}
