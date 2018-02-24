namespace TianWen.Framework.Exceptions
{
    using System;

    public interface IDescriptionHelper
    {
        ExceptionDescription FindDescription(string Code);
    }
}

