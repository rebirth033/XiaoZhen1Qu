using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.BLL;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WDSCController : BaseController
    {
        public IWDSCBLL WDSCBLL { get; set; }

        public ActionResult WDSC()
        {
            return View();
        }

        public JsonResult LoadSCXX()
        {
            return Json(WDSCBLL.LoadYHSCXX(Session["YHM"].ToString(), Request["PageIndex"], Request["PageSize"]));
        }

        public JsonResult DeleteYHSCXX()
        {
            return Json(WDSCBLL.DeleteYHSCXX(Request["YHID"], Request["JCXXID"]));
        }

        public JsonResult SCXX()
        {
            return Json(WDSCBLL.AddYHSCXX(Session["YHM"].ToString(), Request["JCXXID"], Request["TYPE"], Request["LBID"], Request["TYPEID"]));
        }
    }
}