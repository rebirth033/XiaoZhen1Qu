namespace TianWen.Exceptions
{
    using System;

    public interface IModule
    {
        void Run(TianWenException TianWenException);
    }
}

