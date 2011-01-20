using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.presentation
{
    public interface CustomerBrowserView
    {
        void display(IEnumerable<Customer> customers);
    }
}