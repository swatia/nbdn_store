using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.presentation
{
    public class CustomerBrowserPresenterSpecs
    {
        public class when_initialized
        {
            OurCustomerBrowserView view;
            IEnumerable<Customer> results_to_be_returned_by_the_repository;
            CustomerRepository customer_repository;

            [Test]
            public void should_tell_the_view_to_display_the_customers_retrieved_by_the_customer_repository()
            {
                results_to_be_returned_by_the_repository = Enumerable.Range(1, 100).Select(x => new Customer()).ToList();
                customer_repository = new OurRepository(results_to_be_returned_by_the_repository);

                new CustomerBrowserPresenter( new OurCustomerBrowserView(),customer_repository);

                Assert.AreEqual(results_to_be_returned_by_the_repository,view.customers);
            } 
        }
    }

    public class OurRepository : CustomerRepository
    {
        IEnumerable<Customer> return_this;

        public OurRepository(IEnumerable<Customer> return_this)
        {
            this.return_this = return_this;
        }

        public IEnumerable<Customer> get_all_customers()
        {
            return return_this;
        }
    }

    class OurCustomerBrowserView : CustomerBrowserView
    {
        public IEnumerable<Customer> customers { get; set; }
        public void display(IEnumerable<Customer> customers)
        {
            this.customers = customers;
        }
    }
}