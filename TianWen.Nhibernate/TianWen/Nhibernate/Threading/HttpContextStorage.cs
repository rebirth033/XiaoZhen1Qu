namespace TianWen.Nhibernate.Threading
{
    using System;
    using System.Web;

    public class HttpContextStorage : IThreadStorage
    {
        public void FreeNamedDataSlot(string name)
        {
            HttpContext.Current.Items.Remove(name);
        }

        public object GetData(string name)
        {
            return HttpContext.Current.Items[name];
        }

        public void SetData(string name, object value)
        {
            HttpContext.Current.Items[name] = value;
        }
    }
}

