using System;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public class CustomerBrowserPresenter
    {

        CustomerBrowserView view;
        CustomerRepository customer_repository;

        public CustomerBrowserPresenter(CustomerBrowserView view, CustomerRepository customer_repository)
        {
            view.display(customer_repository.get_all_customers());
        }

        public void initialize()
        {
            
        }
    }
}