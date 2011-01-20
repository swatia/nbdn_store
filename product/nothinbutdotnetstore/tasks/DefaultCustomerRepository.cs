using System.Collections.Generic;
using System.Data;
using System.Linq;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.dataaccesslayer.stubs;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CustomerRepository
    {
        IEnumerable<Customer> get_all_customers();
    }

    public class DefaultCustomerRepository : CustomerRepository
    {
        DatabaseGateway gateway;
        CustomerMapper customer_mapper;

        public DefaultCustomerRepository():this(
            new StubDatabaseGateway(),new CustomerMapper())
        {
        }

        public DefaultCustomerRepository(DatabaseGateway gateway, CustomerMapper customer_mapper)
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
            //            foreach (var data_row in raw_results.Select())
            //            {
            //                yield return customer_mapper.map_from(data_row);
            //            }

            return raw_results.Select().Select(customer_mapper.map_from);
        }
    }
}