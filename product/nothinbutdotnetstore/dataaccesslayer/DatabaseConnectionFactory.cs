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

        public DatabaseConnectionFactory():this(ConfigurationManager.ConnectionStrings["Active"])
        {
        }

        public DatabaseConnectionFactory(ConnectionStringSettings settings)
        {
            this.settings = settings;
            provider = create_with_exception_handling(() => get_the_connection_provider_using_the(settings));
        }

        public IDbConnection create()
        {
            return create_with_exception_handling(() => create_a_connection_using_the_current_provider());
        }

        IDbConnection create_a_connection_using_the_current_provider()
        {
            var connection = provider.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;
            return connection;
        }

        DbProviderFactory get_the_connection_provider_using_the(ConnectionStringSettings connection_string_settings)
        {
            return DbProviderFactories.GetFactory(settings.ProviderName);
        }

        public ReturnType create_with_exception_handling<ReturnType>(Func<ReturnType> factory)
        {
            try
            {
                return factory();
            }
            catch (Exception e)
            {
                throw new InvalidConnectionSettingsException(e);
            }
        }
    }
}