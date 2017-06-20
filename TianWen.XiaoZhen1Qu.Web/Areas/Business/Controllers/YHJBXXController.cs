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

        public JsonResult ValidateYHM()
        {
            string YHM = Request["YHM"];
            if (string.IsNullOrEmpty(YHJBXXBLL.GetObjByYHM(YHM)))
                return Json(new { Result = EnResultType.Success });
            else
                return Json(new { Result = EnResultType.Failed });
        }

        public JsonResult GetYHM()
        {
            string SJ = Request["SJ"];
            Random random = new Random();
            string checkcode = random.Next(100000, 999999).ToString();//6位验证码
            Session["CheckCode"] = checkcode;

            string smsText = "欢迎您注册会员，您的验证码是:" + checkcode + ",请您在5分钟内填写.如非本人操作，请忽略本短信.";
            string targeturl = "http://utf8.sms.webchinese.cn/?Uid=rebirth033&Key=c64526354aba20e8f3d4&smsMob=" + SJ + "&smsText=" + smsText;

            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
            hr.Timeout = 30 * 60 * 1000;
            hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            hr.Method = "GET";
            WebResponse hs = hr.GetResponse();
            Stream sr = hs.GetResponseStream();
            StreamReader ser = new StreamReader(sr, Encoding.Default);
            string strRet = ser.ReadToEnd();

            return Json(new { Result = EnResultType.Success, Message = strRet });
        }
    }
}