using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore
{
    public class ObjectMother
    {
        public static class web_items
        {
            public static HttpContext create_http_context()
            {
                return new HttpContext(create_request(),create_response());
            }

            static HttpResponse create_response()
            {
                return new HttpResponse(new StringWriter());
            }

            static HttpRequest create_request()
            {
return new HttpRequest("blah.aspx","http://localhost/blah.aspx",String.Empty);
            }
        }

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

            public static DataTable create_table_of_departments(IEnumerable<Department> customers)
            {
                var data_table = new DataTable();

                data_table.Columns.Add(Tables.Departments.DepartmentName);
                data_table.Columns.Add(Tables.Departments.Id);

                customers.ToList().ForEach(x => append_to(data_table, x));
                return data_table;
            }

            static void append_to(DataTable data_table, Department department)
            {
                data_table.Rows.Add(department.Name,department.Id);
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
            static Department create_customer(int number)
            {
                return new Department
                {
                    Name = number.ToString("Department 0"),
                    Id =  number
                };
            }

            public static IEnumerable<Department> create_department(int number)
            {
                return Enumerable.Range(1, number).Select(create_customer);
            }
        }
    }
}