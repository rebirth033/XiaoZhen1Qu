using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FBCGController : BaseController
    {
        public ActionResult FBCG()
        {
            return View();
        }

        public ActionResult CreateQrCode()
        {
            string str = "君临天华B区5号楼单身公寓一套";
            using (var memoryStream = QRCodeHelper.GetQRCode(str))
            {
                Response.ContentType = "image/jpeg";
                Response.OutputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                Response.End();
            }
            return null;
        }
    }
}