using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BZZXController : BaseController
    {
        public IBZZXBLL BZZXBLL { get; set; }
        public ActionResult BZZX()
        {
            return View();
        }

        public ActionResult BZZX_SY()
        {
            return View();
        }

        public ActionResult BZZX_SY_ZDJS()
        {
            return View();
        }

        public ActionResult BZZX_CJWT()
        {
            return View();
        }

        public ActionResult BZZX_LXKF()
        {
            return View();
        }

        public ActionResult BZZX_WZJY()
        {
            return View();
        }
        
    }
}