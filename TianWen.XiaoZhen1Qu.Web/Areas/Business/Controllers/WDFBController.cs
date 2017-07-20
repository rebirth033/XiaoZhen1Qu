using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WDFBController : BaseController
    {
        public IWDFBBLL WDFBBLL { get; set; }

        public ActionResult WDFB()
        {
            return View();
        }

        public JsonResult LoadYHFBXX()
        {
            return Json(WDFBBLL.LoadYHFBXX(Request["YHID"], Request["TYPE"]));
        }
    }
}