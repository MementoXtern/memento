using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects
{
    public class AccountType
    {
        /// <summary>
        /// Creates an Account Type Object
        /// </summary>
        /// <param name="accountTypeName"></param>
        /// <param name="accountTypeDesc"></param>
        /// <param name="landingUrl"></param>
        /// <returns></returns>
        public static int Create(string accountTypeName, string accountTypeDesc, string landingUrl)
        {
            int? accountTypeId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "AccountTypeSave");
            query.AddParameter("@AccountTypeName", accountTypeName);
            query.AddParameter("@AccountTypeDesc", accountTypeDesc);
            query.AddParameter("@AccountTypeLandingUrl", landingUrl);

            DBManager.ExecuteScalar(query, ref accountTypeId);

            return accountTypeId.Value;
        }
    }
}
