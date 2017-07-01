using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}