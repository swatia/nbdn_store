using System.Configuration;
using System.Data.SqlClient;
using nothinbutdotnetstore.dataaccesslayer;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.dataaccesslayer
{
    public class DatabaseConnectionFactorySpecs
    {
        public class when_creating_a_connection_from_a_legitimate_connection_settings_item
        {
            [Test]
            public void should_create_a_connection_with_the_right_details()
            {
                var settings = new ConnectionStringSettings("blah",
                                                            "data source=(local);Initial catalog=blah;Integrated Security=SSPI");
                settings.ProviderName = "System.Data.SqlClient";

                var sut = new DatabaseConnectionFactory(settings);

                var connection = sut.create();

                Assert.IsInstanceOf(typeof(SqlConnection), connection);
                StringAssert.AreEqualIgnoringCase(settings.ConnectionString, connection.ConnectionString);
            }
        }
    }
}