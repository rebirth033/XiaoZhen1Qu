﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
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
            string YZM = Request["YZM"];
            //生成的验证码被保存到session中
            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (YZM == checkcode)
                {
                    string json = Request["Json"];
                    YHJBXX yhjbxx = JsonHelper.ConvertJsonToObject<YHJBXX>(json);
                    object result = YHJBXXBLL.CreateBasic(yhjbxx);
                    Session["YHM"] = yhjbxx.YHM;
                    return Json(result);
                }
                else
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误或过期，请重新获取", Type = 1 });
            }
            else
                return Json(new { Result = EnResultType.Failed, Message = "请点击获取验证码按钮", Type = 1 });
        }

        public JsonResult GetYZM()
        {
            string SJ = Request["SJ"];

            Random random = new Random();
            string checkcode = random.Next(100000, 999999).ToString(); //6位验证码
            Session["CheckCode"] = checkcode;
            Session["Time"] = DateTime.Now.ToLongTimeString();

            string smsText = "您的验证码是:" + checkcode + ",.如果非本人操作，请忽略本短信.";
            string targeturl = "http://utf8.sms.webchinese.cn/?Uid=rebirth033&Key=c64526354aba20e8f3d4&smsMob=" + SJ + "&smsText=" + smsText;

            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
            hr.Timeout = 30 * 60 * 1000;
            hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            hr.Method = "GET";
            WebResponse hs = hr.GetResponse();
            Stream sr = hs.GetResponseStream();
            StreamReader ser = new StreamReader(sr, Encoding.Default);
            string strRet = ser.ReadToEnd();

            //return Json(new { Result = EnResultType.Success, YZM = checkcode });
            return Json(new { Result = EnResultType.Success });
        }

        public JsonResult ValidateSJ()
        {
            string SJ = Request["SJ"];

            if (YHJBXXBLL.ValidateSJ(SJ) == "0")
            {
                return Json(new { Result = EnResultType.Success });
            }
            else
            {
                return Json(new { Result = EnResultType.Failed, Message = "手机号已存在" });
            }
        }
    }
}