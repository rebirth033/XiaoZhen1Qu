namespace TianWen.Exceptions
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;

    internal class Class13 : IViewer
    {
        private readonly HttpContext httpContext_0;
        private readonly TianWenException TianWenException_0;

        public Class13(HttpContext httpContext_1, TianWenException TianWenException_1)
        {
            this.httpContext_0 = httpContext_1;
            this.TianWenException_0 = TianWenException_1;
        }

        public void ShowMessage()
        {
            string s = "";
            Stream manifestResourceStream = base.GetType().Assembly.GetManifestResourceStream("TianWen.Exceptions.Error.htm");
            byte[] buffer = new byte[manifestResourceStream.Length];
            manifestResourceStream.Read(buffer, 0, buffer.Length);
            s = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Replace("<%TianWen_IMGAGEPATH%>", Settings.ImagePath).Replace("<%TianWen_CODE%>", "[" + this.TianWenException_0.Code + "]").Replace("<%TianWen_URL%>", this.httpContext_0.Request.Url.ToString()).Replace("<%TianWen_MESSAGE%>", this.TianWenException_0.Message.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />")).Replace("<%TianWen_SOURCE%>", this.TianWenException_0.Source.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />")).Replace("<%TianWen_STACKTRACE%>", PubFunction.GetChildException(this.TianWenException_0, true, "ExDiv", 1)).Replace("<%TianWen_SOLUTION%>", string.IsNullOrEmpty(this.TianWenException_0.Solution) ? "" : this.TianWenException_0.Solution.Replace("\r\n", "<br />").Replace(@"\r\n", "<br />"));
            this.httpContext_0.Response.Write(s);
            this.httpContext_0.Response.End();
        }
    }
}

