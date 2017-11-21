using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJMXXController : BaseController
    {
        public IZSJMCXBLL ZSJMCXBLL { get; set; }
        public ActionResult ZSJMXX_CY() { return View(); }
        public ActionResult ZSJMXX_FZXB() { return View(); }
        public ActionResult ZSJMXX_JC() { return View(); }
        public ActionResult ZSJMXX_JX() { return View(); }
        public ActionResult ZSJMXX_MRBJ() { return View(); }
        public ActionResult ZSJMXX_LPSP() { return View(); }
        public ActionResult ZSJMXX_JJHB() { return View(); }
        public ActionResult ZSJMXX_JYPX() { return View(); }
        public ActionResult ZSJMXX_QCFW() { return View(); }
        public ActionResult ZSJMXX_WLFW() { return View(); }
        public ActionResult ZSJMXX_NY() { return View(); }
        public ActionResult ZSJMXX_TS() { return View(); }
        public ActionResult ZSJMXX_SHFW() { return View(); }
        public ActionResult ZSJMXX_MYET() { return View(); }

        public JsonResult LoadZSJMXX()
        {
            return Json(ZSJMCXBLL.LoadZSJMXX(Request["TYPE"], Request["ID"]));
        }
    }
}