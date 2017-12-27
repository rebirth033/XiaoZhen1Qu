using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCGCXController : BaseController
    {
        public IPFCGCXBLL PFCGCXBLL { get; set; }
        public ActionResult PFCGCX_SP(){ GetSession();return View(); }
        public ActionResult PFCGCX_LP() { GetSession(); return View(); }
        public ActionResult PFCGCX_FSXM() { GetSession(); return View(); }
        public ActionResult PFCGCX_XBSP() { GetSession(); return View(); }
        public ActionResult PFCGCX_SJSM() { GetSession(); return View(); }
        public ActionResult PFCGCX_MYWJ() { GetSession(); return View(); }
        public ActionResult PFCGCX_HWYD() { GetSession(); return View(); }
        public ActionResult PFCGCX_HZP() { GetSession(); return View(); }
        public ActionResult PFCGCX_AFSB() { GetSession(); return View(); }
        public ActionResult PFCGCX_FZBL() { GetSession(); return View(); }
        public ActionResult PFCGCX_SCSB() { GetSession(); return View(); }
        public ActionResult PFCGCX_HXP() { GetSession(); return View(); }
        public ActionResult PFCGCX_DGDL() { GetSession(); return View(); }
        public ActionResult PFCGCX_DZYQJ() { GetSession(); return View(); }
        public ActionResult PFCGCX_YBYQ() { GetSession(); return View(); }
        public ActionResult PFCGCX_DJZM() { GetSession(); return View(); }
        public ActionResult PFCGCX_YCL() { GetSession(); return View(); }
        public ActionResult PFCGCX_BZ() { GetSession(); return View(); }
        public ActionResult PFCGCX_TS() { GetSession(); return View(); }
        public ActionResult PFCGCX_KQ() { GetSession(); return View(); }
        public ActionResult PFCGCX_JXJG() { GetSession(); return View(); }


        public JsonResult LoadPFCGXX()
        {
            return Json(PFCGCXBLL.LoadPFCGXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Request["OrderColumn"], Request["OrderType"]));
        }
    }
}