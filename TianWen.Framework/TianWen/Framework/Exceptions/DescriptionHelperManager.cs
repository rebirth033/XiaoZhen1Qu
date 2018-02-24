namespace TianWen.Framework.Exceptions
{
    using System;
    using System.Collections.Generic;
    using TianWen.Framework.Exceptions.DescriptionHelper;

    public class DescriptionHelperManager
    {
        private static Dictionary<string, IDescriptionHelper> _Helpers = new Dictionary<string, IDescriptionHelper>();

        public DescriptionHelperManager()
        {
            this.LoadHelpers();
        }

        public ExceptionDescription FindDescription(string Code)
        {
            ExceptionDescription description = null;
            foreach (IDescriptionHelper helper in _Helpers.Values)
            {
                description = helper.FindDescription(Code);
                if (description != null)
                {
                    return description;
                }
            }
            return null;
        }

        private void LoadHelpers()
        {
            if (_Helpers.Count == 0)
            {
                _Helpers.Add("FileDescriptionHelper", new FileDescriptionHelper());
                _Helpers.Add("AssemblyDescriptionHelper", new AssemblyDescriptionHelper());
            }
        }
    }
}

