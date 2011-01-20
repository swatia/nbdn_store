using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using nothinbutdotnetstore.dataaccesslayer;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.dataaccesslayer
{
    public class DatabaseGatewaySpecs
    {
        public class when_executing_a_legitimate_query_for_a_table
        {
            [Test]
            public void should_return_a_data_table()
            {
                var settings = new ConnectionStringSettings("blah",
                                                            "data source=(local);Initial catalog=blah;Integrated Security=SSPI");
                settings.ProviderName = "System.Data.SqlClient";
                DatabaseConnectionFactory dbConnectionFactory = new DatabaseConnectionFactory(settings);
                var connection = dbConnectionFactory.create();

                var sut = new DatabaseGateway(connection);
                var results = sut.execute_query("select * from customers");

                Assert.IsInstanceOf(typeof(DataTable), results);
            }
        }
    }
}
