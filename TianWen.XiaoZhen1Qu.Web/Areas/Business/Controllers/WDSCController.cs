using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.BLL;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WDSCController : BaseController
    {
        public IWDSCBLL WDSCBLL { get; set; }

        public ActionResult WDSC()
        {
            return View();
        }

        public JsonResult LoadSCXX()
        {
            return Json(WDSCBLL.LoadSCXX(Request["YHID"]));
        }

        public JsonResult DeleteYHSCXX()
        {
            return Json(WDSCBLL.DeleteYHSCXX(Request["YHID"], Request["JCXXID"]));
        }
    }
}