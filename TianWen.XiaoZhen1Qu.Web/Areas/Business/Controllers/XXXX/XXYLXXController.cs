using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYLXXController : BaseController
    {
        public IXXYLCXBLL XXYLCXBLL { get; set; }
        public ActionResult XXYLXX_YDJS() { GetSession(); return View(); }
        public ActionResult XXYLXX_YDJB() { GetSession(); return View(); }
        public ActionResult XXYLXX_KTV() { GetSession(); return View(); }
        public ActionResult XXYLXX_HW() { GetSession(); return View(); }
        public ActionResult XXYLXX_XYWQ() { GetSession(); return View(); }
        public ActionResult XXYLXX_ZLAM() { GetSession(); return View(); }
        public ActionResult XXYLXX_TQT() { GetSession(); return View(); }
        public ActionResult XXYLXX_QPZY() { GetSession(); return View(); }
        public ActionResult XXYLXX_DIYSGF() { GetSession(); return View(); }
        public ActionResult XXYLXX_HPG() { GetSession(); return View(); }

        public JsonResult LoadXXYLXX()
        {
            return Json(XXYLCXBLL.LoadXXYLXX(Request["TYPE"], Request["ID"]));
        }
    }
}