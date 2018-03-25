using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCCXController : BaseController
    {
        public IFCCXBLL FCCXBLL { get; set; }
        public ActionResult FCCX_ZZF() { GetSession(); return View(); }
        public ActionResult FCCX_HZF() { GetSession(); return View(); }
        public ActionResult FCCX_DZF() { GetSession(); return View(); }
        public ActionResult FCCX_ESF() { GetSession(); return View(); }
        public ActionResult FCCX_SP() { GetSession(); return View(); }
        public ActionResult FCCX_XZL() { GetSession(); return View(); }
        public ActionResult FCCX_CF() { GetSession(); return View(); }
        public ActionResult FCCX_CK() { GetSession(); return View(); }
        public ActionResult FCCX_TD() { GetSession(); return View(); }
        public ActionResult FCCX_CW() { GetSession(); return View(); }

        public JsonResult LoadFCXX()
        {
            string type = Request["TYPE"];
            string condition = Request["Condition"];
            string pageindex = Request["PageIndex"];
            string pagesize = Request["PageSize"];
            string xzq = Session["XZQ"].ToString();
            string ordercolumn = Request["OrderColumn"];
            string ordertype = Request["OrderType"];
            string xzqdm = Session["XZQDM"].ToString();
            return Json(FCCXBLL.LoadFCXX(Request["TYPE"], Request["Condition"], Request["PageIndex"], Request["PageSize"], Session["XZQ"].ToString(), Request["OrderColumn"], Request["OrderType"], Session["XZQDM"].ToString()));
        }
    }
}