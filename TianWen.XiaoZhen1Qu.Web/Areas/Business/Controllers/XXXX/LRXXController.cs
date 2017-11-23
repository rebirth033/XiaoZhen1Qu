using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LRXXController : BaseController
    {
        public ILRCXBLL LRCXBLL { get; set; }
        public ActionResult LRXX_MTSS() { return View(); }
        public ActionResult LRXX_MRHF() { return View(); }
        public ActionResult LRXX_SPA() { return View(); }
        public ActionResult LRXX_WD() { return View(); }
        public ActionResult LRXX_YJ() { return View(); }
        public ActionResult LRXX_MFHF() { return View(); }
        public ActionResult LRXX_MJ() { return View(); }
        public ActionResult LRXX_WS() { return View(); }
        public ActionResult LRXX_KQHL() { return View(); }
        public ActionResult LRXX_TJ() { return View(); }

        public JsonResult LoadLRXX()
        {
            return Json(LRCXBLL.LoadLRXX(Request["TYPE"], Request["ID"]));
        }
    }
}