using System;
using System.Data;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class CustomerMapper
    {
        public Customer map_from(DataRow data_row)
        {
            var ret = new Customer();
            ret.FirstName = data_row[Constants.Tables.Customers.FirstName] as string;
            ret.LastName = data_row[Constants.Tables.Customers.LastName] as string;
            ret.Address = data_row[Constants.Tables.Customers.Address] as string;

            return ret;
        }
    }
}