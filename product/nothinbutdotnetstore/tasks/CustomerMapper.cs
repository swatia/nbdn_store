using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class CustomerMapper
    {
        public Customer map_from(DataRow data_row)
        {
            var ret = new Customer();
            ret.FirstName = data_row[Tables.Customers.FirstName] as string;
            ret.LastName = data_row[Tables.Customers.LastName] as string;
            ret.Address = data_row[Tables.Customers.Address] as string;

            return ret;
        }
    }
}