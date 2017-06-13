namespace TianWen.Framework.Common
{
    using System;
    using System.Reflection;
    using TianWen.Framework.Common.Attributes;

    public class DtoChanger
    {
        private void Change(object obj1, object obj2, bool IsToDTO)
        {
            Type type = obj1.GetType();
            Type type2 = obj2.GetType();
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (info.GetValue(obj1, null) != null)
                {
                    JumpAttribute customAttribute = (JumpAttribute) Attribute.GetCustomAttribute(info, typeof(JumpAttribute));
                    if (customAttribute == null)
                    {
                        PropertyInfo property = type2.GetProperty(info.Name);
                        if ((property != null) || info.PropertyType.IsGenericType)
                        {
                            if (info.PropertyType.IsGenericType)
                            {
                                if (IsToDTO)
                                {
                                    property = type2.GetProperty(info.Name.Replace("s", "_DTOs"));
                                }
                                else
                                {
                                    property = type2.GetProperty(info.Name.Replace("_DTOs", "s"));
                                }
                                if (property != null)
                                {
                                    object target = info.GetValue(obj1, null);
                                    object obj4 = property.GetValue(obj2, null);
                                    Type type3 = target.GetType();
                                    int num = int.Parse(type3.InvokeMember("Count", BindingFlags.GetProperty, null, target, null).ToString());
                                    Type type4 = property.PropertyType.GetGenericArguments()[0];
                                    for (int i = 0; i < num; i++)
                                    {
                                        object obj5 = type3.InvokeMember("Item", BindingFlags.GetProperty, null, target, new object[] { i });
                                        object obj6 = Activator.CreateInstance(type4);
                                        this.Change(obj5, obj6, IsToDTO);
                                        if (IsToDTO)
                                        {
                                            property.PropertyType.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance).Invoke(obj4, new object[] { obj6 });
                                        }
                                        else
                                        {
                                            property.PropertyType.GetMethod("Insert", BindingFlags.Public | BindingFlags.Instance).Invoke(obj4, new object[] { i, obj6 });
                                        }
                                    }
                                }
                            }
                            else
                            {
                                property.SetValue(obj2, info.GetValue(obj1, null), null);
                            }
                        }
                    }
                }
            }
        }

        public T ChangeToDTO<T>(object obj)
        {
            object obj2 = Activator.CreateInstance(typeof(T));
            this.Change(obj, obj2, true);
            return (T) obj2;
        }

        public T ChangeToModel<T>(object obj)
        {
            object obj2 = Activator.CreateInstance(typeof(T));
            this.Change(obj, obj2, false);
            this.SetParent(obj2, null);
            return (T) obj2;
        }

        private void SetParent(object obj, object Parent)
        {
            foreach (PropertyInfo info in obj.GetType().GetProperties())
            {
                if (info.PropertyType.IsGenericType)
                {
                    object target = info.GetValue(obj, null);
                    Type type = target.GetType();
                    int num = int.Parse(type.InvokeMember("Count", BindingFlags.GetProperty, null, target, null).ToString());
                    for (int i = 0; i < num; i++)
                    {
                        object obj3 = type.InvokeMember("Item", BindingFlags.GetProperty, null, target, new object[] { i });
                        this.SetParent(obj3, obj);
                    }
                }
                else if ((Parent != null) && (info.PropertyType == Parent.GetType()))
                {
                    info.SetValue(obj, Parent, null);
                }
            }
        }
    }
}

