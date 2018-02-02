using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJMXXController : BaseController
    {
        public IZSJMCXBLL ZSJMCXBLL { get; set; }
        public ActionResult ZSJMXX_CY() { GetSession(); return View(); }
        public ActionResult ZSJMXX_FZXB() { GetSession(); return View(); }
        public ActionResult ZSJMXX_JC() { GetSession(); return View(); }
        public ActionResult ZSJMXX_JX() { GetSession(); return View(); }
        public ActionResult ZSJMXX_MRBJ() { GetSession(); return View(); }
        public ActionResult ZSJMXX_LPSP() { GetSession(); return View(); }
        public ActionResult ZSJMXX_JJHB() { GetSession(); return View(); }
        public ActionResult ZSJMXX_JJRY() { GetSession(); return View(); }
        public ActionResult ZSJMXX_JYPX() { GetSession(); return View(); }
        public ActionResult ZSJMXX_QCFW() { GetSession(); return View(); }
        public ActionResult ZSJMXX_WLFW() { GetSession(); return View(); }
        public ActionResult ZSJMXX_NY() { GetSession(); return View(); }
        public ActionResult ZSJMXX_TS() { GetSession(); return View(); }
        public ActionResult ZSJMXX_SHFW() { GetSession(); return View(); }
        public ActionResult ZSJMXX_MYET() { GetSession(); return View(); }

        public JsonResult LoadZSJMXX()
        {
            return Json(ZSJMCXBLL.LoadZSJMXX(Request["TYPE"], Request["ID"]));
        }
    }
}