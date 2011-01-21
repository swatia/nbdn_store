using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    public class DepartmentRepositorySpecs
    {
        public class when_getting_all_of_the_departments_with_products
        {
            IEnumerable<Department> departments_with_products;

            [Test]
            public void should_return_all_of_the_customers_mapped_from_the_customer_data()
            {
                var sut = new DefaultDepartmentRepository(ObjectMother.database_items.create_db_gateway(),
                                                        new DepartmentMapper());
                departments_with_products = sut.get_all_departments_with_products();
                Assert.IsTrue(departments_with_products.Count() > 0);
            }
        }
    }
}