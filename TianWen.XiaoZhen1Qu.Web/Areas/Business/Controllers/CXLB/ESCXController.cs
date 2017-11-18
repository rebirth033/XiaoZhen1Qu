using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ESCXController : BaseController
    {
        public IESCXBLL ESCXBLL { get; set; }
        public ActionResult ESCX_SJSM_ESSJ() { GetSession(); return View(); }
        public ActionResult ESCX_SJSM_BJBDN() { GetSession(); return View(); }
        public ActionResult ESCX_SJSM_PBDN() { GetSession(); return View(); }
        public ActionResult ESCX_SJSM_SMCP() { GetSession(); return View(); }
        public ActionResult ESCX_SJSM_TSJ() { GetSession(); return View(); }
        public ActionResult ESCX_JDJJBG_ESJD() { GetSession(); return View(); }
        public ActionResult ESCX_JDJJBG_ESJJ() { GetSession(); return View(); }
        public ActionResult ESCX_JDJJBG_JJRY() { GetSession(); return View(); }
        public ActionResult ESCX_JDJJBG_BGSB() { GetSession(); return View(); }
        public ActionResult ESCX_MYFZMR_MYETYPWJ() { GetSession(); return View(); }
        public ActionResult ESCX_MYFZMR_FZXMXB() { GetSession(); return View(); }
        public ActionResult ESCX_MYFZMR_MRBJ() { GetSession(); return View(); }
        public ActionResult ESCX_WHYL_YSPSCP() { GetSession(); return View(); }
        public ActionResult ESCX_WHYL_WTHWYQ() { GetSession(); return View(); }
        public ActionResult ESCX_WHYL_TSYXRJ() { GetSession(); return View(); }
        public ActionResult ESCX_WHYL_WYXNWP() { GetSession(); return View(); }
        public ActionResult ESCX_PWKQ_YCMP() { GetSession(); return View(); }
        public ActionResult ESCX_PWKQ_QTKQ() { GetSession(); return View(); }
        public ActionResult ESCX_PWKQ_YLYJDP() { GetSession(); return View(); }
        public ActionResult ESCX_PWKQ_XFKGWQ() { GetSession(); return View(); }
        public ActionResult ESCX_QTES_ESSB() { GetSession(); return View(); }
        public ActionResult ESCX_QTES_CRYP() { GetSession(); return View(); }

        public JsonResult LoadESXX()
        {
            return Json(ESCXBLL.LoadESXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}