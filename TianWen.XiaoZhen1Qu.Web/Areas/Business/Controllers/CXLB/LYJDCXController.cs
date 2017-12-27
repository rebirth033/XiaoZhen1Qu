using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJDCXController : BaseController
    {
        public ILYJDCXBLL LYJDCXBLL { get; set; }
        public ActionResult LYJDCX_LXS() { GetSession(); return View(); }
        public ActionResult LYJDCX_QZFW() { GetSession(); return View(); }
        public ActionResult LYJDCX_GNY() { GetSession(); return View(); }
        public ActionResult LYJDCX_ZBY() { GetSession(); return View(); }
        public ActionResult LYJDCX_CJY() { GetSession(); return View(); }
        public ActionResult LYJDCX_JDZSYD() { GetSession(); return View(); }
        public ActionResult LYJDCX_JP() { GetSession(); return View(); }
        public ActionResult LYJDCX_DYDDR() { GetSession(); return View(); }

        public JsonResult LoadLYJDXX()
        {
            return Json(LYJDCXBLL.LoadLYJDXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"]));
        }
    }
}