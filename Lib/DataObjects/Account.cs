using Lib.BusinessObjects;
using System.Data;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects
{
    public class Account
    {
        /// <summary>
        /// Returns a loginObject if successful login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginObject CheckLogin(string username, string password)
        {
            LoginObject loginObject = null;
            DataTable dt = null;

            Query query = new Query(SqlQueryType.SqlStoredProc,"AccountCheckLogin");
            query.AddParameter("@Username", username);
            query.AddParameter("@Password", password);

            DBManager.Execute(query, ref dt);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                int accountId = (int)row["AccountID"];
                int accountTypeId = (int)row["AccountTypeID"];
                string landingUrl = row["AccountTypeLandingUrl"] as string;

                loginObject = new LoginObject { AccountId = accountId, AccountTypeId = accountTypeId, LandingUrl = landingUrl };
            }

            return loginObject;
        }

        /// <summary>
        /// Creates an account 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="accountTypeId"></param>
        /// <param name="accountUsername"></param>
        /// <param name="accountPassword"></param>
        /// <returns></returns>
        public static void Create(int accountId, int accountTypeId, string accountUsername, string accountPassword)
        {
            Query query = new Query(SqlQueryType.SqlStoredProc, "AccountSave");
            query.AddParameter("@AccountId", accountId);
            query.AddParameter("@AccountTypeId", accountTypeId);
            query.AddParameter("@AccountUsername", accountUsername);
            query.AddParameter("@AccountPassword", accountPassword);

            DBManager.Execute(query);
        }
    }
}
