﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface.CXLB;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCCXController : BaseController
    {
        public IFCCXBLL FCCXBLL { get; set; }

        public ActionResult FCCX_ZZF()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadFCXX()
        {
            return Json(FCCXBLL.LoadFCXX(Request["TYPE"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}