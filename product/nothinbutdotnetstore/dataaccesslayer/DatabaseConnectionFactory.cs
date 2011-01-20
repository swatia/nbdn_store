using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

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

            // Construct an ADO.NET provider
            var providerFactory = DbProviderFactories.GetFactory(settings.ProviderName);

            // Construct and open connection
            IDbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;

            return connection;


        }
    }
}