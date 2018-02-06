using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFWCXController : BaseController
    {
        public ISHFWCXBLL SHFWCXBLL { get; set; }
        public ActionResult SHFWCX_BJ() { GetSession(); return View(); }
        public ActionResult SHFWCX_BMYS() { GetSession(); return View(); }
        public ActionResult SHFWCX_BJQX() { GetSession(); return View(); }
        public ActionResult SHFWCX_KSXSHS() { GetSession(); return View(); }
        public ActionResult SHFWCX_GDSTQL() { GetSession(); return View(); }
        public ActionResult SHFWCX_SHPS() { GetSession(); return View(); }
        public ActionResult SHFWCX_BZMD() { GetSession(); return View(); }
        public ActionResult SHFWCX_JDWX() { GetSession(); return View(); }
        public ActionResult SHFWCX_DNWX() { GetSession(); return View(); }
        public ActionResult SHFWCX_FWWX() { GetSession(); return View(); }
        public ActionResult SHFWCX_JJWX() { GetSession(); return View(); }
        public ActionResult SHFWCX_SJWX() { GetSession(); return View(); }
        public ActionResult SHFWCX_SMWX() { GetSession(); return View(); }

        public JsonResult LoadSHFWXX()
        {
            return Json(SHFWCXBLL.LoadSHFWXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"], Session["XZQDM"].ToString()));
        }
    }
}