using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSYXXController : BaseController
    {
        public IHQSYCXBLL HQSYCXBLL { get; set; }
        public ActionResult HQSYXX_HQGS() { GetSession(); return View(); }
        public ActionResult HQSYXX_HCZL() { GetSession(); return View(); }
        public ActionResult HQSYXX_HYJD() { GetSession(); return View(); }
        public ActionResult HQSYXX_CZZX() { GetSession(); return View(); }
        public ActionResult HQSYXX_HQYP() { GetSession(); return View(); }
        public ActionResult HQSYXX_SY() { GetSession(); return View(); }
        public ActionResult HQSYXX_HLGP() { GetSession(); return View(); }
        public ActionResult HQSYXX_HSLF() { GetSession(); return View(); }
        public ActionResult HQSYXX_HSSY() { GetSession(); return View(); }

        public JsonResult LoadHQSYXX()
        {
            return Json(HQSYCXBLL.LoadHQSYXX(Request["TYPE"], Request["ID"]));
        }
    }
}