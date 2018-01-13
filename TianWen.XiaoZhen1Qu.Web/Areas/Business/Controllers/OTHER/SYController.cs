using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SYController : BaseController
    {
        public ISYBLL SYBLL { get; set; }

        public ActionResult SY() { GetSession(); return View(); }
        public ActionResult FCSY() { GetSession(); return View(); }
        public ActionResult CLSY() { GetSession(); return View(); }
        public ActionResult ZPSY() { GetSession(); return View(); }
        public ActionResult CWSY() { GetSession(); return View(); }
        public ActionResult ESSY() { GetSession(); return View(); }
        public ActionResult SHFWSY() { GetSession(); return View(); }
        public ActionResult SWFWSY() { GetSession(); return View(); }
        public ActionResult JYPXSY() { GetSession(); return View(); }
        public ActionResult ZSJMSY() { GetSession(); return View(); }
        public ActionResult PFCGSY() { GetSession(); return View(); }

        public JsonResult LoadZXFBXX()
        {
            return Json(SYBLL.LoadZXFBXX());
        }

        public JsonResult LoadLBByJCXX()
        {
            return Json(SYBLL.LoadLBByJCXX(Request["LBID"], Request["JCXXID"]));
        }

        public JsonResult LoadSY_ML()
        {
            return Json(SYBLL.LoadSY_ML(Session["XZQ"].ToString()));
        }

        public JsonResult LoadFCSY()
        {
            return Json(SYBLL.LoadFCSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }
    }
}