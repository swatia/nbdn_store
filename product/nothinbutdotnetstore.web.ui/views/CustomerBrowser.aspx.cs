using System;
using System.Collections.Generic;
using System.Web.UI;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.presentation;

namespace nothinbutdotnetstore.web.ui.views
{
    public partial class CustomerBrowser : Page, CustomerBrowserView
    {
        protected IEnumerable<Customer> details;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            new CustomerBrowserPresenter(this).initialize();
        }

        public void display(IEnumerable<Customer> customers)
        {
            this.details = customers;
        }
    }
}