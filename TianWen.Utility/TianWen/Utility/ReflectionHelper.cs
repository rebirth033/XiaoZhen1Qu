namespace TianWen.Utility
{
    using System;
    using System.Reflection;

    public class ReflectionHelper
    {
        public static ReflectionHelperExceptionHandler ReflectionHelperException;

        public static FieldInfo GetObjectFieldInfo(ref object reflectionObj, string fieldName)
        {
            try
            {
                return reflectionObj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            }
            catch (ReflectionTypeLoadException exception)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetObjectFieldInfo(ref object reflectionObj, string fieldName)", exception.Message);
                }
                return null;
            }
        }

        public static FieldInfo[] GetObjectFieldInfoList(ref object reflectionObj)
        {
            return reflectionObj.GetType().GetFields();
        }

        public static FieldInfo[] GetObjectFieldInfoList(ref object reflectionObj, BindingFlags flagArgs)
        {
            return reflectionObj.GetType().GetFields(flagArgs);
        }

        public static PropertyInfo GetObjectPropertyInfo(ref object reflectionObj, string propertyName)
        {
            try
            {
                return reflectionObj.GetType().GetProperty(propertyName);
            }
            catch (ReflectionTypeLoadException exception)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetObjectPropertyInfo(ref object reflectionObj, string propertyName)", exception.Message);
                }
                return null;
            }
        }

        public static PropertyInfo[] GetObjectPropertyInfoList(ref object reflectionObj)
        {
            return reflectionObj.GetType().GetProperties();
        }

        public static PropertyInfo[] GetObjectPropertyInfoList(ref object reflectionObj, BindingFlags flagArgs)
        {
            return reflectionObj.GetType().GetProperties(flagArgs);
        }

        public static string GetReflectionField(ref object reflectionObj, string fieldName)
        {
            try
            {
                return reflectionObj.GetType().GetField(fieldName).GetValue(reflectionObj).ToString();
            }
            catch (ReflectionTypeLoadException exception)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetReflectionField(ref object reflectionObj, string fieldName)", exception.Message);
                }
                return string.Empty;
            }
        }

        public static object GetReflectionObject(string assemblyName, string ojbFullName)
        {
            return Assembly.Load(assemblyName).CreateInstance(ojbFullName);
        }

        public static object GetReflectionProperty(ref object reflectionObj, string propertyName)
        {
            try
            {
                return reflectionObj.GetType().GetProperty(propertyName).GetValue(reflectionObj, null);
            }
            catch (ReflectionTypeLoadException exception)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetReflectionProperty(ref object reflectionObj,string propertyName)", exception.Message);
                }
                return null;
            }
        }

        public static string GetReflectionPropertyValue(ref object reflectionObj, string propertyName)
        {
            try
            {
                return reflectionObj.GetType().GetProperty(propertyName).GetValue(reflectionObj, null).ToString();
            }
            catch (ReflectionTypeLoadException exception)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetReflectionPropertyValue(ref object reflectionObj, string propertyName)", exception.Message);
                }
                return string.Empty;
            }
        }

        public static void SetFieldValue(ref object reflectionObj, ref FieldInfo field, object fieldValue)
        {
            if (field != null)
            {
                field.SetValue(reflectionObj, Convert.ChangeType(fieldValue, field.FieldType));
            }
        }

        public static void SetFieldValue(ref object reflectionObj, string fieldName, object fieldValue)
        {
            FieldInfo objectFieldInfo = GetObjectFieldInfo(ref reflectionObj, fieldName);
            if (objectFieldInfo != null)
            {
                objectFieldInfo.SetValue(reflectionObj, Convert.ChangeType(fieldValue, objectFieldInfo.FieldType));
            }
        }

        public static void SetPropertyValue(ref object reflectionObj, ref PropertyInfo propertyInfo_0, object propertyValue)
        {
            if (propertyInfo_0 != null)
            {
                propertyInfo_0.SetValue(reflectionObj, Convert.ChangeType(propertyValue, propertyInfo_0.PropertyType), null);
            }
        }

        public static void SetPropertyValue(ref object reflectionObj, string propertyName, object propertyValue)
        {
            PropertyInfo objectPropertyInfo = GetObjectPropertyInfo(ref reflectionObj, propertyName);
            if (objectPropertyInfo != null)
            {
                objectPropertyInfo.SetValue(reflectionObj, Convert.ChangeType(propertyValue, objectPropertyInfo.PropertyType), null);
            }
        }
    }
}

