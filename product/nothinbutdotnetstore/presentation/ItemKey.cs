using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.presentation
{
    public class ItemKey<ValueType>
    {
        string key_name;

        public ItemKey(string key_name)
        {
            this.key_name = key_name;
        }

        public static implicit operator string(ItemKey<ValueType> item_key)
        {
            return item_key.ToString();
        }

        public override string ToString()
        {
            return key_name;
        }

        public ValueType map_from(NameValueCollection payload)
        {
            return (ValueType) Convert.ChangeType(payload[key_name], typeof(ValueType));
        }
    }
}