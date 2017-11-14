using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ESXXController : BaseController
    {
        public IESCXBLL ESCXBLL { get; set; }

        public ActionResult ESXX_SJSM_ESSJ()
        {
            return View();
        }

        public JsonResult LoadESXX()
        {
            return Json(ESCXBLL.LoadESXX(Request["TYPE"], Request["ID"]));
        }
    }
}