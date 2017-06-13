namespace TianWen.Exceptions
{
    using System;

    public class ConfigHelp : IConfigHelp
    {
        private readonly string string_0;

        public ConfigHelp(string _ConfigHelpType)
        {
            this.string_0 = _ConfigHelpType;
        }

        public ExceptionConfig Find(string code)
        {
            code = (code.StartsWith("TianWen") ? "" : "TianWen") + code;
            ExceptionConfig config = null;
            string str = this.string_0;
            if (str != null)
            {
                if (!(str == "FileConfigHelp"))
                {
                    if (str == "DbConfigHelp")
                    {
                        config = new Class10().Find(code);
                    }
                }
                else
                {
                    config = new Class10().Find(code);
                }
            }
            if (config == null)
            {
                config = new AssemblyConfigHelp().Find(code);
            }
            return config;
        }
    }
}

