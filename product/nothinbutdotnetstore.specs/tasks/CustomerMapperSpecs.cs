using System.Data;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    public class CustomerMapperSpecs
    {
        public class when_mapping_a_customer_from_a_customer_row_and_all_the_necessary_information_is_present
        {
            [Test]
            public void should_populate_the_customer_with_the_correct_details()
            {
                var jp = new Customer
                {
                    Address = "the address",
                    FirstName = "JP",
                    LastName = "Boodhoo"
                };

                var data_table = new DataTable();
                data_table.Columns.Add("FirstName");
                data_table.Columns.Add("LastName");
                data_table.Columns.Add("Address");

                data_table.Rows.Add(jp.FirstName, jp.LastName, jp.Address);

                var sut = new CustomerMapper();
                var result = sut.map_from(data_table.Rows[0]);

                is_equal(jp, result);
            }

            void is_equal(Customer expected, Customer actual)
            {
                Assert.AreEqual(expected.FirstName, actual.FirstName);
            }
        }
    }
}