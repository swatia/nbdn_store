using System.Data;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class DatabaseGateway
    {
        public DatabaseGateway(DatabaseConnectionFactory connection_factory)
        {
        }

        public DataTable execute_query(string command)
        {
            return new DataTable();
        }
    }
}