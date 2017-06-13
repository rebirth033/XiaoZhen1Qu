namespace TianWen.Exceptions
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;

    internal class Class12 : IViewer
    {
        private readonly Exception exception_0;
        private readonly HttpContext httpContext_0;

        public Class12(HttpContext httpContext_1, Exception exception_1)
        {
            this.httpContext_0 = httpContext_1;
            this.exception_0 = exception_1;
        }

        public string method_0(Exception exception_1)
        {
            string str = "";
            for (Exception exception = exception_1; exception != null; exception = exception.InnerException)
            {
                if (exception.GetType() == typeof(TianWenException))
                {
                    str = str + "-->" + ((TianWenException) exception).Code;
                }
            }
            return str;
        }

        public void ShowMessage()
        {
            string s = "";
            Stream manifestResourceStream = base.GetType().Assembly.GetManifestResourceStream("TianWen.Exceptions.Error.htm");
            byte[] buffer = new byte[manifestResourceStream.Length];
            manifestResourceStream.Read(buffer, 0, buffer.Length);
            s = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Replace("<%TianWen_IMGAGEPATH%>", Settings.ImagePath).Replace("<%TianWen_CODE%>", this.method_0(this.exception_0)).Replace("<%TianWen_URL%>", this.httpContext_0.Request.Url.ToString()).Replace("<%TianWen_MESSAGE%>", this.exception_0.Message.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />")).Replace("<%TianWen_SOURCE%>", this.exception_0.Source.Replace("\r\n", "<br />")).Replace("<%TianWen_STACKTRACE%>", PubFunction.GetChildException(this.exception_0, true, "ExDiv", 1).Replace("\r\n", "<br />"));
            this.httpContext_0.Response.Write(s);
            this.httpContext_0.Response.End();
        }
    }
}

