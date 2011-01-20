using System;
using System.Configuration;
using nothinbutdotnetstore.dataaccesslayer;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectMother
    {
        public class database_items
        {
            public static DatabaseConnectionFactory create_db_connection_factory()
            {
                return new DatabaseConnectionFactory(create_valid_configuration_element());
            }

            public static ConnectionStringSettings create_valid_configuration_element()
            {
                return new ConnectionStringSettings("blah", "data source=(local);integrated security=SSPI",
                                                    "System.Data.SqlClient");
            }

            public static DefaultDatabaseGateway create_db_gateway()
            {
                throw new NotImplementedException();
            }
        }
    }
}