using System.Collections.Generic;
using System.Data;
using System.Linq;
using nothinbutdotnetstore.dataaccesslayer;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultProductsRepository : ProductsRepository
    {
        protected ProductMapper product_mapper { get; set; }
        protected DatabaseGateway gateway { get; set; }

        public DefaultProductsRepository()
            : this(new DefaultDatabaseGateway(), new ProductMapper())
        {
        }

        public DefaultProductsRepository(DatabaseGateway gateway, ProductMapper product_mapper)
        {
            this.gateway = gateway;
            this.product_mapper = product_mapper;
        }

        public IEnumerable<Product> get_products_for_department(int department_id)
        {
            var query = new Query("SELECT * FROM Products WHERE DepartmentID = " + department_id);
            return map_products_from(gateway.run(query));
        }

        public IEnumerable<Product> map_products_from(DataTable raw_results)
        {
            return raw_results.Select().Select(product_mapper.map_from);
        }
    }
}