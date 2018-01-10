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
        public ActionResult PFCGXX_SP() { GetSession(); return View(); }
        public ActionResult PFCGXX_LP() { GetSession(); return View(); }
        public ActionResult PFCGXX_FSXM() { GetSession(); return View(); }
        public ActionResult PFCGXX_XBSP() { GetSession(); return View(); }
        public ActionResult PFCGXX_SJSM() { GetSession(); return View(); }
        public ActionResult PFCGXX_MYWJ() { GetSession(); return View(); }
        public ActionResult PFCGXX_HWYD() { GetSession(); return View(); }
        public ActionResult PFCGXX_HZP() { GetSession(); return View(); }
        public ActionResult PFCGXX_AFSB() { GetSession(); return View(); }
        public ActionResult PFCGXX_FZBL() { GetSession(); return View(); }
        public ActionResult PFCGXX_SCSB() { GetSession(); return View(); }
        public ActionResult PFCGXX_HXP() { GetSession(); return View(); }
        public ActionResult PFCGXX_DGDL() { GetSession(); return View(); }
        public ActionResult PFCGXX_DZYQJ() { GetSession(); return View(); }
        public ActionResult PFCGXX_YBYQ() { GetSession(); return View(); }
        public ActionResult PFCGXX_DJZM() { GetSession(); return View(); }
        public ActionResult PFCGXX_YCL() { GetSession(); return View(); }
        public ActionResult PFCGXX_BZ() { GetSession(); return View(); }
        public ActionResult PFCGXX_YX() { GetSession(); return View(); }
        public ActionResult PFCGXX_TS() { GetSession(); return View(); }
        public ActionResult PFCGXX_KQ() { GetSession(); return View(); }
        public ActionResult PFCGXX_JXJG() { GetSession(); return View(); }
        

        public JsonResult LoadPFCGXX()
        {

            return Json(PFCGCXBLL.LoadPFCGXX(Request["TYPE"], Request["ID"]));
        }
    }
}