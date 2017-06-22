using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class YHDLXXController : BaseController
    {
        public IYHJBXXBLL YHJBXXBLL { get; set; }

        public ActionResult YHDLXX()
        {
            return View();
        }

        public JsonResult Login()
        {
            string YZM = Request["YZM"];

            TimeSpan span = DateTime.Now.Subtract(Convert.ToDateTime(Session["Time"].ToString()));
            if (span.TotalSeconds > 60)
                return Json(new { Result = EnResultType.Failed, Message = "验证码过期，请重新获取" });
            //生成的验证码被保存到session中
            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (YZM == checkcode)
                {
                    return Json(new { Result = EnResultType.Success, Message = "登录成功" });
                }
                else
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误，请重新输入" });
            }
            else
                return Json(new { Result = EnResultType.Failed, Message = "请点击获取验证码按钮" });
        }
    }
}