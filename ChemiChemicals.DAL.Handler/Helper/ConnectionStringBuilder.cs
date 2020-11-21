
namespace ChemiChemicals.Repository.Helper
{
    //get the singelton pattern code from https://www.geeksforgeeks.org/singleton-design-pattern/

    public class ConnectionStringBuilder
    {
        private static ConnectionStringBuilder _instance;
        private string _connectionString;

        //make the constructor private so that this class cannot be
        //instantiated
        private ConnectionStringBuilder() { }

        //Get the only object available
        public static ConnectionStringBuilder getInstance()
        {
            if (_instance == null)
                _instance = new ConnectionStringBuilder();
            return _instance;
        }

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
