using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYLXXController : BaseController
    {
        public IXXYLCXBLL XXYLCXBLL { get; set; }
        public ActionResult XXYLXX_YDJS() { return View(); }
        public ActionResult XXYLXX_YDJB() { return View(); }
        public ActionResult XXYLXX_HW() { return View(); }
        public ActionResult XXYLXX_XYWQ() { return View(); }
        public ActionResult XXYLXX_ZLAM() { return View(); }
        public ActionResult XXYLXX_TQT() { return View(); }
        public ActionResult XXYLXX_QPZY() { return View(); }
        public ActionResult XXYLXX_DIYSFG() { return View(); }
        public ActionResult XXYLXX_HPG() { return View(); }

        public JsonResult LoadXXYLXX()
        {
            return Json(XXYLCXBLL.LoadXXYLXX(Request["TYPE"], Request["ID"]));
        }
    }
}