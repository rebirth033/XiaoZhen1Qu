using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class QZZPCXController : BaseController
    {
        public IQZZPCXBLL QZZPCXBLL { get; set; }
        public ActionResult QZZPCX_QZZP() { GetSession();return View(); }
        public ActionResult QZZPCX_JZZP() { GetSession(); return View(); }

        public JsonResult LoadQZZPXX()
        {
            return Json(QZZPCXBLL.LoadQZZPXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}