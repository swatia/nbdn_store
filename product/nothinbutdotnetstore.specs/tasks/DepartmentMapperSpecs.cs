using System.Linq;
using nothinbutdotnetstore.dataaccesslayer;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    public class DepartmentMapperSpecs
    {
        public class when_mapping_a_customer_from_a_customer_row_and_all_the_necessary_information_is_present
        {
            [Test]
            public void should_populate_the_customer_with_the_correct_details()
            {
                var customers = ObjectMother.ReportingModels.create_department(1).ToList();

                var data_table = ObjectMother.database_items.create_table_of_departments(customers);

                var sut = new DepartmentMapper();
                var result = sut.map_from(data_table.Rows[0]);
                is_equal(customers[0], result);
            }

            void is_equal(Department expected, Department actual)
            {
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Id, actual.Id);
            }
        }
    }
}