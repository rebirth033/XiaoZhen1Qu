using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.BLL;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class GRZLController : BaseController
    {
        public IYHJBXXBLL YHJBXXBLL { get; set; }
        public ActionResult GRZL()
        {
            return View();
        }

        public ActionResult HBSJ()
        {
            return View();
        }

        public ActionResult YXYZ()
        {
            return View();
        }

        public ActionResult YXYZCG()
        {
            return View();
        }

        public JsonResult SaveXTTX()
        {
            object result = YHJBXXBLL.UpdateTX(Request["YHID"], Request["TX"]);
            return Json(result);
        }

        public JsonResult GetGRZL()
        {
            object result = YHJBXXBLL.GetObjByID(Request["YHID"]);
            return Json(result);
        }

        public JsonResult UpdateYHM()
        {
            object result = YHJBXXBLL.UpdateYHM(Request["YHID"], Request["YHM"]);
            return Json(result);
        }

        public JsonResult UpdateSJ()
        {
            object result = YHJBXXBLL.UpdateSJ(Request["YHID"], Request["SJ"]);
            return Json(result);
        }

        public JsonResult SendEmail()
        {
            object result = YHJBXXBLL.SendEmail(Request["YHID"], Request["YX"]);
            return Json(result);
        }
    }
}