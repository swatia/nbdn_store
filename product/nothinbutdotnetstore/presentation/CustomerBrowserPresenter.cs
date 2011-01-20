using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public class CustomerBrowserPresenter
    {
        CustomerBrowserView view;
        CustomerRepository customer_repository;

        public CustomerBrowserPresenter(CustomerBrowserView view) : this(view,
                                                                         new DefaultCustomerRepository())
        {
        }

        public CustomerBrowserPresenter(CustomerBrowserView view, CustomerRepository customer_repository)
        {
            this.view = view;
            this.customer_repository = customer_repository;

            view.display(customer_repository.get_all_customers());
        }

        public void initialize()
        {
            view.display(customer_repository.get_all_customers());
        }
    }
}