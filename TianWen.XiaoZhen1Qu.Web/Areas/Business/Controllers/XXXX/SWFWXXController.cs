using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFWXXController : BaseController
    {
        public ISWFWCXBLL SWFWCXBLL { get; set; }
        public ActionResult SWFWXX_GSZC() { return View(); }
        public ActionResult SWFWXX_SBZL() { return View(); }
        public ActionResult SWFWXX_FLZX() { return View(); }
        public ActionResult SWFWXX_CWKJPG() { return View(); }
        public ActionResult SWFWXX_BX() { return View(); }
        public ActionResult SWFWXX_TZDB() { return View(); }
        public ActionResult SWFWXX_YSBZ() { return View(); }
        public ActionResult SWFWXX_PHZP() { return View(); }
        public ActionResult SWFWXX_SJCH() { return View(); }
        public ActionResult SWFWXX_GGCM() { return View(); }
        public ActionResult SWFWXX_ZHFW() { return View(); }
        public ActionResult SWFWXX_LPDZ() { return View(); }
        public ActionResult SWFWXX_ZK() { return View(); }
        public ActionResult SWFWXX_FYSJ() { return View(); }
        public ActionResult SWFWXX_WLBXWH() { return View(); }
        public ActionResult SWFWXX_WZJSTG() { return View(); }
        public ActionResult SWFWXX_ZXFW() { return View(); }
        public ActionResult SWFWXX_KD() { return View(); }
        public ActionResult SWFWXX_HYWL() { return View(); }
        public ActionResult SWFWXX_HYZX() { return View(); }
        public ActionResult SWFWXX_BGSBWX() { return View(); }
        public ActionResult SWFWXX_ZL() { return View(); }
        public ActionResult SWFWXX_DBQZQZ() { return View(); }
        public ActionResult SWFWXX_JZWX() { return View(); }
        public ActionResult SWFWXX_JXSBWX() { return View(); }
        public ActionResult SWFWXX_SYSX() { return View(); }
        public ActionResult SWFWXX_LYQD() { return View(); }

        public JsonResult LoadSWFWXX()
        {
            return Json(SWFWCXBLL.LoadSWFWXX(Request["TYPE"], Request["ID"]));
        }
    }
}