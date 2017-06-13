namespace TianWen.Utility
{
    using System;
    using System.Runtime.InteropServices;

    public static class Cast
    {
        public static T GetEnum<T>(string value, T gparam_0)
        {
            object obj2 = null;
            try
            {
                obj2 = Enum.Parse(typeof(T), value);
            }
            catch
            {
                return gparam_0;
            }
            return To<T>(obj2, gparam_0);
        }

        public static T To<T>(object object_0, T gparam_0)
        {
            if (object_0 == null)
            {
                return gparam_0;
            }
            try
            {
                T objA = (T) Convert.ChangeType(object_0, typeof(T));
                return (object.Equals(objA, null) ? gparam_0 : objA);
            }
            catch
            {
                return gparam_0;
            }
        }
    }
}

