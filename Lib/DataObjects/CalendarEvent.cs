using System.Collections.Generic;
using Lib.BusinessObjects;
using System;

namespace Lib.DataObjects
{
    public class CalendarEvent
    {

        /// <summary>
        /// Returns the events based on account type id
        /// </summary>
        /// <param name="accountTypeId"></param>
        /// <returns></returns>
        public static List<CalendarEventObject> GetCalendarEvents(int accountTypeId)
        {
            List<CalendarEventObject> calendarEvents = new List<CalendarEventObject>();

            //DataTable dt = null;
            //Query query = new Query();
            //query.AddParameter("@AccountTypeId", testId);
            //DBManager.Execute(query, ref dt);

            calendarEvents.Add(new CalendarEventObject { id = 1, title = "Huge Ass Boobs", start = DateTime.Now.ToShortDateString(), description = "Blow me" });
            calendarEvents.Add(new CalendarEventObject { id = 2, title = "Like seriously, fucking huge", start = DateTime.Now.ToShortDateString(), description = "Seriously, blow me" });

            return calendarEvents;
        }
    }
}
