using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WDXJController : BaseController
    {
        public IWDXJBLL WDXJBLL { get; set; }

        public ActionResult WDXJ_MXCX()
        {
            return View();
        }

        public JsonResult LoadSZMX()
        {
            return Json(WDXJBLL.LoadSZMX(Request["YHID"], Request["LX"], Request["ZJLX"], Request["StartTime"], Request["EndTime"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}