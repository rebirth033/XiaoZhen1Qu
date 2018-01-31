using System.Web;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Ashx
{
    /// <summary>
    /// GenerateQRCode 的摘要说明
    /// </summary>
    public class GenerateQRCode : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(CreateCode(context));
        }

        //生成二维码方法一
        private string CreateCode(HttpContext context)
        {
            string data = context.Request["qrdata"];
            return QRCodeHelper.GetQRCodeImage(data);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}