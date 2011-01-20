using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class CustomerMapper
    {
        public Customer map_from(DataRow data_row)
        {
            return new Customer
            {
                Address = data_row[Tables.Customers.Address].ToString(),
                FirstName = data_row[Tables.Customers.FirstName].ToString(),
                LastName = data_row[Tables.Customers.LastName].ToString()
            };
        }
    }
}