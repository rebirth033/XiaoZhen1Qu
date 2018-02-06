using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYLCXController : BaseController
    {
        public IXXYLCXBLL XXYLCXBLL { get; set; }
        public ActionResult XXYLCX_YDJS() { GetSession(); return View(); }
        public ActionResult XXYLCX_YDJB() { GetSession(); return View(); }
        public ActionResult XXYLCX_KTV() { GetSession(); return View(); }
        public ActionResult XXYLCX_HW() { GetSession(); return View(); }
        public ActionResult XXYLCX_XYWQ() { GetSession(); return View(); }
        public ActionResult XXYLCX_ZLAM() { GetSession(); return View(); }
        public ActionResult XXYLCX_TQT() { GetSession(); return View(); }
        public ActionResult XXYLCX_QPZY() { GetSession(); return View(); }
        public ActionResult XXYLCX_DIYSGF() { GetSession(); return View(); }
        public ActionResult XXYLCX_HPG() { GetSession(); return View(); }

        public JsonResult LoadXXYLXX()
        {
            return Json(XXYLCXBLL.LoadXXYLXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"], Session["XZQDM"].ToString()));
        }
    }
}