using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.presentation
{
    public class DepartmentBrowserPresenterSpecs
    {
        public class when_initialized
        {
            OurDeparmentBrowserView view;
            IEnumerable<Department> results_to_be_returned_by_the_repository;
            DepartmentRepository department_repository;

            [Test]
            public void should_tell_the_view_to_display_the_departments_retrieved_by_the_department_repository()
            {
                view = new OurDeparmentBrowserView();
                results_to_be_returned_by_the_repository = Enumerable.Range(1, 100).Select(x => new Department()).ToList();
                department_repository = new OurRepository(results_to_be_returned_by_the_repository);

                var sut = new DepartmentBrowserPresenter(view, department_repository);

                sut.initialize();

                Assert.AreEqual(results_to_be_returned_by_the_repository, view.departments);
            }
        }
    }

    public class OurRepository : DepartmentRepository
    {
        IEnumerable<Department> return_this;

        public OurRepository(IEnumerable<Department> return_this)
        {
            this.return_this = return_this;
        }

        public IEnumerable<Department> get_all_departments_with_products()
        {
            return return_this;
        }
    }

    class OurDeparmentBrowserView : DepartmentBrowserView
    {
        public IEnumerable<Department> departments { get; set; }

        public void display(IEnumerable<Department> departments)
        {
            this.departments = departments;
        }
    }
}