using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FWCZController : BaseController
    {
        public IFWCZJBXXBLL FWCZJBXXBLL { get; set; }
        public IBaseBLL BaseBLL { get; set; }

        public ActionResult FWCZ()
        {
            return View();
        }

        public JsonResult LoadCODES()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(BaseBLL.LoadCODES(TYPENAME));
        }

        public JsonResult FB()
        {
            string json = Request["Json"];
            FWCZJBXX yhjbxx = JsonHelper.ConvertJsonToObject<FWCZJBXX>(json);
            object result = FWCZJBXXBLL.SaveFWCZJBXX(yhjbxx);
            return Json(result);
        }

        public JsonResult LoadFWCZXX()
        {
            string FWCZID = Request["FWCZID"];
            object result = FWCZJBXXBLL.LoadFWCZXX(FWCZID);
            return Json(result);
        }
    }
}