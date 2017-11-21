using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CLXXController : BaseController
    {
        public ICLCXBLL CLCXBLL { get; set; }
        public ActionResult CLXX_JC() { return View(); }
        public ActionResult CLXX_HC() { return View(); }
        public ActionResult CLXX_KC() { return View(); }
        public ActionResult CLXX_MTC() { return View(); }
        public ActionResult CLXX_ZXC() { return View(); }
        public ActionResult CLXX_DDC() { return View(); }
        public ActionResult CLXX_SLC() { return View(); }
        public ActionResult CLXX_GCC() { return View(); }

        public JsonResult LoadCLXX()
        {
            return Json(CLCXBLL.LoadCLXX(Request["TYPE"], Request["ID"]));
        }
    }
}