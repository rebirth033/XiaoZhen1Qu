using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSYXXController : BaseController
    {
        public IHQSYCXBLL HQSYCXBLL { get; set; }
        public ActionResult HQSYXX_HQGS() { return View(); }
        public ActionResult HQSYXX_HCZL() { return View(); }
        public ActionResult HQSYXX_HYJD() { return View(); }
        public ActionResult HQSYXX_CZZX() { return View(); }
        public ActionResult HQSYXX_HQYP() { return View(); }
        public ActionResult HQSYXX_SY() { return View(); }
        public ActionResult HQSYXX_HLGP() { return View(); }
        public ActionResult HQSYXX_HSLF() { return View(); }
        public ActionResult HQSYXX_ZBSS() { return View(); }
        public ActionResult HQSYXX_HSSY() { return View(); }

        public JsonResult LoadHQSYXX()
        {
            return Json(HQSYCXBLL.LoadHQSYXX(Request["TYPE"], Request["ID"]));
        }
    }
}