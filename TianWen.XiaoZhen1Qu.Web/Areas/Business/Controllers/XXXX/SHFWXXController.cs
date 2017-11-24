using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFWXXController : BaseController
    {
        public ISHFWCXBLL SHFWCXBLL { get; set; }
        public ActionResult SHFWXX_BJ() { return View(); }
        public ActionResult SHFWXX_BMYS() { return View(); }
        public ActionResult SHFWXX_BJQX() { return View(); }
        public ActionResult SHFWXX_KSXSHS() { return View(); }
        public ActionResult SHFWXX_GDSTQL() { return View(); }
        public ActionResult SHFWXX_SHPS() { return View(); }
        public ActionResult SHFWXX_BZMD() { return View(); }
        public ActionResult SHFWXX_JDWX() { return View(); }
        public ActionResult SHFWXX_DNWX() { return View(); }
        public ActionResult SHFWXX_FWWXDK() { return View(); }
        public ActionResult SHFWXX_JJWX() { return View(); }
        public ActionResult SHFWXX_SJWX() { return View(); }
        public ActionResult SHFWXX_SMWX() { return View(); }

        public JsonResult LoadZXJCXX()
        {
            return Json(SHFWCXBLL.LoadSHFWXX(Request["TYPE"], Request["ID"]));
        }
    }
}