using ChemiChemicals.Repository.Helper;
using System.Configuration;
using Xunit;

namespace ChemiChemical.Test
{
    public class TestSqlConnection
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["TestConnectionSting"].ConnectionString;

        [Fact]
        public void TestSetConnectionString()
        {
            ConnectionStringBuilder builder = ConnectionStringBuilder.getInstance();
            builder.SetConnectionString(_connectionString);
        }

        [Fact]
        public void TestGetConnectionString()
        {
            TestSetConnectionString();
            ConnectionStringBuilder builder = ConnectionStringBuilder.getInstance();
            Assert.Equal(builder.GetConnectionString(), _connectionString);
        }
    }
}
