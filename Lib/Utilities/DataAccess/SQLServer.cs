using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Lib.Utilities.DataAccess
{
    internal class SQLServer : ISqlQuery
    {
        #region Private Members
        
        private string mDbConnStr = string.Empty;
        private SqlConnection mConnection;

        #endregion

        #region Public Methods
        
        // Constructor
        public SQLServer(string dbConnStr)
        {
            // Set the connection string
            mDbConnStr = dbConnStr;

            // Create a new DB Connection object
            mConnection = new SqlConnection(mDbConnStr);
        }

        // Destructor
        ~SQLServer()
        {
            mConnection = null;
        }

        /// <summary>
        /// Executes a query object
        /// </summary>
        /// <param name="queryObject"></param>
        public void Execute(Query queryObject)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                // Check the connection state
                CheckConnection();

                // Open the connection
                mConnection.Open();

                // Set the connection for the command object
                command.Connection = mConnection;

                // Set the timeout for the command object
                command.CommandTimeout = queryObject.QueryTimeOut;

                // Set the command text
                command.CommandText = queryObject.QueryString;

                // Set the Command Type, if type is store procedure
                if (queryObject.QueryType.Equals(SqlQueryType.SqlStoredProc))
                {
                    command.CommandType = CommandType.StoredProcedure;
                }

                // Set query parameters
                SetParameters(queryObject, ref command);

                // Execute the SQL
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.State == 17)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                // Close DB Connection
                mConnection.Close();

                command = null;
            }
        }

        /// <summary>
        /// Executes a query object returning the results in a data set
        /// </summary>
        /// <param name="queryObejct"></param>
        /// <returns></returns>
        public DataSet ExecuteAsDataSet(Query queryObejct)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dataAdapter;
            DataSet returnDS = new DataSet();

            try
            {
                // Check the connection state
                CheckConnection();

                // Open the connection
                mConnection.Open();

                // Set the connection for the command object
                command.Connection = mConnection;

                // Set the timeout for the command object
                command.CommandTimeout = queryObejct.QueryTimeOut;

                // Set the Command Type, if type is store procedure
                if (queryObejct.QueryType.Equals(SqlQueryType.SqlStoredProc))
                {
                    command.CommandType = CommandType.StoredProcedure;
                }

                // Set the command text
                command.CommandText = queryObejct.QueryString.ToString();

                // Set query parameters
                SetParameters(queryObejct, ref command);

                // Execute the SQL
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(returnDS, queryObejct.TableName.ToString());

                // Return the dataset
                return returnDS;
            }
            catch (SqlException ex)
            {
                if (ex.State == 17)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                // Close DB Connection
                mConnection.Close();

                command = null;
                dataAdapter = null;
                returnDS = null;
            }
        }

        /// <summary>
        /// Executes a query object returning the results in a data table
        /// </summary>
        /// <param name="queryObejct"></param>
        /// <returns></returns>
        public DataTable ExecuteAsDataTable(Query queryObejct)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dataAdapter;
            DataTable returnDT = new DataTable();

            try
            {
                // Check the connection state
                CheckConnection();

                // Open the connection
                mConnection.Open();

                // Set the connection for the command object
                command.Connection = mConnection;

                // Set the timeout for the command object
                command.CommandTimeout = queryObejct.QueryTimeOut;

                // Set the Command Type, if type is store procedure
                if (queryObejct.QueryType.Equals(SqlQueryType.SqlStoredProc))
                {
                    command.CommandType = CommandType.StoredProcedure;
                }

                // Set the command text
                command.CommandText = queryObejct.QueryString.ToString();

                // Set query parameters
                SetParameters(queryObejct, ref command);

                // Execute the SQL
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(returnDT);
                returnDT.TableName = queryObejct.TableName.ToString();

                // Return the data table
                return returnDT;
            }
            catch (SqlException ex)
            {
                if (ex.State == 17)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                // Close DB Connection
                mConnection.Close();

                command = null;
                dataAdapter = null;
                returnDT = null;
            }
        }

        /// <summary>
        /// Executes a query object returning the results in an int?
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        public int? ExecuteAsInt(Query queryObject)
        {
            SqlCommand command = null;
            object returnValue = null;

            try
            {
                command = new SqlCommand();

                // Check the connection state
                CheckConnection();

                // Open the connection
                mConnection.Open();

                // Set the connection for the command object
                command.Connection = mConnection;

                // Set the timeout for the command object
                command.CommandTimeout = queryObject.QueryTimeOut;

                // Set the Command Type, if type is store procedure
                if (queryObject.QueryType.Equals(SqlQueryType.SqlStoredProc))
                {
                    command.CommandType = CommandType.StoredProcedure;
                }

                // Set the command text
                command.CommandText = queryObject.QueryString;

                // Set query parameters
                SetParameters(queryObject, ref command);

                // Execute the SQL
                returnValue = command.ExecuteScalar();

                // This is a workaround for returning @@IDENTITY as an int
                if (returnValue != null && returnValue.GetType() == typeof(decimal))
                {
                    returnValue = Convert.ToInt32(returnValue);
                }

                // Return the value
                return returnValue as int?;
            }
            finally
            {
                if (mConnection != null && mConnection.State != ConnectionState.Closed)
                {
                    mConnection.Close();
                }

                if (command != null)
                {
                    command.Dispose();
                }
            }
        }

        /// <summary>
        /// Executes a query object returning the results in a scalar
        /// </summary>
        /// <param name="queryObejct"></param>
        /// <returns></returns>
        public object ExecuteAsScalar(Query queryObejct)
        {
            SqlCommand command = new SqlCommand();
            object returnValue = null;

            try
            {
                // Check the connection state
                CheckConnection();

                // Open the connection
                mConnection.Open();

                // Set the connection for the command object
                command.Connection = mConnection;

                // Set the timeout for the command object
                command.CommandTimeout = queryObejct.QueryTimeOut;

                // Set the Command Type, if type is store procedure
                if (queryObejct.QueryType.Equals(SqlQueryType.SqlStoredProc))
                {
                    command.CommandType = CommandType.StoredProcedure;
                }

                // Set the command text
                command.CommandText = queryObejct.QueryString.ToString();

                // Set query parameters
                SetParameters(queryObejct, ref command);

                // Execute the SQL
                returnValue = command.ExecuteScalar();

                // Return the value
                return returnValue;
            }
            catch (SqlException ex)
            {
                if (ex.State == 17)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                // Close DB Connection
                mConnection.Close();

                command = null;
            }
        }

        /// <summary>
        /// Executes a sql-xml query object returning the results as a string
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        public string ExecuteXml(SqlXmlQuery queryObject)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dataAdapter;
            DataSet tempDataSet = new DataSet();

            try
            {
                // Check the connection state
                CheckConnection();

                // Open the connection
                mConnection.Open();

                // Set the connection for the command object
                command.Connection = mConnection;

                // Set the timeout for the command object
                command.CommandTimeout = queryObject.QueryTimeOut;

                // Set the Command Type, if type is store procedure
                if (queryObject.QueryType.Equals(SqlXmlQueryType.SqlXmlStoredProc))
                {
                    command.CommandType = CommandType.StoredProcedure;
                }

                // Set the command text
                command.CommandText = queryObject.QueryString.ToString();

                // Set query parameters
                SetParameters(queryObject, ref command);

                // Execute the SQL
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(tempDataSet);

                // Get the xml from the dataset
                StringBuilder returnXML = new StringBuilder("");
                for (int x = 0; x <= tempDataSet.Tables.Count - 1; x++)
                {
                    for (int i = 0; i <= tempDataSet.Tables[x].Rows.Count - 1; i++)
                    {
                        returnXML.Append(tempDataSet.Tables[x].Rows[i].ItemArray[0]);
                    }
                }

                // Return the xml as a string concatenated with the start tag and end tag properties
                return queryObject.StartTag.ToString() + returnXML.ToString() + queryObject.EndTag.ToString();
            }
            catch (SqlException ex)
            {
                if (ex.State == 17)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                // Close DB Connection
                mConnection.Close();

                command = null;
                dataAdapter = null;
                tempDataSet = null;
            }
        }

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Makes sure the connection object is set to an instance and a DB Connection string is set
        /// </summary>
        private void CheckConnection()
        {
            if (mConnection.Equals(null))
            {
                mConnection = new SqlConnection(mDbConnStr);
            }
            else if (mConnection.State.Equals(0))
            {
                mConnection.ConnectionString = mDbConnStr;
            }
        }

        /// <summary>
        /// Sets the parameters for a command object
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="command"></param>
        private void SetParameters(Query queryObject, ref SqlCommand command)
        {
            foreach (Parameter currentParameter in queryObject.ParameterCollection.ParameterArray)
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = currentParameter.Name.ToString();
                parameter.Value = currentParameter.Value;
                command.Parameters.Add(parameter);
                parameter = null;
            }
        }

        #endregion
    }
}
