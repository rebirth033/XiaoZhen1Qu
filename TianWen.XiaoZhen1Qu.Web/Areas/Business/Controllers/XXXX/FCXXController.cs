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

        public ActionResult FC_ZZF()
        {
            return View();
        }
        public ActionResult FC_DZF()
        {
            return View();
        }
        public ActionResult FC_ESF()
        {
            return View();
        }
        public ActionResult FC_SP()
        {
            return View();
        }

        public JsonResult LoadFCXX()
        {
            return Json(FCCXBLL.LoadFCXX(Request["TYPE"], Request["ID"]));
        }
    }
}