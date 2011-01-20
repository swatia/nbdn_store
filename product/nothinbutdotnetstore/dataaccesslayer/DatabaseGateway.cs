using System;
using System.Data;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class DatabaseGateway
    {
        public DatabaseGateway(IDbConnection connection)
        {
        }

        public DataTable execute_query(string command)
        {
            throw new NotImplementedException();
        }
    }
}