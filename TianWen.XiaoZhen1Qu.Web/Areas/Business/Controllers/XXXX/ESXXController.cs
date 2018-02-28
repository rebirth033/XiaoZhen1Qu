using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ESXXController : BaseController
    {
        public IESCXBLL ESCXBLL { get; set; }
        public ActionResult ESXX_SJSM_ESSJ() { GetSession(); return View(); }
        public ActionResult ESXX_SJSM_BJBDN() { GetSession(); return View(); }
        public ActionResult ESXX_SJSM_PBDN() { GetSession(); return View(); }
        public ActionResult ESXX_SJSM_SMCP() { GetSession(); return View(); }
        public ActionResult ESXX_SJSM_TSJ() { GetSession(); return View(); }
        public ActionResult ESXX_JDJJBG_ESJD() { GetSession(); return View(); }
        public ActionResult ESXX_JDJJBG_ESJJ() { GetSession(); return View(); }
        public ActionResult ESXX_JDJJBG_JJRY() { GetSession(); return View(); }
        public ActionResult ESXX_JDJJBG_BGSB() { GetSession(); return View(); }
        public ActionResult ESXX_MYFZMR_MYETYPWJ() { GetSession(); return View(); }
        public ActionResult ESXX_MYFZMR_FZXMXB() { GetSession(); return View(); }
        public ActionResult ESXX_MYFZMR_MRBJ() { GetSession(); return View(); }
        public ActionResult ESXX_WHYL_YSPSCP() { GetSession(); return View(); }
        public ActionResult ESXX_WHYL_WTHWYQ() { GetSession(); return View(); }
        public ActionResult ESXX_WHYL_TSYXRJ() { GetSession(); return View(); }
        public ActionResult ESXX_WHYL_WYXNWP() { GetSession(); return View(); }
        public ActionResult ESXX_PWKQ_MPKQ() { GetSession(); return View(); }
        public ActionResult ESXX_QTES_ESSB() { GetSession(); return View(); }
        public ActionResult ESXX_QTES_CRYP() { GetSession(); return View(); }

        public JsonResult LoadESXX()
        {
            return Json(ESCXBLL.LoadESXX(Request["TYPE"], Request["ID"]));
        }
    }
}