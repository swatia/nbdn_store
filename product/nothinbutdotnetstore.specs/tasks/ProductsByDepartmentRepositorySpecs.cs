using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    class ProductsByDepartmentRepositorySpecs
    {
        IEnumerable<Product> products;

        [Test]
        public void should_return_all_of_the_customers_mapped_from_the_customer_data()
        {
            var sut = new DefaultCustomerRepository(ObjectMother.database_items.create_db_gateway(), new CustomerMapper());
            customers = sut.get_all_customers();
            Assert.IsTrue(customers.Count() > 0);
        }
    }
}
