using System.Data;
using System.Linq;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class DatabaseGateway
    {
        public DatabaseGateway(DatabaseConnectionFactory connection_factory)
        {
        }

        public DataTable execute_query(string command)
        {
            var data_table = new DataTable();
            data_table.Columns.Add("sdfsdf");
            Enumerable.Range(1, 4).ToList().ForEach(x => data_table.Rows.Add(data_table.NewRow()));
            return data_table;
        }
    }
}