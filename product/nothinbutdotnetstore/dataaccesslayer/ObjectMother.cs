using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class ObjectMother
    {
        public class database_items
        {
            public static DatabaseConnectionFactory create_db_connection_factory()
            {
                return new DatabaseConnectionFactory(create_valid_configuration_element());
            }

            public static ConnectionStringSettings create_valid_configuration_element()
            {
                return ConfigurationManager.ConnectionStrings["active"];
            }

            public static DefaultDatabaseGateway create_db_gateway()
            {
                return new DefaultDatabaseGateway(create_db_connection_factory());
            }

            public static DataTable create_table_of_customers(IEnumerable<Customer> customers)
            {
                var data_table = new DataTable();

                data_table.Columns.Add(Tables.Customers.FirstName);
                data_table.Columns.Add(Tables.Customers.LastName);
                data_table.Columns.Add(Tables.Customers.Address);

                customers.ToList().ForEach(x => append_to(data_table, x));
                return data_table;
            }

            static void append_to(DataTable data_table, Customer customer)
            {
                data_table.Rows.Add(customer.FirstName, customer.LastName,
                                    customer.Address);
            }

            public static DataTable create_table_of_products()
            {
                var query = new Query("SELECT * FROM Products ORDER BY ProductID");
                var gateway = create_db_gateway();
                return gateway.run(query);
            }
        }

        public class ReportingModels
        {
            static Customer create_customer(int number)
            {
                return new Customer
                {
                    FirstName = number.ToString("FirstName 0"),
                    LastName = number.ToString("LastName 0"),
                    Address = number.ToString("Address 0")
                };
            }

            public static IEnumerable<Customer> create_customers(int number)
            {
                return Enumerable.Range(1, number).Select(create_customer);
            }
        }
    }
}