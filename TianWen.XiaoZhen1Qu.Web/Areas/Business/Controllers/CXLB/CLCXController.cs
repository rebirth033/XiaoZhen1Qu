using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CLCXController : BaseController
    {
        public ICLCXBLL CLCXBLL { get; set; }

        public ActionResult CL_JC()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadCLXX()
        {
            return Json(CLCXBLL.LoadCLXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}