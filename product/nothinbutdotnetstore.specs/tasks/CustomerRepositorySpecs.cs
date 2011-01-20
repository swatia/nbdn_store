using System;
using System.Collections.Generic;
using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    public class CustomerRepositorySpecs
    {
        public class when_getting_all_of_the_customers
        {
            IEnumerable<Customer> customers;
            DatabaseGateway some_gateway;

            [Test]
            public void should_return_all_of_the_customers_mapped_from_the_customer_data()
            {
                some_gateway = new OurGateway();
                var sut = new DefaultCustomerRepository(some_gateway,new CustomerMapper());
                customers = sut.get_all_customers();
                Assert.IsNotNull(customers);
            }
        }
    }

    public class OurGateway : DatabaseGateway
    {
        public DataTable run(Query query)
        {
            return ObjectMother.database_items.create_table_of_customers(
                ObjectMother.ReportingModels.create_customers(100)); 
        }
    }
}