﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_SHPSController : BaseController
    {
        public ISHFW_SHFW_SHPSBLL SHFW_SHFW_SHPSBLL { get; set; }

        public ActionResult SHFW_SHFW_SHPS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_SHPSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_SHPSJBXX SHFW_SHFW_SHPSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_SHPSJBXX>(json);
            SHFW_SHFW_SHPSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_SHPSBLL.SaveSHFW_SHFW_SHPSJBXX(jcxx, SHFW_SHFW_SHPSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_SHPSJBXX()
        {
            string SHFW_SHFW_SHPSJBXXID = Request["SHFW_SHFW_SHPSJBXXID"];
            object result = SHFW_SHFW_SHPSBLL.LoadSHFW_SHFW_SHPSJBXX(SHFW_SHFW_SHPSJBXXID);
            return Json(result);
        }
    }
}