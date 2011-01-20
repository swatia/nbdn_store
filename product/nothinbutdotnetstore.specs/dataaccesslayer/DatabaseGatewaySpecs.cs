using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.specs.utility;
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
                var sut = new DatabaseGateway(ObjectMother.database_items.create_db_connection_factory());
                var results = sut.execute_query("select * from customers");
                Assert.IsNotNull(results);
            }
        }
    }
}