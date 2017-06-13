namespace TianWen.Framework.Exceptions.Viewer
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using TianWen.Framework.Exceptions;

    public class DefaultViewer : IViewer
    {
        private HttpContext _Context;
        private Exception _Ex;

        public DefaultViewer(HttpContext context, Exception ex)
        {
            this._Context = context;
            this._Ex = ex;
        }

        private string GetCodeTree(Exception ex)
        {
            string str = "";
            for (Exception exception = ex; exception != null; exception = exception.InnerException)
            {
                if (exception.GetType() == typeof(TianWenException))
                {
                    str = str + "-->" + ((TianWenException) exception).Code;
                }
            }
            return str;
        }

        public void Show()
        {
            string s = "";
            Stream manifestResourceStream = base.GetType().Assembly.GetManifestResourceStream("Top.Framework.Exceptions.Error.htm");
            byte[] buffer = new byte[manifestResourceStream.Length];
            manifestResourceStream.Read(buffer, 0, buffer.Length);
            s = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Replace("<%TianWen_CODE%>", this.GetCodeTree(this._Ex)).Replace("<%TianWen_URL%>", this._Context.Request.Url.ToString()).Replace("<%TianWen_MESSAGE%>", this._Ex.Message.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />")).Replace("<%TianWen_SOURCE%>", this._Ex.Source.Replace("\r\n", "<br />")).Replace("<%TianWen_STACKTRACE%>", PubFunction.GetChildException(this._Ex, true, "ExDiv", 1).Replace("\r\n", "<br />")).Replace("<%TianWen_SOLUTION%>", "");
            this._Context.Response.Write(s);
            this._Context.Response.End();
        }
    }
}

