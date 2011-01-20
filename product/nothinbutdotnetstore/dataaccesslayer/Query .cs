using System.Data;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class Query
    {
        string original_query;

        public Query(string original_query)
        {
            this.original_query = original_query;
        }

        public static implicit operator string(Query query)
        {
            return query.ToString();
        }

        public void prepare(IDbCommand command_to_prepare)
        {
            command_to_prepare.CommandType = CommandType.Text;
            command_to_prepare.CommandText = this.original_query;
        }

        public override string ToString()
        {
            return original_query;
        }
    }
}