using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SYController : BaseController
    {
        public ISYBLL SYBLL { get; set; }

        public ActionResult SY() { GetSession(); return View(); }
        public ActionResult FCSY() { GetSession(); return View(); }
        public ActionResult CLSY() { GetSession(); return View(); }
        public ActionResult ZPSY() { GetSession(); return View(); }
        public ActionResult CWSY() { GetSession(); return View(); }
        public ActionResult ESSY() { GetSession(); return View(); }
        public ActionResult SHFWSY() { GetSession(); return View(); }
        public ActionResult SWFWSY() { GetSession(); return View(); }
        public ActionResult JYPXSY() { GetSession(); return View(); }
        public ActionResult ZSJMSY() { GetSession(); return View(); }
        public ActionResult PFCGSY() { GetSession(); return View(); }

        public JsonResult LoadZXFBXX()
        {
            return Json(SYBLL.LoadZXFBXX());
        }

        public JsonResult LoadLBByJCXX()
        {
            return Json(SYBLL.LoadLBByJCXX(Request["LBID"], Request["JCXXID"]));
        }

        public JsonResult LoadSY_ML()
        {
            return Json(SYBLL.LoadSY_ML(Session["XZQ"].ToString()));
        }

        public JsonResult LoadFCSY()
        {
            return Json(SYBLL.LoadFCSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadCLSY()
        {
            return Json(SYBLL.LoadCLSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadCWSY()
        {
            return Json(SYBLL.LoadCWSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadESSY()
        {
            return Json(SYBLL.LoadESSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadZPSY()
        {
            return Json(SYBLL.LoadZPSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadHYLB()
        {
            return Json(SYBLL.LoadHYLB(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadSHFWTOP()
        {
            return Json(SYBLL.LoadSHFWTOP(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadSHFWSY()
        {
            return Json(SYBLL.LoadSHFWSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadSWFWTOP()
        {
            return Json(SYBLL.LoadSWFWTOP(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadSWFWSY()
        {
            return Json(SYBLL.LoadSWFWSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadJYPXTOP()
        {
            return Json(SYBLL.LoadJYPXTOP(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadJYPXSY()
        {
            return Json(SYBLL.LoadJYPXSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadZSJMTOP()
        {
            return Json(SYBLL.LoadZSJMTOP(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadZSJMSY()
        {
            return Json(SYBLL.LoadZSJMSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadPFCGTOP()
        {
            return Json(SYBLL.LoadPFCGTOP(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadPFCGSY()
        {
            return Json(SYBLL.LoadPFCGSY(Session["XZQDM"].ToString(), Session["XZQ"].ToString()));
        }

        public JsonResult LoadKeyWordByHZ()
        {
            return Json(SYBLL.LoadKeyWordByHZ(Request["SS"], Session["XZQ"].ToString()));
        }
        public JsonResult LoadKeyWordByPY()
        {
            return Json(SYBLL.LoadKeyWordByPY(Request["SS"], Session["XZQ"].ToString()));
        }
    }
}