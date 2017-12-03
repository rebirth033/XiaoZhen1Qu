using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPXXXController : BaseController
    {
        public IJYPXCXBLL JYPXCXBLL { get; set; }
        public ActionResult JYPXXX_ZXXFDB() { return View(); }
        public ActionResult JYPXXX_ZXXYDY() { return View(); }
        public ActionResult JYPXXX_JJJG() { return View(); }
        public ActionResult JYPXXX_JJGR() { return View(); }
        public ActionResult JYPXXX_YYPXJG() { return View(); }
        public ActionResult JYPXXX_YYPXJS() { return View(); }
        public ActionResult JYPXXX_YSPXJG() { return View(); }
        public ActionResult JYPXXX_YSPXJS() { return View(); }
        public ActionResult JYPXXX_ZYJNPX() { return View(); }
        public ActionResult JYPXXX_TYPXJG() { return View(); }
        public ActionResult JYPXXX_TYJL() { return View(); }
        public ActionResult JYPXXX_XLJY() { return View(); }
        public ActionResult JYPXXX_ITPX() { return View(); }
        public ActionResult JYPXXX_SJPX() { return View(); }
        public ActionResult JYPXXX_GLPX() { return View(); }
        public ActionResult JYPXXX_YYEJY() { return View(); }
        public ActionResult JYPXXX_LX() { return View(); }
        public ActionResult JYPXXX_YM() { return View(); }
        public ActionResult JYPXXX_PBPK() { return View(); }

        public JsonResult LoadJYPXXX()
        {
            return Json(JYPXCXBLL.LoadJYPXXX(Request["TYPE"], Request["ID"]));
        }
    }
}