using Lib.BusinessObjects;

namespace Lib.DataObjects
{
    public class Account
    {
        /// <summary>
        /// Returns a loginObject if successful login
        /// </summary>
        /// <param name="accountTypeId"></param>
        /// <returns></returns>
        public static LoginObject CheckLogin(string email, string password)
        {
            LoginObject loginObject = null;

            //DataTable dt = null;
            //Query query = new Query();
            //query.AddParameter("@Email", email);
            //query.AddParameter("@Password", password);
            //DBManager.Execute(query, ref dt);

            loginObject = new LoginObject { AccountId = 1, AccountTypeId = 1, LandingUrl = "vendor/default.aspx" };
            return loginObject;
        }
    }
}
