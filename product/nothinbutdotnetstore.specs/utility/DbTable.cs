using System;

namespace nothinbutdotnetstore.specs.utility
{
    public class DbTable
    {
        public string table_name { get; set; }

        public DbTable(string table_name)
        {
            this.table_name = table_name;
        }

        public string all_query()
        {
            return String.Format("SELECT * FROM {0}", table_name);
        }
    }
}