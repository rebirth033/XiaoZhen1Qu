namespace TianWen.Framework.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class StringKVItem : IKVListItem
    {
        public StringKVItem()
        {
        }

        public StringKVItem(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }

        public string KVKey
        {
            get
            {
                return this.Key;
            }
        }

        public string Value { get; set; }
    }
}

