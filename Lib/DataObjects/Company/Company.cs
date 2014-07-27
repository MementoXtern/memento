using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects.Company
{
    public class Company
    {
        /// <summary>
        /// Creates a company
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
            int? companyId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "CompanySave");
            query.AddParameter("@CompanyName", name);
            query.AddParameter("@CompanyAddress", address);
            query.AddParameter("@CompanyCity", city);
            query.AddParameter("@CompanyState", state);
            query.AddParameter("@CompanyZip", zip);
            query.AddParameter("@CompanyPhone", phone);
            query.AddParameter("@CompanyEmail", email);
            query.AddParameter("@companyContactName", contactName);

            DBManager.ExecuteScalar(query, ref companyId);

            return companyId.Value;
        }
    }
}
