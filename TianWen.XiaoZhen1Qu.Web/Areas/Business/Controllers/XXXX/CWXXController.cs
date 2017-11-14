using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CWXXController : BaseController
    {
        public ICWCXBLL CWCXBLL { get; set; }

        public ActionResult CWXX_CWG()
        {
            return View();
        }
        public ActionResult CWXX_CWM()
        {
            return View();
        }
        public ActionResult CWXX_HNYC()
        {
            return View();
        }
        public ActionResult CWXX_CWFW()
        {
            return View();
        }
        public ActionResult CWXX_CWYPSP()
        {
            return View();
        }

        public JsonResult LoadCWXX()
        {
            return Json(CWCXBLL.LoadCWXX(Request["TYPE"], Request["ID"]));
        }
    }
}