using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFYXXController : BaseController
    {
        public INLMFYCXBLL NLMFYCXBLL { get; set; }
        public ActionResult NLMFYXX_YLHH() { return View(); }
        public ActionResult NLMFYXX_NZW() { return View(); }
        public ActionResult NLMFYXX_DZWZM() { return View(); }
        public ActionResult NLMFYXX_CQYZ() { return View(); }
        public ActionResult NLMFYXX_SC() { return View(); }
        public ActionResult NLMFYXX_FLNY() { return View(); }
        public ActionResult NLMFYXX_SLSY() { return View(); }
        public ActionResult NLMFYXX_NJJSB() { return View(); }
        public ActionResult NLMFYXX_NCPJG() { return View(); }

        public JsonResult LoadNLMFYXX()
        {
            return Json(NLMFYCXBLL.LoadNLMFYXX(Request["TYPE"], Request["ID"]));
        }
    }
}