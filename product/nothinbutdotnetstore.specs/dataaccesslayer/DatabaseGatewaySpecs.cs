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
            DatabaseGateway sut;
            DataTable results;

            [SetUp]
            public void setup()
            {
                sut = new DatabaseGateway(ObjectMother.database_items.create_db_connection_factory());

            }

            [Test]
            public void should_return_a_datatable_with_the_correct_number_of_rows()
            {
                var transaction_scope = new TransactionScope();
                using (transaction_scope)
                {
                    var db_table = new DbTable("Customers");
                    DbUtility.generate_rows_for(db_table, 100);

                    results = sut.execute_query(db_table.all_query());
                    Assert.AreEqual(100,results.Rows.Count);
                }
                
            }
        }
    }
}