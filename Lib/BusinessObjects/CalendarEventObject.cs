using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.BusinessObjects
{
    public class CalendarEventObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string description { get; set; }
    }
}
