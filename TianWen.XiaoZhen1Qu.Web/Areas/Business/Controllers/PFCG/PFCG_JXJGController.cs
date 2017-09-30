﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_JXJGController : BaseController
    {
        public IPFCG_JXJGBLL PFCG_JXJGBLL { get; set; }

        public ActionResult PFCG_JXJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_JXJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_JXJGBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_JXJGJBXX PFCG_JXJGjbxx = JsonHelper.ConvertJsonToObject<PFCG_JXJGJBXX>(json);
            PFCG_JXJGjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_JXJGBLL.SavePFCG_JXJGJBXX(jcxx, PFCG_JXJGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_JXJGJBXX()
        {
            string PFCG_JXJGJBXXID = Request["PFCG_JXJGJBXXID"];
            object result = PFCG_JXJGBLL.LoadPFCG_JXJGJBXX(PFCG_JXJGJBXXID);
            return Json(result);
        }
    }
}