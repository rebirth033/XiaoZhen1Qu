namespace TianWen.Exceptions
{
    using System;
    using System.Web;

    public class Settings
    {
        private static bool? nullable_0;
        private static string string_0;
        private static string string_1;
        private static string string_2;
        private static string string_3;
        private static string string_4;

        public static string ConfigHelpType
        {
            get
            {
                return (string_1 ?? (string_1 = PubFunction.GetCustomSectionValue<string>("TianWen/Exception", "ConfigHelpType", "")));
            }
        }

        public static string ErrorPagePath
        {
            get
            {
                return (string_2 ?? (string_2 = PubFunction.GetCustomSectionValue<string>("TianWen/Exception", "ErrorPagePath", "")));
            }
        }

        public static string ExceptionConfigFilePath
        {
            get
            {
                return (string_0 ?? (string_0 = PubFunction.GetCustomSectionValue<string>("TianWen/Exception", "ExceptionConfigFilePath", "")));
            }
        }

        public static string ImagePath
        {
            get
            {
                return (string_4 ?? (string_4 = PubFunction.GetCustomSectionValue<string>("TianWen/Exception", "ImagePath", "/" + HttpContext.Current.Request.ApplicationPath + "JsHtcCss/Error/images")));
            }
        }

        public static bool IsWriteLog
        {
            get
            {
                bool? nullable = nullable_0;
                bool? nullable2 = nullable.HasValue ? new bool?(nullable.GetValueOrDefault()) : (nullable_0 = new bool?(PubFunction.GetCustomSectionValue<bool>("TianWen/Exception", "IsWriteLog", true)));
                return nullable2.Value;
            }
        }

        public static string LogPath
        {
            get
            {
                return (string_3 ?? (string_3 = PubFunction.GetCustomSectionValue<string>("TianWen/Exception", "LogPath", "")));
            }
        }
    }
}

