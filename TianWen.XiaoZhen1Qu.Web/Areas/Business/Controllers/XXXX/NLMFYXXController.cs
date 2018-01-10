using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFYXXController : BaseController
    {
        public INLMFYCXBLL NLMFYCXBLL { get; set; }
        public ActionResult NLMFYXX_YLHH() { GetSession(); return View(); }
        public ActionResult NLMFYXX_NZW() { GetSession(); return View(); }
        public ActionResult NLMFYXX_DZWZM() { GetSession(); return View(); }
        public ActionResult NLMFYXX_CQYZ() { GetSession(); return View(); }
        public ActionResult NLMFYXX_SC() { GetSession(); return View(); }
        public ActionResult NLMFYXX_FLNY() { GetSession(); return View(); }
        public ActionResult NLMFYXX_SLSY() { GetSession(); return View(); }
        public ActionResult NLMFYXX_NJJSB() { GetSession(); return View(); }
        public ActionResult NLMFYXX_NCPJG() { GetSession(); return View(); }

        public JsonResult LoadNLMFYXX()
        {
            return Json(NLMFYCXBLL.LoadNLMFYXX(Request["TYPE"], Request["ID"]));
        }
    }
}