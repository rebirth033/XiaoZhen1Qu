﻿using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ESCXController : BaseController
    {
        public IESCXBLL ESCXBLL { get; set; }

        public ActionResult ESCX_SJSM_ESSJ()
        {
            GetSession();
            return View();
        }
        public ActionResult ESCX_SJSM_BJBDN()
        {
            GetSession();
            return View();
        }
        public ActionResult ESCX_SJSM_PBDN()
        {
            GetSession();
            return View();
        }
        public ActionResult ESCX_SJSM_SMCP()
        {
            GetSession();
            return View();
        }
        public ActionResult ESCX_SJSM_TSJ()
        {
            GetSession();
            return View();
        }
        public ActionResult ESCX_JDJJBG_ESJD()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadESXX()
        {
            return Json(ESCXBLL.LoadESXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}