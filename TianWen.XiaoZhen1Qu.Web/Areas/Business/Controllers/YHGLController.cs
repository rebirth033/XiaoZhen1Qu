using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class YHGLController : BaseController
    {
        public IYHDLXXBLL YHDLXXBLL { get; set; }
        public ActionResult YHGL()
        {
            return View();
        }

        public JsonResult AutoLogin()
        {
            string username = string.Empty;
            string sessionID = string.Empty;
            if (Request.Cookies["autoLoginUser"] != null)
            {
                username = Request.Cookies["autoLoginUser"].Value;
            }
            if (Request.Cookies["sessionID"] != null)
            {
                sessionID = Request.Cookies["sessionID"].Value;
            }

            return Json(YHDLXXBLL.AutoLogin(username, sessionID));

        }
    }
}