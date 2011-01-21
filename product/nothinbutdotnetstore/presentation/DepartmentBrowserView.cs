using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.presentation
{
    public interface DepartmentBrowserView
    {
        void display(IEnumerable<Department> departments);
    }
}