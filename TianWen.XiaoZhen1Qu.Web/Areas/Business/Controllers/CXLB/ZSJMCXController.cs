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
        public ActionResult ZSJMCX_JC()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_JX()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_MRBJ()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_LPSP()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_JJHB()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_JYPX()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_QCFW()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_WLFW()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_NY()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_TS()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_SHFW()
        {
            GetSession();
            return View();
        }
        public ActionResult ZSJMCX_MYET()
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