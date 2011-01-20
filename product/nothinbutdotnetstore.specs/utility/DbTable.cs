using System;
using nothinbutdotnetstore.dataaccesslayer;

namespace nothinbutdotnetstore.specs.utility
{
    public class DbTable
    {
        public string table_name { get; set; }

        public DbTable(string table_name)
        {
            this.table_name = table_name;
        }

        public Query all_query()
        {
            return new Query(String.Format("SELECT * FROM {0}", table_name));
        }
    }
}