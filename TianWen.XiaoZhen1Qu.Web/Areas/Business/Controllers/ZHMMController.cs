using System.Text;
using System.Web.Mvc;
using System.Xml;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZHMMController : BaseController
    {
        public IYHJBXXBLL YHJBXXBLL { get; set; }
        public ActionResult ZHMM()
        {
            return View();
        }

        public JsonResult QRZH()
        {
            string Value = Request["Value"];
            string TXYZM = Request["TXYZM"];
            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (TXYZM == checkcode)
                {
                    string result = YHJBXXBLL.GetObjByYHMOrSJ(Value);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return Json(new { Result = EnResultType.Success, Message = "验证成功" });
                    }
                    else
                    {
                        return Json(new { Result = EnResultType.Failed, Message = "账户不存在，请重新输入", Type = 2 });
                    }
                }
                else
                {
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误，请重新输入", Type = 1 });
                }
            }
            else
            {
                return Json(new { Result = EnResultType.Failed, Message = "验证码不存在", Type = 1 });
            }
        }
    }
}