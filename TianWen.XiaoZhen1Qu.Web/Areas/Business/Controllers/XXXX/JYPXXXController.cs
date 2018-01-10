using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPXXXController : BaseController
    {
        public IJYPXCXBLL JYPXCXBLL { get; set; }
        public ActionResult JYPXXX_ZXXFDB() { GetSession(); return View(); }
        public ActionResult JYPXXX_ZXXYDY() { GetSession(); return View(); }
        public ActionResult JYPXXX_JJJG() { GetSession(); return View(); }
        public ActionResult JYPXXX_JJGR() { GetSession(); return View(); }
        public ActionResult JYPXXX_YYPXJG() { GetSession(); return View(); }
        public ActionResult JYPXXX_YYPXJS() { GetSession(); return View(); }
        public ActionResult JYPXXX_YSPXJG() { GetSession(); return View(); }
        public ActionResult JYPXXX_YSPXJS() { GetSession(); return View(); }
        public ActionResult JYPXXX_ZYJNPX() { GetSession(); return View(); }
        public ActionResult JYPXXX_TYPXJG() { GetSession(); return View(); }
        public ActionResult JYPXXX_TYJL() { GetSession(); return View(); }
        public ActionResult JYPXXX_XLJY() { GetSession(); return View(); }
        public ActionResult JYPXXX_ITPX() { GetSession(); return View(); }
        public ActionResult JYPXXX_SJPX() { GetSession(); return View(); }
        public ActionResult JYPXXX_GLPX() { GetSession(); return View(); }
        public ActionResult JYPXXX_YYEJY() { GetSession(); return View(); }
        public ActionResult JYPXXX_LX() { GetSession(); return View(); }
        public ActionResult JYPXXX_YM() { GetSession(); return View(); }
        public ActionResult JYPXXX_PBPK() { GetSession(); return View(); }

        public JsonResult LoadJYPXXX()
        {
            return Json(JYPXCXBLL.LoadJYPXXX(Request["TYPE"], Request["ID"]));
        }
    }
}