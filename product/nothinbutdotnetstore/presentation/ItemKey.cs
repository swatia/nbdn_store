using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.presentation
{
    public class ItemKey
    {
        string key_name;

        public ItemKey(string key_name)
        {
            this.key_name = key_name;
        }

        public static implicit operator string(ItemKey item_key)
        {
            return item_key.key_name;
        }

        public object map_from(NameValueCollection payload)
        {
            throw new NotImplementedException();
        }
    }
}