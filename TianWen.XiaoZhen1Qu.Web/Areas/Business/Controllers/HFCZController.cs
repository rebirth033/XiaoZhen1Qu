using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HFCZController : BaseController
    {
        public IHFCZBLL HFCZBLL { get; set; }

        public ActionResult HFCZ()
        {
            return View();
        }

        public ActionResult ZFFS()
        {
            return View();
        }

        public JsonResult SearchMobilePhoneGuiSuArea()
        {
            object result = HFCZBLL.SearchMobilePhoneGuiSuArea(Request["YHID"], Request["MobileNo"]);
            return Json(result);
        }
    }
}