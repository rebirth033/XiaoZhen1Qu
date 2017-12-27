using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJCCXController : BaseController
    {
        public IZXJCCXBLL ZXJCCXBLL { get; set; }
        public ActionResult ZXJCCX_JZFW() { GetSession(); return View(); }
        public ActionResult ZXJCCX_GZFW() { GetSession(); return View(); }
        public ActionResult ZXJCCX_FWGZ() { GetSession(); return View(); }
        public ActionResult ZXJCCX_JC() { GetSession(); return View(); }
        public ActionResult ZXJCCX_JJ() { GetSession(); return View(); }
        public ActionResult ZXJCCX_JFJS() { GetSession(); return View(); }

        public JsonResult LoadZXJCXX()
        {
            return Json(ZXJCCXBLL.LoadZXJCXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"]));
        }
    }
}