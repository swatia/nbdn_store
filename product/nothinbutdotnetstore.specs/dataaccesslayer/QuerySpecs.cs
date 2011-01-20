using nothinbutdotnetstore.dataaccesslayer;
using NUnit.Framework;

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
    }
}