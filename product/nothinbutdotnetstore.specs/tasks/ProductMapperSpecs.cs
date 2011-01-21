using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    public class ProductMapperSpecs
    {
        public class when_mapping_a_product_from_a_product_row_and_all_the_necessary_information_is_present
        {
            [Test]
            public void should_populate_the_product_with_the_correct_details()
            {
                var data_table = ObjectMother.database_items.create_table_of_products();
                var sut = new ProductMapper();
                var result = sut.map_from(data_table.Rows[0]);

                Assert.AreEqual("Field Tomatoes sold by the pound, approx. 2 per pound", result.Name);
                StringAssert.StartsWith("Imported\r\nNutrition Information", result.Description);
                Assert.AreEqual(1.98, result.Price);
            }
        }
    }
}