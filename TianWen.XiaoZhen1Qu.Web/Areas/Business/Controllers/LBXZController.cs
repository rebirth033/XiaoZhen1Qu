using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LBXZController : BaseController
    {
        public ILBXXBLL LBXXBLL { get; set; }

        public ActionResult LBXZ()
        {
            return View();
        }

        public JsonResult LoadDL()
        {
            return Json(LBXXBLL.LoadDL());
        }

        public JsonResult LoadXL()
        {
            string CODEID = Request["CODEID"];
            return Json(LBXXBLL.LoadXL(CODEID));
        }
    }
}