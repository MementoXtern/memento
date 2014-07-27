using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Lib.DataObjects;
using System.Web.Script.Serialization;

namespace WebApp.webservice
{
    /// <summary>
    /// Summary description for webservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class webservice : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetEvents()
        {
            var calendarEvents = CalendarEvent.GetCalendarEvents(0);

            var json = new JavaScriptSerializer().Serialize(calendarEvents);

            return json;
        }
    }
}
