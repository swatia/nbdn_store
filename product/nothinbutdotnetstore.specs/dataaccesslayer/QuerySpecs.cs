using System.Data.SqlClient;
using nothinbutdotnetstore.dataaccesslayer;
using NUnit.Framework;
using System.Data;
using nothinbutdotnetstore.specs.utility;

namespace nothinbutdotnetstore.specs.dataaccesslayer
{
    public class QuerySpecs
    {
        public class when_implicitly_converted_to_a_string
        {
            string original_query;

            [Test]
            public void should_return_the_value_of_the_raw_sql()
            {
                original_query = "SELECT * FROM Customers";
                var sut = new Query(original_query);

                string sut_as_string = sut;

                Assert.AreEqual(original_query, sut_as_string);
            }
            public void should_return_the_value_of_the_raw_sql_when_to_string_is_invoked()
            {
                original_query = "SELECT * FROM Customers";
                var sut = new Query(original_query);

                string sut_as_string = sut.ToString();

                Assert.AreEqual(original_query, sut_as_string);
            }
        }
        public class when_applying_to_command
        {
            Query query = new Query("SELECT * FROM Customers");

            [Test]
            public void should_return_command_with_command_text()
            {
                IDbCommand command = new SqlCommand();
                query.apply_to(command);
                Assert.AreEqual(command.CommandText, query.ToString());
                Assert.AreEqual(command.CommandType, CommandType.Text);
            }
        }
    }
}