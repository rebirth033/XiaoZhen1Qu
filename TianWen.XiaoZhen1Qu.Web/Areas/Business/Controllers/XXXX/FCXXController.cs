﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCXXController : BaseController
    {
        public IFCCXBLL FCCXBLL { get; set; }
        public ActionResult FCXX_ZZF() { return View(); }
        public ActionResult FCXX_DZF() { return View(); }
        public ActionResult FCXX_ESF() { return View(); }
        public ActionResult FCXX_SP() { return View(); }
        public ActionResult FCXX_XZL() { return View(); }
        public ActionResult FCXX_CF() { return View(); }
        public ActionResult FCXX_CK() { return View(); }
        public ActionResult FCXX_TD() { return View(); }
        public ActionResult FCXX_CW() { return View(); }

        public JsonResult LoadFCXX()
        {
            return Json(FCCXBLL.LoadFCXX(Request["TYPE"], Request["ID"]));
        }
    }
}