using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class YHJBXXController : BaseController
    {
        public IYHJBXXBLL YHJBXXBLL { get; set; }
        public ActionResult YHJBXX()
        {
            return View();
        }

        public JsonResult Register()
        {
            string json = Request["Json"];
            YHJBXX yhjbxx = JsonHelper.ConvertJsonToObject<YHJBXX>(json);
            object result = YHJBXXBLL.CreateBasic(yhjbxx);

            return Json(result);
        }
	}
}