using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJMXXController : BaseController
    {
        public IZSJMCXBLL ZSJMCXBLL { get; set; }

        public ActionResult ZSJMXX_CY()
        {
            return View();
        }
        public ActionResult ZSJMXX_FZXB()
        {
            return View();
        }

        public JsonResult LoadZSJMXX()
        {
            return Json(ZSJMCXBLL.LoadZSJMXX(Request["TYPE"], Request["ID"]));
        }
    }
}