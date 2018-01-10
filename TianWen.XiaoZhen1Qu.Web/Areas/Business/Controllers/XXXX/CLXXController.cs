using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CLXXController : BaseController
    {
        public ICLCXBLL CLCXBLL { get; set; }
        public ActionResult CLXX_JC() { GetSession(); return View(); }
        public ActionResult CLXX_HC() { GetSession(); return View(); }
        public ActionResult CLXX_KC() { GetSession(); return View(); }
        public ActionResult CLXX_MTC() { GetSession(); return View(); }
        public ActionResult CLXX_ZXC() { GetSession(); return View(); }
        public ActionResult CLXX_DDC() { GetSession(); return View(); }
        public ActionResult CLXX_SLC() { GetSession(); return View(); }
        public ActionResult CLXX_GCC() { GetSession(); return View(); }
        public ActionResult CLXX_ZC() { GetSession(); return View(); }
        public ActionResult CLXX_DJ() { GetSession(); return View(); }
        public ActionResult CLXX_JX() { GetSession(); return View(); }
        public ActionResult CLXX_QCPL() { GetSession(); return View(); }
        public ActionResult CLXX_QCWXBY() { GetSession(); return View(); }
        public ActionResult CLXX_GHSPNJYC() { GetSession(); return View(); }
        public ActionResult CLXX_QCMRZS() { GetSession(); return View(); }
        public ActionResult CLXX_QCGZFH() { GetSession(); return View(); }
        public ActionResult CLXX_QCPJ() { GetSession(); return View(); }

        public JsonResult LoadCLXX()
        {
            return Json(CLCXBLL.LoadCLXX(Request["TYPE"], Request["ID"]));
        }
    }
}