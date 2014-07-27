using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.BusinessObjects.Vendor
{
    public class CalendarEventObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string originCompany { get; set; }
        public string start { get; set; }
        public string location { get; set; }
        public string item { get; set; }
        public int quantity { get; set; }
        public bool isComplete { get; set; }
    }
}
