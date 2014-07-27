using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects
{
    public class Page
    {
        /// <summary>
        /// Creates a new page  
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static int Create(string pageName, string pageUrl)
        {
            int? pageId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "PageSave");
            query.AddParameter("@PageName", pageName);
            query.AddParameter("@PageUrl", pageUrl);

            DBManager.ExecuteScalar(query, ref pageId);

            return pageId.Value;
        }

        /// <summary>
        /// Creates a new page  
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static bool CheckAccess(int pageId, int accountTypeId)
        {
            int? newPageId = null;

            Query query = new Query(SqlQueryType.SqlStoredProc, "PageCheckAccess");
            query.AddParameter("@PageId", pageId);
            query.AddParameter("@AccountTypeId", accountTypeId);

            DBManager.ExecuteScalar(query, ref newPageId);

            return newPageId.HasValue;
        }

        /// <summary>
        /// Adds page access to the specified account type
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="accountTypeId"></param>
        public static void AddAccountTypeAccess(int pageId, int accountTypeId)
        {
            Query query = new Query(SqlQueryType.SqlStoredProc, "PageAddAccess");
            query.AddParameter("@PageId", pageId);
            query.AddParameter("@AccountTypeId", accountTypeId);

            DBManager.Execute(query);
        }
    }
}
