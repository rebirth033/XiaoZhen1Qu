using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LRXXController : BaseController
    {
        public ILRCXBLL LRCXBLL { get; set; }
        public ActionResult LRXX_MTSS() { GetSession(); return View(); }
        public ActionResult LRXX_MRHF() { GetSession(); return View(); }
        public ActionResult LRXX_SPA() { GetSession(); return View(); }
        public ActionResult LRXX_WD() { GetSession(); return View(); }
        public ActionResult LRXX_YJ() { GetSession(); return View(); }
        public ActionResult LRXX_MFHF() { GetSession(); return View(); }
        public ActionResult LRXX_MJ() { GetSession(); return View(); }
        public ActionResult LRXX_WS() { GetSession(); return View(); }
        public ActionResult LRXX_KQHL() { GetSession(); return View(); }
        public ActionResult LRXX_TJ() { GetSession(); return View(); }

        public JsonResult LoadLRXX()
        {
            return Json(LRCXBLL.LoadLRXX(Request["TYPE"], Request["ID"]));
        }
    }
}