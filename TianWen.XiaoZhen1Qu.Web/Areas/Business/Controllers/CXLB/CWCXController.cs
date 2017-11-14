using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CWCXController : BaseController
    {
        public ICWCXBLL CWCXBLL { get; set; }

        public ActionResult CWCX_CWG()
        {
            GetSession();
            return View();
        }
        public ActionResult CWCX_CWM()
        {
            GetSession();
            return View();
        }
        public ActionResult CWCX_HNYC()
        {
            GetSession();
            return View();
        }
        public ActionResult CWCX_CWFW()
        {
            GetSession();
            return View();
        }
        public ActionResult CWCX_CWYPSP()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadCWXX()
        {
            return Json(CWCXBLL.LoadCWXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}