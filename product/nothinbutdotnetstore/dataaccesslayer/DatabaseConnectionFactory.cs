using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class DatabaseConnectionFactory
    {
        ConnectionStringSettings settings;
        DbProviderFactory provider;

        public DatabaseConnectionFactory(ConnectionStringSettings settings)
        {
            this.settings = settings;
            provider = get_the_connection_provider_using_the(settings);
        }

        public IDbConnection create()
        {
            try
            {
                return create_a_connection_using_the_current_provider();
            }
            catch (Exception e)
            {
                throw  new InvalidConnectionSettingsException();
            }
        }

        IDbConnection create_a_connection_using_the_current_provider()
        {
            var connection = provider.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;
            return connection;
        }

        DbProviderFactory get_the_connection_provider_using_the(ConnectionStringSettings connection_string_settings)
        {
            try
            {
                return DbProviderFactories.GetFactory(settings.ProviderName);
            }
            catch (Exception e)
            {
                throw new InvalidConnectionSettingsException();  
            }
        }
    }
}