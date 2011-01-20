using System.Data;

namespace nothinbutdotnetstore.dataaccesslayer.stubs
{
    public class StubDatabaseGateway : DatabaseGateway
    {
        public DataTable run(Query query)
        {
            return ObjectMother.database_items.create_table_of_customers(
                ObjectMother.ReportingModels.create_customers(200));
        }
    }
}