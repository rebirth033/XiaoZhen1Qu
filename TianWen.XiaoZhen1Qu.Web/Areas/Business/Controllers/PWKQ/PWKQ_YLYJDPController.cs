﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PWKQ_YLYJDPController : BaseController
    {
        public IPWKQ_YLYJDPBLL PWKQ_YLYJDPBLL { get; set; }

        public ActionResult PWKQ_YLYJDP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PWKQ_YLYJDPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + PWKQ_YLYJDPBLL.GetLBQCByLBID(jcxx.LBID);
            PWKQ_YLYJDPJBXX PWKQ_YLYJDPjbxx = JsonHelper.ConvertJsonToObject<PWKQ_YLYJDPJBXX>(json);
            PWKQ_YLYJDPjbxx.BCMS = bcms;
            object result = PWKQ_YLYJDPBLL.SavePWKQ_YLYJDPJBXX(jcxx, PWKQ_YLYJDPjbxx);
            return Json(result);
        }

        public JsonResult LoadPWKQ_YLYJDPJBXX()
        {
            string PWKQ_YLYJDPJBXXID = Request["PWKQ_YLYJDPJBXXID"];
            object result = PWKQ_YLYJDPBLL.LoadPWKQ_YLYJDPJBXX(PWKQ_YLYJDPJBXXID);
            return Json(result);
        }
    }
}