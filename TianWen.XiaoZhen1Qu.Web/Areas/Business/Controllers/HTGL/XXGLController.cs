using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXGLController : BaseController
    {
        public IXXGLBLL XXGLBLL { get; set; }

        public ActionResult XXGL()
        {
            return View();
        }

        public ActionResult XXGLMX()
        {
            return View();
        }

        public JsonResult LoadYHXX()
        {
            YHJBXX YHJBXX = XXGLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return Json(XXGLBLL.LoadYHXX(YHJBXX.YHID, Request["TYPE"], Request["PageIndex"], Request["PageSize"]));
        }

        public JsonResult LoadYHXXMX()
        {
            YHJBXX YHJBXX = XXGLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return Json(XXGLBLL.LoadYHXXMX(YHJBXX.YHID, Request["YHXXID"]));
        }

        public JsonResult LoadUpYHXXMX()
        {
            YHJBXX YHJBXX = XXGLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return Json(XXGLBLL.LoadUpYHXXMX(YHJBXX.YHID, Request["YHXXID"]));
        }

        public JsonResult LoadDownYHXXMX()
        {
            YHJBXX YHJBXX = XXGLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return Json(XXGLBLL.LoadDownYHXXMX(YHJBXX.YHID, Request["YHXXID"]));
        }

        public JsonResult DeleteYHXX()
        {
            return Json(XXGLBLL.DeleteYHXX(Request["YHXXID"].Split(',')));
        }

        public JsonResult YDYHXX()
        {
            return Json(XXGLBLL.YDYHXX(Request["YHXXID"].Split(',')));
        }
        
    }
}