﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZHBDController : BaseController
    {
        public IZHBDBLL ZHBDBLL { get; set; }
        public ActionResult ZHBD()
        {
            return View();
        }

        public ActionResult WBBD()
        {
            return View();
        }

        public ActionResult WXBD()
        {
            return View();
        }
    }
}