using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPXCXController : BaseController
    {
        public IJYPXCXBLL JYPXCXBLL { get; set; }
        
        public ActionResult ZSJMCX_CY()
        {
            GetSession();
            return View();
        }
        

        public JsonResult LoadJYPXXX()
        {
            return Json(JYPXCXBLL.LoadJYPXXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}