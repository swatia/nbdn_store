using System;
using System.Collections.Generic;
using System.Web.UI;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.ui.views
{
    public partial class ProductBrowser : Page, ProductBrowserView
    {
        protected IEnumerable<Product> details;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            new ProductBrowserPresenter(this).initialize(int.Parse(Request.QueryString["department_id"]));
        }

        public void display(IEnumerable<Product> products)
        {
            this.details = products;
        }
    }
}