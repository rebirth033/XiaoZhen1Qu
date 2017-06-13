namespace TianWen.Plus4MEF
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal interface Interface0
    {
        T GetComponent<T>(string componentName);
        void LoadPlusin(Assembly assembly_0);
        void LoadPlusin(string path = ".", string searchPattern = "*.dll");
        void RemoveComponent<T>(string componentName);
    }
}

