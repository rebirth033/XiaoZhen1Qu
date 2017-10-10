﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_LXSController : BaseController
    {
        public ILYJD_LXSBLL LYJD_LXSBLL { get; set; }

        public ActionResult LYJD_LXS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_LXSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + LYJD_LXSBLL.GetLBQCByLBID(jcxx.LBID);
            LYJD_LXSJBXX LYJD_LXSjbxx = JsonHelper.ConvertJsonToObject<LYJD_LXSJBXX>(json);
            LYJD_LXSjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_LXSBLL.SaveLYJD_LXSJBXX(jcxx, LYJD_LXSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_LXSJBXX()
        {
            string LYJD_LXSJBXXID = Request["LYJD_LXSJBXXID"];
            object result = LYJD_LXSBLL.LoadLYJD_LXSJBXX(LYJD_LXSJBXXID);
            return Json(result);
        }
    }
}