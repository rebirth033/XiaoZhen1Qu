namespace TianWen.Framework.Common
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class KVList<T> : List<T> where T: IKVListItem
    {
        public virtual void Add(T item)
        {
            if (this.Exist(item.KVKey))
            {
                throw new Exception("NamedList元素的键值Name重复");
            }
            base.Add(item);
        }

        public bool Exist(string key)
        {
            return (this.GetItem(key) != null);
        }

        public T GetItem(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                foreach (T local in this)
                {
                    if (key.ToLower().Equals(local.KVKey.ToLower()))
                    {
                        return local;
                    }
                }
            }
            return default(T);
        }

        public int IndexOf(string key)
        {
            for (int i = 0; i < base.Count; i++)
            {
                T local = base[i];
                if (local.KVKey.ToLower() == key.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        public bool RemoveItem(string key)
        {
            return base.Remove(this.GetItem(key));
        }

        public T this[string key]
        {
            get
            {
                return this.GetItem(key);
            }
            set
            {
                int index = this.IndexOf(key);
                if (index >= 0)
                {
                    base[index] = value;
                }
                else
                {
                    base.Add(value);
                }
            }
        }
    }
}

