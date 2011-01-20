using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            public void Setup()
            {
                sut = new DatabaseGateway(ObjectMother.database_items.create_db_connection_factory());
                results = sut.execute_query("select * from customers");
            }

            [Test]
            public void should_return_a_data_table()
            {
                Assert.IsNotNull(results);
            }

            [Test]
            public void should_return_4_rows_of_data_table()
            {
                Assert.AreEqual(4,results.Rows.Count);
            }

            [Test]
            public void should_return_first_name_last_name()
            {
                var dictionary = new Dictionary<string, int>();
                dictionary.Add(new DbQuery("Select * from customers", 20));
                dictionary.Add(new DbQuery("select * from departments", 33));
                dictionary.Add(new DbQuery("select * from products", 57));

                dictionary.Values.ToList().ForEach((query, count) =>
                {
                    DbUtility.generate_rows_for();
                });
                DbUtility.generate_rows_for("Customers", 20);

            }
        }
    }
}