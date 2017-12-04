using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSYCXController : BaseController
    {
        public IHQSYCXBLL HQSYCXBLL { get; set; }
        public ActionResult HQSYCX_HQGS() { GetSession(); return View(); }
        public ActionResult HQSYCX_HCZL() { GetSession(); return View(); }
        public ActionResult HQSYCX_HYJD() { GetSession(); return View(); }
        public ActionResult HQSYCX_CZZX() { GetSession(); return View(); }
        public ActionResult HQSYCX_HQYP() { GetSession(); return View(); }
        public ActionResult HQSYCX_SY() { GetSession(); return View(); }
        public ActionResult HQSYCX_HLGP() { GetSession(); return View(); }
        public ActionResult HQSYCX_HSLF() { GetSession(); return View(); }
        public ActionResult HQSYCX_HSSY() { GetSession(); return View(); }

        public JsonResult LoadHQSYXX()
        {
            return Json(HQSYCXBLL.LoadHQSYXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}