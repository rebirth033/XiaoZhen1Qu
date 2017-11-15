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
        public ActionResult ESXX_SJSM_BJBDN()
        {
            return View();
        }
        public ActionResult ESXX_SJSM_PBDN()
        {
            return View();
        }
        public ActionResult ESXX_SJSM_SMCP()
        {
            return View();
        }
        public ActionResult ESXX_SJSM_TSJ()
        {
            return View();
        }
        public ActionResult ESXX_JDJJBG_ESJD()
        {
            return View();
        }
        public ActionResult ESXX_JDJJBG_ESJJ()
        {
            return View();
        }
        public ActionResult ESXX_JDJJBG_JJRY()
        {
            return View();
        }
        public ActionResult ESXX_JDJJBG_BGSB()
        {
            return View();
        }
        public ActionResult ESXX_MYFZMR_MYETYPWJ()
        {
            return View();
        }
        public ActionResult ESXX_MYFZMR_FZXMXB()
        {
            return View();
        }
        public ActionResult ESXX_MYFZMR_MRBJ()
        {
            return View();
        }

        public JsonResult LoadESXX()
        {
            return Json(ESCXBLL.LoadESXX(Request["TYPE"], Request["ID"]));
        }
    }
}