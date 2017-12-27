using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFYCXController : BaseController
    {
        public INLMFYCXBLL NLMFYCXBLL { get; set; }
        public ActionResult NLMFYCX_YLHH() { GetSession(); return View(); }
        public ActionResult NLMFYCX_NZW() { GetSession(); return View(); }
        public ActionResult NLMFYCX_DZWZM() { GetSession(); return View(); }
        public ActionResult NLMFYCX_CQYZ() { GetSession(); return View(); }
        public ActionResult NLMFYCX_SC() { GetSession(); return View(); }
        public ActionResult NLMFYCX_FLNY() { GetSession(); return View(); }
        public ActionResult NLMFYCX_SLSY() { GetSession(); return View(); }
        public ActionResult NLMFYCX_NJJSB() { GetSession(); return View(); }
        public ActionResult NLMFYCX_NCPJG() { GetSession(); return View(); }


        public JsonResult LoadNLMFYXX()
        {
            return Json(NLMFYCXBLL.LoadNLMFYXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"]));
        }
    }
}