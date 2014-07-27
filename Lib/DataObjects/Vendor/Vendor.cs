using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects.Vendor
{
    public class Vendor
    {
        /// <summary>
        /// Creates a vendor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="contactName"></param>
        /// <returns></returns>
        public static int Create(string name, string address, string city, string state, string zip, string phone, string email, string contactName)
        {
            int? vendorId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "VendorSave");
            query.AddParameter("@VendorName", name);
            query.AddParameter("@VendorAddress", address);
            query.AddParameter("@VendorCity", city);
            query.AddParameter("@VendorState", state);
            query.AddParameter("@VendorZip", zip);
            query.AddParameter("@VendorPhone", phone);
            query.AddParameter("@VendorEmail", email);
            query.AddParameter("@VendorContactName", contactName);

            DBManager.ExecuteScalar(query, ref vendorId);

            return vendorId .Value;
        }
    }
}
