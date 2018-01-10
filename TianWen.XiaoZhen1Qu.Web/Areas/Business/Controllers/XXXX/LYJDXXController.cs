using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJDXXController : BaseController
    {
        public ILYJDCXBLL LYJDCXBLL { get; set; }
        public ActionResult LYJDXX_LXS() { GetSession(); return View(); }
        public ActionResult LYJDXX_QZFW() { GetSession(); return View(); }
        public ActionResult LYJDXX_GNY() { GetSession(); return View(); }
        public ActionResult LYJDXX_ZBY() { GetSession(); return View(); }
        public ActionResult LYJDXX_CJY() { GetSession(); return View(); }
        public ActionResult LYJDXX_JDZSYD() { GetSession(); return View(); }
        public ActionResult LYJDXX_JP() { GetSession(); return View(); }
        public ActionResult LYJDXX_DYDDR() { GetSession(); return View(); }

        public JsonResult LoadLYJDXX()
        {
            return Json(LYJDCXBLL.LoadLYJDXX(Request["TYPE"], Request["ID"]));
        }
    }
}