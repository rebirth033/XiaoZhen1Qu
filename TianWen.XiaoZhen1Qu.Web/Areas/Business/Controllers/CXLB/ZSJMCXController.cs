using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJMCXController : BaseController
    {
        public IZSJMCXBLL ZSJMCXBLL { get; set; }
        
        public ActionResult ZSJMCX_CY()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_FZXB()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadZSJMXX()
        {
            return Json(ZSJMCXBLL.LoadZSJMXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}