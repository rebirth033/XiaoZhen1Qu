﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_FSXMController : BaseController
    {
        public IPFCG_FSXMBLL PFCG_FSXMBLL { get; set; }

        public ActionResult PFCG_FSXM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_FSXMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_FSXMBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_FSXMJBXX PFCG_FSXMjbxx = JsonHelper.ConvertJsonToObject<PFCG_FSXMJBXX>(json);
            PFCG_FSXMjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_FSXMBLL.SavePFCG_FSXMJBXX(jcxx, PFCG_FSXMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_FSXMJBXX()
        {
            string PFCG_FSXMJBXXID = Request["PFCG_FSXMJBXXID"];
            object result = PFCG_FSXMBLL.LoadPFCG_FSXMJBXX(PFCG_FSXMJBXXID);
            return Json(result);
        }
    }
}