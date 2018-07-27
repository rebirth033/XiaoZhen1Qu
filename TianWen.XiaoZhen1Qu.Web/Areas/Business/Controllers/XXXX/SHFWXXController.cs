using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFWXXController : BaseController
    {
        public ISHFWCXBLL SHFWCXBLL { get; set; }
        public ActionResult SHFWXX_BJ() { GetSession(); return View(); }
        public ActionResult SHFWXX_BMYS() { GetSession(); return View(); }
        public ActionResult SHFWXX_BJQX() { GetSession(); return View(); }
        public ActionResult SHFWXX_KSXSHS() { GetSession(); return View(); }
        public ActionResult SHFWXX_GDSTQL() { GetSession(); return View(); }
        public ActionResult SHFWXX_SHPS() { GetSession(); return View(); }
        public ActionResult SHFWXX_BZMD() { GetSession(); return View(); }
        public ActionResult SHFWXX_JDWX() { GetSession(); return View(); }
        public ActionResult SHFWXX_DNWX() { GetSession(); return View(); }
        public ActionResult SHFWXX_FWWX() { GetSession(); return View(); }
        public ActionResult SHFWXX_JJWX() { GetSession(); return View(); }
        public ActionResult SHFWXX_SJWX() { GetSession(); return View(); }
        public ActionResult SHFWXX_SMWX() { GetSession(); return View(); }
        public ActionResult SHFWXX_ESHS() { GetSession(); return View(); }

        public JsonResult LoadSHFWXX()
        {
            return Json(SHFWCXBLL.LoadSHFWXX(Request["TYPE"], Request["ID"]));
        }
    }
}