using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCGXXController : BaseController
    {
        public IPFCGCXBLL PFCGCXBLL { get; set; }
        public ActionResult PFCGXX_SP() { return View(); }
        public ActionResult PFCGXX_LP() { return View(); }
        public ActionResult PFCGXX_FSXM() { return View(); }
        public ActionResult PFCGXX_XBSP() { return View(); }
        public ActionResult PFCGXX_SJSM() { return View(); }
        public ActionResult PFCGXX_MYWJ() { return View(); }
        public ActionResult PFCGXX_HWYD() { return View(); }
        public ActionResult PFCGXX_HZP() { return View(); }
        public ActionResult PFCGXX_AFSB() { return View(); }
        public ActionResult PFCGXX_FZBL() { return View(); }
        public ActionResult PFCGXX_SCSB() { return View(); }
        public ActionResult PFCGXX_HXP() { return View(); }
        public ActionResult PFCGXX_DGDL() { return View(); }
        public ActionResult PFCGXX_DZYQJ() { return View(); }
        public ActionResult PFCGXX_YBYQ() { return View(); }
        public ActionResult PFCGXX_DJZM() { return View(); }
        public ActionResult PFCGXX_YCL() { return View(); }
        public ActionResult PFCGXX_BZ() { return View(); }
        public ActionResult PFCGXX_YX() { return View(); }
        public ActionResult PFCGXX_TS() { return View(); }
        public ActionResult PFCGXX_KQ() { return View(); }
        public ActionResult PFCGXX_JXJG() { return View(); }
        

        public JsonResult LoadPFCGXX()
        {

            return Json(PFCGCXBLL.LoadPFCGXX(Request["TYPE"], Request["ID"]));
        }
    }
}