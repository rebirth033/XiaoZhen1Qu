﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_JXController : BaseController
    {
        public ISHFW_CLFW_JXBLL SHFW_CLFW_JXBLL { get; set; }

        public ActionResult SHFW_CLFW_JX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_JXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_JXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_JXJBXX SHFW_CLFW_JXjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_JXJBXX>(json);
            SHFW_CLFW_JXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_JXBLL.SaveSHFW_CLFW_JXJBXX(jcxx, SHFW_CLFW_JXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_JXJBXX()
        {
            string SHFW_CLFW_JXJBXXID = Request["SHFW_CLFW_JXJBXXID"];
            object result = SHFW_CLFW_JXBLL.LoadSHFW_CLFW_JXJBXX(SHFW_CLFW_JXJBXXID);
            return Json(result);
        }
    }
}