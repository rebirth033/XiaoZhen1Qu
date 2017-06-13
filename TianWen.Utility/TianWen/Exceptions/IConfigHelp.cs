namespace TianWen.Exceptions
{
    using System;

    public interface IConfigHelp
    {
        ExceptionConfig Find(string code);
    }
}

