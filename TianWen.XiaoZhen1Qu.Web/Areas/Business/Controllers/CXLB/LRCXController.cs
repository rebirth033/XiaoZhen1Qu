using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LRCXController : BaseController
    {
        public ILRCXBLL LRCXBLL { get; set; }
        public ActionResult LRCX_MTSS() { GetSession(); return View(); }
        public ActionResult LRCX_MRHF() { GetSession(); return View(); }
        public ActionResult LRCX_SPA() { GetSession(); return View(); }
        public ActionResult LRCX_WD() { GetSession(); return View(); }
        public ActionResult LRCX_YJ() { GetSession(); return View(); }
        public ActionResult LRCX_MFHF() { GetSession(); return View(); }
        public ActionResult LRCX_MJ() { GetSession(); return View(); }
        public ActionResult LRCX_WS() { GetSession(); return View(); }
        public ActionResult LRCX_KQHL() { GetSession(); return View(); }
        public ActionResult LRCX_TJ() { GetSession(); return View(); }

        public JsonResult LoadLRXX()
        {
            return Json(LRCXBLL.LoadLRXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}