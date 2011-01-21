using System.Data;
using System.Transactions;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.dataaccesslayer
{
    public class DatabaseGatewaySpecs
    {
        public class when_executing_a_legitimate_query_for_a_table
        {
            DefaultDatabaseGateway sut;
            DataTable results;

            [SetUp]
            public void setup()
            {
                sut = new DefaultDatabaseGateway(ObjectMother.database_items.create_db_connection_factory());
            }

            [Test]
            public void should_return_a_datatable_with_the_correct_number_of_rows()
            {
                var transaction_scope = new TransactionScope();
                using (transaction_scope)
                {
                    var db_table = new DbTable("Products");
//                    DbUtility.generate_rows_for(db_table, 100);

                    results = sut.run(db_table.all_query());
                    Assert.IsTrue(results.Rows.Count > 0);
                }
                
            }
        }
    }
}
