namespace TianWen.Interface
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class EnvironmentVar
    {
        [CompilerGenerated]
        private static bool bool_0;
        private const string string_0 = "temporary asp.net files";
        private static string string_1;

        public static string ApplicationBin
        {
            get
            {
                return Path.Combine(ApplicationPath, (IsSvc || !NoWeb) ? "bin" : "");
            }
        }

        private static string applicationPath
        {
            get
            {
                string assemblyLocationPath = AssemblyLocationPath;
                assemblyLocationPath = assemblyLocationPath.Substring(0, assemblyLocationPath.LastIndexOf('\\'));
                if (NoWeb)
                {
                    IsSvc = assemblyLocationPath == AssemblyCodeBasePath;
                    assemblyLocationPath = AssemblyCodeBasePath;
                }
                return ((Environment.CurrentDirectory == assemblyLocationPath) ? Environment.CurrentDirectory : assemblyLocationPath);
            }
        }

        public static string ApplicationPath
        {
            get
            {
                return (NoWeb ? applicationPath : (IsSvc ? applicationPath : AssemblyCodeBasePath));
            }
        }

        private static string AssemblyCodeBasePath
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                if (codeBase.StartsWith("file:///"))
                {
                    codeBase = codeBase.Substring(8).Replace("/", @"\");
                }
                codeBase = codeBase.Substring(0, codeBase.LastIndexOf('\\'));
                if (!(NoWeb || !codeBase.EndsWith("bin")))
                {
                    codeBase = codeBase.Substring(0, codeBase.LastIndexOf("bin", StringComparison.CurrentCultureIgnoreCase));
                }
                return codeBase;
            }
        }

        private static string AssemblyLocationPath
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location.ToLower();
            }
        }

        public static string ConfigRootPath
        {
            get
            {
                return Path.Combine(ApplicationPath, "Configs");
            }
        }

        private static string IISVirtualPath
        {
            get
            {
                if (NoWeb)
                {
                    throw new NotImplementedException("当前非web模式，无法获取IIS虚拟路径");
                }
                string assemblyLocationPath = AssemblyLocationPath;
                int startIndex = (assemblyLocationPath.IndexOf("temporary asp.net files", StringComparison.CurrentCultureIgnoreCase) + "temporary asp.net files".Length) + 1;
                int index = assemblyLocationPath.IndexOf('\\', startIndex);
                return (string_1 = assemblyLocationPath.Substring(startIndex, index - startIndex).ToLower());
            }
        }

        private static bool IsSvc
        {
            [CompilerGenerated]
            get
            {
                return bool_0;
            }
            [CompilerGenerated]
            set
            {
                bool_0 = value;
            }
        }

        public static bool IsWindowService
        {
            get
            {
                return !Environment.UserInteractive;
            }
        }

        public static bool NoWeb
        {
            get
            {
                return (AssemblyLocationPath.IndexOf("temporary asp.net files", StringComparison.CurrentCultureIgnoreCase) <= 0);
            }
        }

        public static string VirtualPath
        {
            get
            {
                return (NoWeb ? "" : ('/' + (string_1 ?? IISVirtualPath) + '/'));
            }
        }
    }
}

