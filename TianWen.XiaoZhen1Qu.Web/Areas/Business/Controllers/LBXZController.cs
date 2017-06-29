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
            string LBID = Request["LBID"];
            return Json(LBXXBLL.LoadXL(LBID));
        }

        public JsonResult LoadLBByID()
        {
            string LBID = Request["LBID"];
            return Json(LBXXBLL.LoadLBByID(LBID));
        }
    }
}