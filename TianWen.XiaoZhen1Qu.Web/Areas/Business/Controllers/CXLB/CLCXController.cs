using System;
using System.IO;
using System.Web.Mvc;
using System.Xml.Serialization;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CLCXController : BaseController
    {
        public ICLCXBLL CLCXBLL { get; set; }
        public ActionResult CLCX_JC() { GetSession(); return View(); }
        public ActionResult CLCX_HC() { GetSession(); return View(); }
        public ActionResult CLCX_KC() { GetSession(); return View(); }
        public ActionResult CLCX_MTC() { GetSession(); return View(); }
        public ActionResult CLCX_ZXC() { GetSession(); return View(); }
        public ActionResult CLCX_DDC() { GetSession(); return View(); }
        public ActionResult CLCX_SLC() { GetSession(); return View(); }
        public ActionResult CLCX_GCC() { GetSession(); return View(); }
        public ActionResult CLCX_ZC() { GetSession(); return View(); }
        public ActionResult CLCX_DJ() { GetSession(); return View(); }
        public ActionResult CLCX_JX() { GetSession(); return View(); }
        public ActionResult CLCX_QCPL() { GetSession(); return View(); }
        public ActionResult CLCX_QCWXBY() { GetSession(); return View(); }
        public ActionResult CLCX_GHSPNJYC() { GetSession(); return View(); }
        public ActionResult CLCX_QCMRZS() { GetSession(); return View(); }
        public ActionResult CLCX_QCGZFH() { GetSession(); return View(); }
        public ActionResult CLCX_QCPJ() { GetSession(); return View(); }

        public JsonResult LoadCLXX()
        {
            return Json(CLCXBLL.LoadCLXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"]));
        }
    }
}