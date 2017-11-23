using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJDXXController : BaseController
    {
        public ILYJDCXBLL LYJDCXBLL { get; set; }
        public ActionResult LYJDXX_LXS() { return View(); }
        public ActionResult LYJDXX_GNY() { return View(); }
        public ActionResult LYJDXX_ZBY() { return View(); }
        public ActionResult LYJDXX_CJY() { return View(); }
        public ActionResult LYJDXX_JDZSYD() { return View(); }
        public ActionResult LYJDXX_JP() { return View(); }
        public ActionResult LYJDXX_DYDDR() { return View(); }

        public JsonResult LoadLYJDXX()
        {
            return Json(LYJDCXBLL.LoadLYJDXX(Request["TYPE"], Request["ID"]));
        }
    }
}