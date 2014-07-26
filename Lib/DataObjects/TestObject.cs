using System;
using Lib.Utilities.DataAccess;
using Lib.Utilities;

namespace Lib.DataObjects
{
    public static class TestObject
    {
        #region Public Methods

        /// <summary>
        /// Deletes the specifed test 
        /// </summary>
        /// <param name="adminId"></param>
        public static void Delete(Guid testId)
        {
            Query query = new Query(SqlQueryType.SqlStoredProc, "TestDelete");
            query.AddParameter("@TestId", testId);

            DBManager.Execute(query);
        }

        /// <summary>
        /// Gets the specified test as string xml
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static string Get(Guid? testId)
        {
            string xml = string.Empty;

            SqlXmlQuery query = new SqlXmlQuery(SqlXmlQueryType.SqlXmlStoredProc, "TestGet");
            query.AddParameter("@TestId", testId);

            DBManager.Execute(query, ref xml);

            return xml;
        }

        /// <summary>
        /// Saves the specified test into the database
        /// </summary>
        /// <returns></returns>
        public static Guid Save(Guid? testId)
        {
            Guid returnId = Guid.Empty;

            Query query = new Query(SqlQueryType.SqlStoredProc, "TestSave");

            query.AddParameter("@TestId", testId);

            DBManager.ExecuteScalar(query, ref returnId);

            return returnId;
        }

        #endregion
    }
}
