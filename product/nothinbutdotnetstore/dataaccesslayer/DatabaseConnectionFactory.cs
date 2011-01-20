using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class DatabaseConnectionFactory
    {
        ConnectionStringSettings settings;

        public DatabaseConnectionFactory(ConnectionStringSettings settings)
        {
            this.settings = settings;
        }

        public IDbConnection create()
        {
            return new SqlConnection(this.settings.ConnectionString);
        }
    }
}