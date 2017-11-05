using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCXXController : BaseController
    {
        public IFCXXBLL FCXXBLL { get; set; }

        public ActionResult FCXX_ZZF()
        {
            return View();
        }
    }
}