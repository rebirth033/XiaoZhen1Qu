namespace TianWen.Framework.Exceptions.Viewer
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using TianWen.Framework.Exceptions;

    internal class TianWenExceptionViewer : IViewer
    {
        private HttpContext _Context;
        private TianWenException _TianWenException;

        public TianWenExceptionViewer(HttpContext context, TianWenException TianWenException)
        {
            this._Context = context;
            this._TianWenException = TianWenException;
        }

        public void Show()
        {
            string s = "";
            Stream manifestResourceStream = base.GetType().Assembly.GetManifestResourceStream("Top.Framework.Exceptions.Error.htm");
            byte[] buffer = new byte[manifestResourceStream.Length];
            manifestResourceStream.Read(buffer, 0, buffer.Length);
            s = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Replace("<%TianWen_CODE%>", "[" + this._TianWenException.Code + "]").Replace("<%TianWen_URL%>", this._Context.Request.Url.ToString()).Replace("<%TianWen_MESSAGE%>", this._TianWenException.Message.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />")).Replace("<%TianWen_SOURCE%>", this._TianWenException.Source.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />")).Replace("<%TianWen_STACKTRACE%>", PubFunction.GetChildException(this._TianWenException, true, "ExDiv", 1)).Replace("<%TianWen_SOLUTION%>", string.IsNullOrEmpty(this._TianWenException.Solution) ? "" : this._TianWenException.Solution.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />"));
            this._Context.Response.Write(s);
            this._Context.Response.End();
        }
    }
}

