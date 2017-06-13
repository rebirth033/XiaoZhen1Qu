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

        public JsonResult ValidateCheckCode()
        {
            string YZM = Request["YZM"];
            //生成的验证码被保存到session中
            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (YZM == checkcode)
                    return Json(new { Result = EnResultType.Success });
                else
                    return Json(new { Result = EnResultType.Failed });
            }
            else
                return Json(new { Result = EnResultType.Failed });
        }

    }
}