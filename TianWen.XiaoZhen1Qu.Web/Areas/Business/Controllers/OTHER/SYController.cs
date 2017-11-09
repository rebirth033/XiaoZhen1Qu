﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SYController : BaseController
    {
        public ISYBLL SYBLL { get; set; }
        public ActionResult SY()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadZXFBXX()
        {
            return Json(SYBLL.LoadZXFBXX());
        }

        public JsonResult LoadLBByJCXX()
        {
            return Json(SYBLL.LoadLBByJCXX(Request["LBID"], Request["JCXXID"]));
        }
    }
}