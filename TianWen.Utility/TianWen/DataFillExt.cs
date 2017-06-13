namespace TianWen
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class DataFillExt
    {
        public static T FillEnt<T>(this IDataReader idataReader_0, System.Action<IDataReader, T> fillFunc = null, Action<T> childAction = null, IDictionary<int, PropertyInfo> mapInfo = null, bool ignoreCase = true) where T: new()
        {
            T local = idataReader_0.smethod_0<T>(fillFunc, childAction, mapInfo, ignoreCase);
            idataReader_0.Close();
            return local;
        }

        public static IList<T> FillListEnt<T>(this IDataReader idataReader_0, System.Action<IDataReader, T> fillFunc = null, Action<T> childAction = null, bool onlyFirst = false, bool ignoreCase = true) where T: new()
        {
            IList<T> list = new List<T>();
            while (idataReader_0.Read())
            {
                T item = idataReader_0.smethod_0<T>(fillFunc, childAction, null, ignoreCase);
                list.Add(item);
                if (onlyFirst)
                {
                    break;
                }
            }
            idataReader_0.Close();
            return list;
        }

        public static NameValueCollection FillOne(this IDataReader idataReader_0)
        {
            if (!idataReader_0.Read())
            {
                idataReader_0.Close();
                return null;
            }
            NameValueCollection values2 = null;
            values2 = new NameValueCollection(idataReader_0.FieldCount);
            for (int i = 0; i < idataReader_0.FieldCount; i++)
            {
                values2.Add(idataReader_0.GetName(i), Convert.ToString(idataReader_0[i]));
            }
            idataReader_0.Close();
            return values2;
        }

        public static T FillOne<T>(this IDataReader idataReader_0, System.Action<IDataReader, T> fillFunc = null, Action<T> childAction = null, IDictionary<int, PropertyInfo> mapInfo = null, bool ignoreCase = true) where T: new()
        {
            IList<T> list = idataReader_0.FillListEnt<T>(fillFunc, childAction, true, ignoreCase);
            return ((list.Count > 0) ? list[0] : default(T));
        }

        private static T smethod_0<T>(this IDataReader idataReader_0, System.Action<IDataReader, T> action_0 = null, Action<T> action_1 = null, IDictionary<int, PropertyInfo> idictionary_0 = null, bool bool_0 = true) where T: new()
        {
            if (idataReader_0.IsClosed)
            {
                return default(T);
            }
            if (!((DbDataReader) idataReader_0).HasRows)
            {
                return default(T);
            }
            T local3 = new T();
            if (idictionary_0 == null)
            {
                idictionary_0 = idataReader_0.smethod_1(typeof(T), bool_0);
            }
            foreach (KeyValuePair<int, PropertyInfo> pair in idictionary_0)
            {
                object obj2 = idataReader_0[pair.Key];
                if (obj2 != DBNull.Value)
                {
                    pair.Value.SetValue(local3, Convert.ChangeType(obj2, pair.Value.PropertyType), null);
                }
            }
            if (action_0 != null)
            {
                action_0(idataReader_0, local3);
            }
            if (action_1 != null)
            {
                action_1(local3);
            }
            return local3;
        }

        private static IDictionary<int, PropertyInfo> smethod_1(this IDataReader idataReader_0, Type type_0, bool bool_0 = true)
        {
            Class18 class2 = new Class18 {
                bool_0 = bool_0
            };
            PropertyInfo[] properties = type_0.GetProperties();
            Dictionary<int, PropertyInfo> dictionary = new Dictionary<int, PropertyInfo>();
            for (int i = 0; i < idataReader_0.FieldCount; i++)
            {
                Class19 class3 = new Class19 {
                    class18_0 = class2,
                    string_0 = idataReader_0.GetName(i)
                };
                if (class2.bool_0)
                {
                    class3.string_0 = class3.string_0.ToUpper();
                }
                PropertyInfo info = Enumerable.FirstOrDefault<PropertyInfo>(properties, new System.Func<PropertyInfo, bool>(class3.method_0));
                if ((info != null) && info.CanWrite)
                {
                    dictionary.Add(i, info);
                }
            }
            return dictionary;
        }

        [CompilerGenerated]
        private sealed class Class18
        {
            public bool bool_0;
        }

        [CompilerGenerated]
        private sealed class Class19
        {
            public DataFillExt.Class18 class18_0;
            public string string_0;

            public bool method_0(PropertyInfo propertyInfo_0)
            {
                return ((this.class18_0.bool_0 ? propertyInfo_0.Name.ToUpper() : propertyInfo_0.Name) == this.string_0);
            }
        }
    }
}

