using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCCXController : BaseController
    {
        public IFCCXBLL FCCXBLL { get; set; }

        public ActionResult FCCX_ZZF()
        {
            GetSession();
            return View();
        }
        public ActionResult FCCX_DZF()
        {
            GetSession();
            return View();
        }

        public JsonResult LoadFCXX()
        {
            return Json(FCCXBLL.LoadFCXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}