namespace TianWen.Framework.Exceptions.DescriptionHelper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    using TianWen.Framework.Exceptions;

    internal class AssemblyDescriptionHelper : IDescriptionHelper
    {
        public ExceptionDescription FindDescription(string Code)
        {
            Stream manifestResourceStream = Assembly.Load("Top.Framework.Exceptions").GetManifestResourceStream("Top.Framework.Exceptions.ExceptionDescription." + Code.Substring(3, 5) + ".config");
            List<ExceptionDescription> list = new List<ExceptionDescription>();
            if (manifestResourceStream != null)
            {
                XmlSerializer serializer = new XmlSerializer(list.GetType());
                list = (List<ExceptionDescription>) serializer.Deserialize(manifestResourceStream);
            }
            foreach (ExceptionDescription description in list)
            {
                if (description.Code == Code)
                {
                    return description;
                }
            }
            return null;
        }
    }
}

