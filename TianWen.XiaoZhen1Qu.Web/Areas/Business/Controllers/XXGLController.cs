using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXGLController : BaseController
    {
        public IXXGLBLL XXGLBLL { get; set; }

        public ActionResult XXGL()
        {
            return View();
        }
    }
}