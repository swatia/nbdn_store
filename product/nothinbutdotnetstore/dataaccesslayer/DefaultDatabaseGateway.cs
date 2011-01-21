using System.Data;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public interface DatabaseGateway
    {
        DataTable run(Query query);
    }

    public class DefaultDatabaseGateway : DatabaseGateway
    {
        DatabaseConnectionFactory connection_factory;

        public DefaultDatabaseGateway():this(new DatabaseConnectionFactory(
            ))
        {
        }

        public DefaultDatabaseGateway(DatabaseConnectionFactory connection_factory)
        {
            this.connection_factory = connection_factory;
        }

        public DataTable run(Query query)
        {
            using (var connection = connection_factory.create())
            using (var command = connection.CreateCommand())
            {
                query.prepare(command);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
    }
}