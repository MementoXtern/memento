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

            calendarEvents.Add(new CalendarEventObject { ID = 1, Title = "Huge Ass Boobs", Start = DateTime.Now.ToShortDateString() });
            calendarEvents.Add(new CalendarEventObject { ID = 2, Title = "Like seriously, fucking huge", Start = DateTime.Now.ToShortDateString() });

            return calendarEvents;
        }
    }
}
