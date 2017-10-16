﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_ZXXFDBController : BaseController
    {
        public IJYPX_ZXXFDBBLL JYPX_ZXXFDBBLL { get; set; }

        public ActionResult JYPX_ZXXFDB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_ZXXFDBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_ZXXFDBBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_ZXXFDBJBXX JYPX_ZXXFDBjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZXXFDBJBXX>(json);
            JYPX_ZXXFDBjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ZXXFDBBLL.SaveJYPX_ZXXFDBJBXX(jcxx, JYPX_ZXXFDBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_ZXXFDBJBXX()
        {
            string JYPX_ZXXFDBJBXXID = Request["JYPX_ZXXFDBJBXXID"];
            object result = JYPX_ZXXFDBBLL.LoadJYPX_ZXXFDBJBXX(JYPX_ZXXFDBJBXXID);
            return Json(result);
        }
    }
}