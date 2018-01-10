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
        public IFCCXBLL FCCXBLL { get; set; }
        public ActionResult FCXX_ZZF() { GetSession(); return View(); }
        public ActionResult FCXX_HZF() { GetSession(); return View(); }
        public ActionResult FCXX_DZF() { GetSession(); return View(); }
        public ActionResult FCXX_ESF() { GetSession(); return View(); }
        public ActionResult FCXX_SP() { GetSession(); return View(); }
        public ActionResult FCXX_XZL() { GetSession(); return View(); }
        public ActionResult FCXX_CF() { GetSession(); return View(); }
        public ActionResult FCXX_CK() { GetSession(); return View(); }
        public ActionResult FCXX_TD() { GetSession(); return View(); }
        public ActionResult FCXX_CW() { GetSession(); return View(); }

        public JsonResult LoadFCXX()
        {
            return Json(FCCXBLL.LoadFCXX(Request["TYPE"], Request["ID"]));
        }
    }
}