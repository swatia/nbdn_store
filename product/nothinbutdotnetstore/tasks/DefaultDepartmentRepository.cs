using System.Collections.Generic;
using System.Data;
using System.Linq;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_all_departments_with_products();
    }

    public class DefaultDepartmentRepository : DepartmentRepository
    {
        DatabaseGateway gateway;
        DepartmentMapper department_mapper;

        public DefaultDepartmentRepository():this(
            new DefaultDatabaseGateway(),new DepartmentMapper())
        {
        }

        public DefaultDepartmentRepository(DatabaseGateway gateway, DepartmentMapper department_mapper)
        {
            this.gateway = gateway;
            this.department_mapper = department_mapper;
        }

        public IEnumerable<Department> get_all_departments_with_products()
        {
            var query = new Query("SELECT * FROM Departments INNER JOIN Products On Departments.DepartmentId=Products.DepartmentId");

            return map_customers_from(gateway.run(query));
        }

        IEnumerable<Department> map_customers_from(DataTable raw_results)
        {
            //            foreach (var data_row in raw_results.Select())
            //            {
            //                yield return customer_mapper.map_from(data_row);
            //            }

            return raw_results.Select().Select(department_mapper.map_from);
        }
    }
}