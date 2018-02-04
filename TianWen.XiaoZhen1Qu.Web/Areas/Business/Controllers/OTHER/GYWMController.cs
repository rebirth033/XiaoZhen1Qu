using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class GYWMController : BaseController
    {
        //public IGYWMBLL GYWMBLL { get; set; }

        public ActionResult GYWM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        //public JsonResult LoadDL()
        //{
        //    return Json(GYWMBLL.LoadDL());
        //}
    }
}