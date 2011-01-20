using System.Data;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class CustomerMapper
    {
        public Customer map_from(DataRow data_row)
        {
            return new Customer
            {
                Address = data_row["address"].ToString(),
                FirstName = data_row["FirstName"].ToString(),
                LastName = data_row["LastName"].ToString()
            };
        }
    }
}