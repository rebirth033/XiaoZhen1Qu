using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WZCXController : BaseController
    {
        public IWZCXBLL WZCXBLL { get; set; }
        public ActionResult WZCX()
        {
            return View();
        }
    }
}