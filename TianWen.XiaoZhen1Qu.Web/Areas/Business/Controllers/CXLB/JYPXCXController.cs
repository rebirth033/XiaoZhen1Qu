using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPXCXController : BaseController
    {
        public IJYPXCXBLL JYPXCXBLL { get; set; }
        public ActionResult JYPXCX_ZXXFDB() { GetSession(); return View(); }
        public ActionResult JYPXCX_ZXXYDY() { GetSession(); return View(); }
        public ActionResult JYPXCX_JJJG() { GetSession(); return View(); }
        public ActionResult JYPXCX_JJGR() { GetSession(); return View(); }
        public ActionResult JYPXCX_YYPXJG() { GetSession(); return View(); }
        public ActionResult JYPXCX_YYPXJS() { GetSession(); return View(); }
        public ActionResult JYPXCX_YSPXJG() { GetSession(); return View(); }
        public ActionResult JYPXCX_YSPXJS() { GetSession(); return View(); }
        public ActionResult JYPXCX_ZYJNPX() { GetSession(); return View(); }
        public ActionResult JYPXCX_TYPXJG() { GetSession(); return View(); }
        public ActionResult JYPXCX_TYJL() { GetSession(); return View(); }
        public ActionResult JYPXCX_XLJY() { GetSession(); return View(); }
        public ActionResult JYPXCX_ITPX() { GetSession(); return View(); }
        public ActionResult JYPXCX_SJPX() { GetSession(); return View(); }
        public ActionResult JYPXCX_GLPX() { GetSession(); return View(); }
        public ActionResult JYPXCX_YYEJY() { GetSession(); return View(); }
        public ActionResult JYPXCX_LX() { GetSession(); return View(); }
        public ActionResult JYPXCX_YM() { GetSession(); return View(); }
        public ActionResult JYPXCX_PBPK() { GetSession(); return View(); }

        public JsonResult LoadJYPXXX()
        {
            return Json(JYPXCXBLL.LoadJYPXXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"]));
        }
    }
}