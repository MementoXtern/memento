namespace Lib.Utilities.DataAccess
{
    // enumeration specifing supported query types
    public enum SqlXmlQueryType { SqlXml, SqlXmlStoredProc }

    public class SqlXmlQuery : Query
    {
        #region Private Members
        
        // member variables to hold property values
        private SqlXmlQueryType mQueryType = SqlXmlQueryType.SqlXml;
        private string mStartTag = "";
        private string mEndTag = "";

        #endregion

        #region Properties
        
        // Properties
        public new SqlXmlQueryType QueryType
        {
            get { return mQueryType; }
            set { mQueryType = value; }
        }

        public string StartTag
        {
            get { return mStartTag; }
            set { mStartTag = value; }
        }

        public string EndTag
        {
            get { return mEndTag; }
            set { mEndTag = value; }
        }

        #endregion

        #region Public Methods
        
        // Constructor
        public SqlXmlQuery()
        {
            // Do Nothing
        }

        // Constructor
        public SqlXmlQuery(SqlXmlQueryType queryType)
        {
            // Set property values
            mQueryType = queryType;
        }

        // Constructor
        public SqlXmlQuery(SqlXmlQueryType queryType, string sqlQueryString)
        {
            // Set property values
            mQueryType = queryType;

            // Set base class property
            QueryString = sqlQueryString;
        }

        // Constructor
        public SqlXmlQuery(SqlXmlQueryType queryType, string sqlQueryString,
                           string startTag, string endTag)
        {
            // Set property values
            mQueryType = queryType;
            mStartTag = startTag;
            mEndTag = endTag;

            // Set base class property
            QueryString = sqlQueryString;
        }

        public void SetRootNode(string rootNodeName)
        {
            rootNodeName = rootNodeName.Replace("<", "").Replace(">", "").Replace("/", "");
            mStartTag = "<" + rootNodeName + ">";
            mEndTag = "</" + rootNodeName + ">";
        }

        #endregion
    }
}
