using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class DepartmentMapper
    {
        public Department map_from(DataRow data_row)
        {
            return new Department
            {
                Name = data_row[Tables.Departments.DepartmentName].ToString(),
                Id = long.Parse(data_row[Tables.Departments.Id].ToString())
            };
        }
    }
}