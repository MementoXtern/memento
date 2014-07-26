using Lib.Utilities.DataAccess;
using System;
using System.Configuration;
using System.Data;

namespace Lib.Utilities
{
    public static class DBManager
    {
        #region Private Members
        
        // constants used for cryptography
        private const string CryptoKey = "UV/cwi0b5tXJKybuSVG9RriPjehn8k8RG+efOpcbLSs=";
        private const string CryptoIV = "gtavmugfYQqWydfYXnuXYQ==";

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Executes the query
        /// </summary>
        /// <param name="query"></param>
        public static void Execute(Query query)
        {
            VerifyQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            sqlClass.Execute(query);
        }

        /// <summary>
        /// Executes the query as a dataset
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dataSetObject"></param>
        public static void Execute(Query query, ref DataSet dataSetObject)
        {
            VerifyQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            dataSetObject = sqlClass.ExecuteAsDataSet(query);
        }

        /// <summary>
        /// Executes the query as a data table
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dataTableObject"></param>
        public static void Execute(Query query, ref DataTable dataTableObject)
        {
            VerifyQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            dataTableObject = sqlClass.ExecuteAsDataTable(query);
        }

        /// <summary>
        /// Executes a sql xml query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="xmlString"></param>
        public static void Execute(SqlXmlQuery query, ref string xmlString)
        {
            VerifySqlXmlQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            xmlString = sqlClass.ExecuteXml(query);
        }

        /// <summary>
        /// Executes the query as a scalar
        /// </summary>
        /// <param name="query"></param>
        /// <param name="returnId"></param>
        public static void ExecuteScalar(Query query, ref object returnId)
        {
            VerifyQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            returnId = sqlClass.ExecuteAsScalar(query);
        }

        /// <summary>
        /// Executes the query as a scalar
        /// </summary>
        /// <param name="query"></param>
        ///<param name="returnId></param>
        public static void ExecuteScalar(Query query, ref Guid returnId)
        {
            VerifyQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            returnId = (Guid)sqlClass.ExecuteAsScalar(query);
        }

        /// <summary>
        /// Executes the query as a scalar
        /// </summary>
        /// <param name="query"></param>
        /// <param name="returnInt"></param>
        public static void ExecuteScalar(Query query, ref int? returnInt)
        {
            VerifyQueryObject(query);
            ISqlQuery sqlClass = new SQLServer(GetConnectionString());
            returnInt = sqlClass.ExecuteAsInt(query);
        }

        #endregion

        #region Private Methods
        

        /// <summary>
        /// Decrypts the connection string
        /// </summary>
        /// <param name="dbConnectSting"></param>
        /// <returns></returns>
        private static string DecryptDBConnStr(string dbConnectString)
        {
            CryptoManager crypto = new CryptoManager(CryptoType.Rijndael, CryptoKey, CryptoIV);

            //decrypt the string
            crypto.Decrypt(ref dbConnectString);

            return dbConnectString;
        }

        /// <summary>
        /// Encrypes the connection string. One time use
        /// </summary>
        /// <param name="dbConnectSting"></param>
        /// <returns></returns>
        private static string EncryptDBConnStr(string dbConnectString)
        {
            CryptoManager crypto = new CryptoManager(CryptoType.Rijndael, CryptoKey, CryptoIV);

            crypto.Encrypt(ref dbConnectString);

            return dbConnectString;
        }

        /// <summary>
        /// Retrieves the appropriate connection string
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            //return DecryptDBConnStr(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        /// <summary>
        /// Parses the connection string for server connection info and puts them into the passed variables
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        /// <param name="initialCatalog"></param>
        private static void ParseConnectionString(string connectionString, ref string userID,
                                                  ref string password, ref string server,
                                                  ref string initialCatalog)
        {
            string[] connectStringArray = connectionString.Split(new Char[] { ';' });
            foreach (string temp in connectStringArray)
            {
                string[] tempArray = temp.Split(new char[] { '=' });
                switch (tempArray[0].ToLower())
                {
                    case "user id":
                        userID = tempArray[1];
                        break;
                    case "password":
                        password = tempArray[1];
                        break;
                    case "data source":
                        server = tempArray[1];
                        break;
                    case "initial catalog":
                        initialCatalog = tempArray[1];
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Verifies that the object passed into this method is a supported query class 
        /// </summary>
        /// <param name="query"></param>
        private static void VerifyQueryObject(object query)
        {
            if (!query.GetType().ToString().Equals("Lib.Utilities.DataAccess.Query"))
            {
                throw (new Exception("ERROR! Invalid Query object. Use the Lib.Utilities.DataAccess.Query object."));
            }
        }

        /// <summary>
        /// verifies tath the sqlxml query object passed into this method is a supported query class
        /// </summary>
        /// <param name="query"></param>
        private static void VerifySqlXmlQueryObject(object query)
        {
            if (!query.GetType().ToString().Equals("Lib.Utilities.DataAccess.SqlXmlQuery"))
            {
                throw (new Exception("ERROR! Invalid Sql Xml Query object. Use the Lib.Utilities.DataAccess.SqlXmlQuery object."));
            }
        }

        #endregion
    }
}
