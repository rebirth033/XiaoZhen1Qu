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
        public ActionResult ZXJCXX_JZFW() { GetSession(); return View(); }
        public ActionResult ZXJCXX_GZFW() { GetSession(); return View(); }
        public ActionResult ZXJCXX_FWGZ() { GetSession(); return View(); }
        public ActionResult ZXJCXX_JC() { GetSession(); return View(); }
        public ActionResult ZXJCXX_JJ() { GetSession(); return View(); }
        public ActionResult ZXJCXX_JFJS() { GetSession(); return View(); }

        public JsonResult LoadZXJCXX()
        {
            return Json(ZXJCCXBLL.LoadZXJCXX(Request["TYPE"], Request["ID"]));
        }
    }
}