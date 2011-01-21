using System.Collections.Generic;
using System.Data;

namespace nothinbutdotnetstore.tasks
{
    public interface ProductsByDepartmentRepository
    {
        IEnumerable<Product> get_products_for_department(int department_id);
    }
}