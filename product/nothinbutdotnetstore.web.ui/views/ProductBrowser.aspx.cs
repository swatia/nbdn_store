using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            new ProductBrowserPresenter(this).initialize();
        }

        public void display(IEnumerable<Product> products)
        {
            this.details = products;
        }

        public NameValueCollection payload
        {
            get { return Request.Params;}
        }
    }
}