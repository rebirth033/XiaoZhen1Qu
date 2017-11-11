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

        public ActionResult FC_ZZF()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_DZF()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_ESF()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_SP()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_XZL()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_CF()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_CK()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_TD()
        {
            GetSession();
            return View();
        }
        public ActionResult FC_CW()
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