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

        public ActionResult CLCX_JC()
        {
            GetSession();
            return View();
        }
        public ActionResult CLCX_HC()
        {
            GetSession();
            return View();
        }
        public ActionResult CLCX_KC()
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