using System;
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

        public void apply_to(IDbCommand command_to_populate)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return original_query;
        }
    }
}