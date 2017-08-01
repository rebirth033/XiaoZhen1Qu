using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXGLController : BaseController
    {
        public IXXGLBLL XXGLBLL { get; set; }

        public ActionResult XXGL()
        {
            return View();
        }

        public ActionResult XXGLMX()
        {
            return View();
        }

        public JsonResult LoadYHXX()
        {
            return Json(XXGLBLL.LoadYHXX(Request["YHID"], Request["TYPE"], Request["PageIndex"], Request["PageSize"]));
        }

        public JsonResult LoadYHXXMX()
        {
            return Json(XXGLBLL.LoadYHXXMX(Request["YHID"], Request["YHXXID"]));
        }

        public JsonResult DeleteYHXX()
        {
            return Json(XXGLBLL.DeleteYHXX(Request["YHXXID"].Split(',')));
        }

        public JsonResult YDYHXX()
        {
            return Json(XXGLBLL.YDYHXX(Request["YHXXID"].Split(',')));
        }
        
    }
}