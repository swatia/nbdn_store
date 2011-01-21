using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public class DepartmentBrowserPresenter
    {
        DepartmentBrowserView view;
        DepartmentRepository department_repository;

        public DepartmentBrowserPresenter(DepartmentBrowserView view) : this(view,
                                                                             new DefaultDepartmentRepository())
        {
        }

        public DepartmentBrowserPresenter(DepartmentBrowserView view, DepartmentRepository department_repository)
        {
            this.view = view;
            this.department_repository = department_repository;

            view.display(department_repository.get_all_departments_with_products());
        }

        public void initialize()
        {
            view.display(department_repository.get_all_departments_with_products());
        }
    }
}