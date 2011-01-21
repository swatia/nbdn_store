using System;
using System.Collections.Generic;
using System.Web.UI;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.presentation;

namespace nothinbutdotnetstore.web.ui.views
{
    public partial class DepartmentBrowser : Page,DepartmentBrowserView
    {
       protected IEnumerable<Department> departments;

        protected override void OnLoad(EventArgs e)
        {
            new DepartmentBrowserPresenter(this).initialize();
            base.OnLoad(e);
        }

        public void display(IEnumerable<Department> departments)
        {
            this.departments = departments;
        }
    }
}