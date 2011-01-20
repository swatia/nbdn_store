using System.Collections.Generic;
using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class CustomerRepository
    {
        DatabaseGateway gateway;
        CustomerMapper customer_mapper;

        public CustomerRepository(DatabaseGateway gateway,CustomerMapper customer_mapper)
        {
            this.gateway = gateway;
            this.customer_mapper = customer_mapper;
        }

        public IEnumerable<Customer> get_all_customers()
        {
            var query = new Query("SELECT * FROM Customers");

            return map_customers_from(gateway.run(query));
        }

        IEnumerable<Customer> map_customers_from(DataTable raw_results)
        {
            foreach (DataRow row in raw_results.Rows)
                yield return customer_mapper.map_from(row);
        }
    }
}