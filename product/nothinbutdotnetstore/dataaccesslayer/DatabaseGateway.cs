using System.Data;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class DatabaseGateway
    {
        DatabaseConnectionFactory connection_factory;

        public DatabaseGateway(DatabaseConnectionFactory connection_factory)
        {
            this.connection_factory = connection_factory;
        }

        public DataTable execute_query(Query query)
        {
            using (var connection = connection_factory.create())
            using (var select_command = connection.CreateCommand())
            using (var reader = select_command.ExecuteReader())
            {
//                query.apply_to(select_command);
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
    }
}