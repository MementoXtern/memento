using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects
{
    public class EventType
    {

        public static int Create(string eventTypeName, string eventTypeDesc)
        {
            int? eventTypeId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "EventTypeSave");
            query.AddParameter("@EventTypeName", eventTypeName);
            query.AddParameter("@EventTypeDesc", eventTypeDesc);

            DBManager.ExecuteScalar(query, ref eventTypeId);

            return eventTypeId.Value;
        }
    }
}
