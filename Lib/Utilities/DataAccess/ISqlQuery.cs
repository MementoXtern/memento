using System.Data;

namespace Lib.Utilities.DataAccess
{
    internal interface ISqlQuery
    {
        // Query Object
        void Execute(Query queryObject);
        DataSet ExecuteAsDataSet(Query queryObject);
        DataTable ExecuteAsDataTable(Query queryObject);
        object ExecuteAsScalar(Query queryObject);
        int? ExecuteAsInt(Query queryObject);

        // SqlXmlQuery Object
        string ExecuteXml(SqlXmlQuery queryObject);
    }
}
