using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJCXXController : BaseController
    {
        public IZXJCCXBLL ZXJCCXBLL { get; set; }
        public ActionResult ZXJCXX_JZFW() { return View(); }
        public ActionResult ZXJCXX_GZFW() { return View(); }
        public ActionResult ZXJCXX_FWGZ() { return View(); }
        public ActionResult ZXJCXX_JC() { return View(); }
        public ActionResult ZXJCXX_JJ() { return View(); }
        public ActionResult ZXJCXX_JFJS() { return View(); }

        public JsonResult LoadZXJCXX()
        {
            return Json(ZXJCCXBLL.LoadZXJCXX(Request["TYPE"], Request["ID"]));
        }
    }
}