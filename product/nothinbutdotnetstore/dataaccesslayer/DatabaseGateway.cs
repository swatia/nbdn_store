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

        public DataTable execute_query(string query)
        {
            using (var connection = connection_factory.create())
            using (var select_command = create_command_using(connection, query))
            using (var reader = select_command.ExecuteReader())
            {
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        IDbCommand create_command_using(IDbConnection connection, string query)
        {
            var command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            return command;
        }
    }
}