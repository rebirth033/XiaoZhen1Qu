using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFWCXController : BaseController
    {
        public ISWFWCXBLL SWFWCXBLL { get; set; }
        public ActionResult SWFWCX_GSZC() { GetSession(); return View(); }
        public ActionResult SWFWCX_SBZL() { GetSession(); return View(); }
        public ActionResult SWFWCX_FLZX() { GetSession(); return View(); }
        public ActionResult SWFWCX_CWKJPG() { GetSession(); return View(); }
        public ActionResult SWFWCX_BX() { GetSession(); return View(); }
        public ActionResult SWFWCX_TZDB() { GetSession(); return View(); }
        public ActionResult SWFWCX_YSBZ() { GetSession(); return View(); }
        public ActionResult SWFWCX_PHZP() { GetSession(); return View(); }
        public ActionResult SWFWCX_SJCH() { GetSession(); return View(); }
        public ActionResult SWFWCX_GGCM() { GetSession(); return View(); }
        public ActionResult SWFWCX_ZHFW() { GetSession(); return View(); }
        public ActionResult SWFWCX_LPDZ() { GetSession(); return View(); }
        public ActionResult SWFWCX_ZK() { GetSession(); return View(); }
        public ActionResult SWFWCX_FYSJ() { GetSession(); return View(); }
        public ActionResult SWFWCX_WLBXWH() { GetSession(); return View(); }
        public ActionResult SWFWCX_WZJSTG() { GetSession(); return View(); }
        public ActionResult SWFWCX_ZXFW() { GetSession(); return View(); }
        public ActionResult SWFWCX_KD() { GetSession(); return View(); }
        public ActionResult SWFWCX_HYWL() { GetSession(); return View(); }
        public ActionResult SWFWCX_HYZX() { GetSession(); return View(); }
        public ActionResult SWFWCX_BGSBWX() { GetSession(); return View(); }
        public ActionResult SWFWCX_ZL() { GetSession(); return View(); }
        public ActionResult SWFWCX_DBQZQZ() { GetSession(); return View(); }
        public ActionResult SWFWCX_JZWX() { GetSession(); return View(); }
        public ActionResult SWFWCX_JXSBWX() { GetSession(); return View(); }
        public ActionResult SWFWCX_SYSX() { GetSession(); return View(); }
        public ActionResult SWFWCX_LYQD() { GetSession(); return View(); }

        public JsonResult LoadSWFWXX()
        {
            return Json(SWFWCXBLL.LoadSWFWXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"]));
        }
    }
}