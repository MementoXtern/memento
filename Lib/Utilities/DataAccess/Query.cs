namespace Lib.Utilities.DataAccess
{
    // enumeration specifing supported query types
    public enum SqlQueryType { Sql, SqlStoredProc }

    // enumeration of supported database types
    public enum DatabaseTypes { SQLServer }

    public class Query
    {
        #region Private Members
        
        // Instance of the Parameters class to store a collection of parameters
        //  that are to be executed with this query class
        private Parameters mParameterCollection;
        private DatabaseTypes mDbType;
        private SqlQueryType mQueryType;
        private string mQueryString;
        private string mTableName;
        private int mQueryTimeout;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates the kind of database to connect to (i.e. SQLServer, Oracle, etc.)
        /// </summary>
        public DatabaseTypes DbType
        {
            get { return mDbType; }
            set { mDbType = value; }
        }

        /// <summary>
        /// Instance of the Parameters class to store a collection of parameters
        ///  that are to be executed with this query class
        /// </summary>
        public Parameters ParameterCollection
        {
            get { return mParameterCollection; }
            set { mParameterCollection = value; }
        }

        /// <summary>
        /// Indicates the type of query that will be run on the database server
        /// </summary>
        public virtual SqlQueryType QueryType
        {
            get { return mQueryType; }
            set { mQueryType = value; }
        }

        /// <summary>
        /// Contains the SQL or Stored Procedure name that will be run on the database server
        /// </summary>
        public string QueryString
        {
            get { return mQueryString; }
            set { mQueryString = value; }
        }

        /// <summary>
        /// Indicates the amount of time (in seconds) before a database timeout occurs
        /// </summary>
        public int QueryTimeOut
        {
            get { return mQueryTimeout; }
            set { mQueryTimeout = value; }
        }

        /// <summary>
        /// Contains the table name to store the results (if the dataset option is used)
        /// </summary>
        public virtual string TableName
        {
            get { return mTableName; }
            set { mTableName = value; }
        }

        #endregion

        #region Public Methods
        // Constructor
        public Query()
        {
            SetStartupValues();
        }

        // Constructor
        public Query(SqlQueryType queryType)
        {
            SetStartupValues();

            // Set property values
            this.QueryType = queryType;
        }

        // Constructor
        public Query(SqlQueryType queryType, string sqlQueryString)
        {
            SetStartupValues();

            // Set property values
            this.QueryType = queryType;
            this.QueryString = sqlQueryString;

        }

        /// <summary>
        /// Adds a new parameter to the parameters collection class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddParameter(string name, object value)
        {
            this.ParameterCollection.Add(name, value);
        }

        /// <summary>
        /// Changes the value of a specific parameter by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newValue"></param>
        public void ChangeParameterValue(string name, object newValue)
        {
            this.ParameterCollection.ChangeValue(name, newValue);
        }

        /// <summary>
        /// Changes the value of a specific parameter by index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newValue"></param>
        public void ChangeParameterValue(int index, object newValue)
        {
            this.ParameterCollection.ChangeValue(index, newValue);
        }

        /// <summary>
        /// Removes all parameters from the parameters collection class
        /// </summary>
        public void ClearAllParameters()
        {
            this.ParameterCollection.ClearAll();
        }

        /// <summary>
        /// Returns the value of a specific parameter by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetParameterValue(string name)
        {
            return this.ParameterCollection.GetValue(name);
        }

        /// <summary>
        /// Returns the value of a specific parameter by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetParameterValue(int index)
        {
            return this.ParameterCollection.GetValue(index);
        }

        /// <summary>
        /// Removes a parameter from the parameters collection class by name
        /// </summary>
        /// <param name="name"></param>
        public void RemoveParameter(string name)
        {
            this.ParameterCollection.Remove(name);
        }

        /// <summary>
        /// Removes a parameter from the parameters collection class by index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveParameter(int index)
        {
            this.ParameterCollection.Remove(index);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the class properties to default values
        /// </summary>
        private void SetStartupValues()
        {
            mParameterCollection = new Parameters();
            mDbType = DatabaseTypes.SQLServer; // Default to SQL Server
            mQueryType = SqlQueryType.Sql;
            mQueryString = string.Empty;
            mQueryTimeout = 60;
            mTableName = "Table1";
        }

        #endregion
    }
}
