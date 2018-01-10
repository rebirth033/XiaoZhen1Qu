using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFWXXController : BaseController
    {
        public ISWFWCXBLL SWFWCXBLL { get; set; }
        public ActionResult SWFWXX_GSZC() { GetSession(); return View(); }
        public ActionResult SWFWXX_SBZL() { GetSession(); return View(); }
        public ActionResult SWFWXX_FLZX() { GetSession(); return View(); }
        public ActionResult SWFWXX_CWKJPG() { GetSession(); return View(); }
        public ActionResult SWFWXX_BX() { GetSession(); return View(); }
        public ActionResult SWFWXX_TZDB() { GetSession(); return View(); }
        public ActionResult SWFWXX_YSBZ() { GetSession(); return View(); }
        public ActionResult SWFWXX_PHZP() { GetSession(); return View(); }
        public ActionResult SWFWXX_SJCH() { GetSession(); return View(); }
        public ActionResult SWFWXX_GGCM() { GetSession(); return View(); }
        public ActionResult SWFWXX_ZHFW() { GetSession(); return View(); }
        public ActionResult SWFWXX_LPDZ() { GetSession(); return View(); }
        public ActionResult SWFWXX_ZK() { GetSession(); return View(); }
        public ActionResult SWFWXX_FYSJ() { GetSession(); return View(); }
        public ActionResult SWFWXX_WLBXWH() { GetSession(); return View(); }
        public ActionResult SWFWXX_WZJSTG() { GetSession(); return View(); }
        public ActionResult SWFWXX_ZXFW() { GetSession(); return View(); }
        public ActionResult SWFWXX_KD() { GetSession(); return View(); }
        public ActionResult SWFWXX_HYWL() { GetSession(); return View(); }
        public ActionResult SWFWXX_HYZX() { GetSession(); return View(); }
        public ActionResult SWFWXX_BGSBWX() { GetSession(); return View(); }
        public ActionResult SWFWXX_ZL() { GetSession(); return View(); }
        public ActionResult SWFWXX_DBQZQZ() { GetSession(); return View(); }
        public ActionResult SWFWXX_JZWX() { GetSession(); return View(); }
        public ActionResult SWFWXX_JXSBWX() { GetSession(); return View(); }
        public ActionResult SWFWXX_SYSX() { GetSession(); return View(); }
        public ActionResult SWFWXX_LYQD() { GetSession(); return View(); }
        public ActionResult SWFWXX_QMFSSM() { GetSession(); return View(); }

        public JsonResult LoadSWFWXX()
        {
            return Json(SWFWCXBLL.LoadSWFWXX(Request["TYPE"], Request["ID"]));
        }
    }
}