using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.specs.utility;
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
                var settings = ObjectMother.database_items.create_valid_configuration_element();
                settings.ProviderName = "System.Data.SqlClient";

                var sut = new DatabaseConnectionFactory(settings);

                var connection = sut.create();

                Assert.IsInstanceOf(typeof(SqlConnection), connection);
                StringAssert.AreEqualIgnoringCase(settings.ConnectionString, connection.ConnectionString);
            }

            [Test]
            public void should_create_a_connection_that_matches_the_expected_provider_type()
            {
                var settings = ObjectMother.database_items.create_valid_configuration_element();

                settings.ProviderName = "System.Data.OleDb";

                var sut = new DatabaseConnectionFactory(settings);

                var connection = sut.create();

                Assert.IsInstanceOf(typeof(OleDbConnection), connection);
                StringAssert.AreEqualIgnoringCase(settings.ConnectionString, connection.ConnectionString);
            }

        }

        public class when_creating_a_connection_from_an_invalid_connection_settings_item
        {
            [Test]
            public void should_fail_at_construction_if_the_provider_name_is_invalid()
            {
                var settings = new ConnectionStringSettings("blah",
                                                            "data source=(local);Initial catalog=blah;Provider=SQLOleDb");
                settings.ProviderName = "InvalidProvider";


                Assert.Catch<InvalidConnectionSettingsException>(() => new DatabaseConnectionFactory(settings)); 
            }
            [Test]
            public void should_fail_if_the_connection_string_is_invalid()
            {
                var settings = new ConnectionStringSettings("blah",
                                                            "data source=(local);Initial catalog=blah;Providesdfdsfr=SQLOleDb");
                settings.ProviderName = "System.Data.OleDb";

                var sut = new DatabaseConnectionFactory(settings);

                Assert.Catch(typeof(InvalidConnectionSettingsException), () => sut.create()); 
            }

            [Test]
            public void should_fail_and_provide_access_to_the_underlying_exception_for_a_good_stack_trace()
            {
                var settings = new ConnectionStringSettings("blah",
                                                            "data source=(local);Initial catalog=blah;Providesdfdsfr=SQLOleDb");
                settings.ProviderName = "System.Data.OleDb";

                var sut = new DatabaseConnectionFactory(settings);

                var exception = Assert.Catch(typeof(InvalidConnectionSettingsException), () => sut.create()); 
                Assert.IsNotNull(exception.InnerException);
            }
        }
    }
}