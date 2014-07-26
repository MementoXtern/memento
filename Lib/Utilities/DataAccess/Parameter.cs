namespace Lib.Utilities.DataAccess
{
    // This struct holds the name and value of a SQL parameter
    internal struct Parameter
    {
        public string Name;
        public object Value;

        public Parameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
