using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class QZZPXXController : BaseController
    {
        public IQZZPCXBLL QZZPCXBLL { get; set; }
        public ActionResult QZZPXX_QZZP() { return View(); }
        public ActionResult QZZPXX_JZZP() { return View(); }

        public JsonResult LoadQZZPXX()
        {
            return Json(QZZPCXBLL.LoadQZZPXX(Request["TYPE"], Request["ID"]));
        }
    }
}