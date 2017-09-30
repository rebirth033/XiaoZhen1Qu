﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_YBYQController : BaseController
    {
        public IPFCG_YBYQBLL PFCG_YBYQBLL { get; set; }

        public ActionResult PFCG_YBYQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_YBYQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_YBYQBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_YBYQJBXX PFCG_YBYQjbxx = JsonHelper.ConvertJsonToObject<PFCG_YBYQJBXX>(json);
            PFCG_YBYQjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_YBYQBLL.SavePFCG_YBYQJBXX(jcxx, PFCG_YBYQjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_YBYQJBXX()
        {
            string PFCG_YBYQJBXXID = Request["PFCG_YBYQJBXXID"];
            object result = PFCG_YBYQBLL.LoadPFCG_YBYQJBXX(PFCG_YBYQJBXXID);
            return Json(result);
        }
    }
}