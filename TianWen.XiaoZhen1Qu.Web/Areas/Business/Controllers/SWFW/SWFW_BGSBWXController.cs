﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_BGSBWXController : BaseController
    {
        public ISWFW_BGSBWXBLL SWFW_BGSBWXBLL { get; set; }

        public ActionResult SWFW_BGSBWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_BGSBWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_BGSBWXJBXX SWFW_BGSBWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_BGSBWXJBXX>(json);
            SWFW_BGSBWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BGSBWXBLL.SaveSWFW_BGSBWXJBXX(jcxx, SWFW_BGSBWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_BGSBWXJBXX()
        {
            string SWFW_BGSBWXJBXXID = Request["SWFW_BGSBWXJBXXID"];
            object result = SWFW_BGSBWXBLL.LoadSWFW_BGSBWXJBXX(SWFW_BGSBWXJBXXID);
            return Json(result);
        }
    }
}