using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentRepository
    {
        public IEnumerable<Department> get_all_departments_with_products()
        {
            return ObjectMother.ReportingModels.create_department(100);
        }
    }
}