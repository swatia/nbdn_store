using System;

namespace nothinbutdotnetstore.presentation
{
    public class ItemKey
    {
        string _keyName;
        public ItemKey(string key_name)
        {
            _keyName = key_name;
        }

        public static implicit operator string(ItemKey item_key)
        {
            return item_key._keyName;
        }

    }
}