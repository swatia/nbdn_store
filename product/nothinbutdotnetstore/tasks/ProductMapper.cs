using System;
using System.Data;
using nothinbutdotnetstore.dataaccesslayer;

namespace nothinbutdotnetstore.tasks
{
    public class ProductMapper
    {
        public Product map_from(DataRow data_row)
        {
            return new Product()
            {
                Name = data_row["Name"].ToString(),
                Description = data_row["Description"].ToString(),
                Price = Decimal.Parse(data_row["Price"].ToString())
            };
        }
    }
}