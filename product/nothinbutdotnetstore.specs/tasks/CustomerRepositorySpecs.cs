using System.Collections.Generic;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;
using System.Linq;

namespace nothinbutdotnetstore.specs.tasks
{
    public class CustomerRepositorySpecs
    {
        public class when_getting_all_of_the_customers
        {
            IEnumerable<Customer> customers;

            [Test]
            public void should_return_all_of_the_customers_mapped_from_the_customer_data()
            {
                var sut = new DefaultCustomerRepository(ObjectMother.database_items.create_db_gateway(), new CustomerMapper());
                customers = sut.get_all_customers();
                Assert.IsTrue(customers.Count() >0);
            }
        }

    }
}