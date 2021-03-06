﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.Framework.Log;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class YHZCController : BaseController
    {
        public IYHZCBLL YHZCBLL { get; set; }

        public ActionResult YHZC()
        {
            return View();
        }

        //用户名密码注册
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
                    YHJBXX YHJBXX = JsonHelper.ConvertJsonToObject<YHJBXX>(json);
                    object result = YHZCBLL.CreateBasic(YHJBXX);
                    Session["YHM"] = YHJBXX.YHM;
                    return Json(result);
                }
                else
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误或过期，请重新获取", Type = 1 });
            }
            else
                return Json(new { Result = EnResultType.Failed, Message = "请点击获取验证码按钮", Type = 1 });
        }

        //手机号注册
        public JsonResult SJRegister()
        {
            try
            {
                string YZM = Request["YZM"];
                //生成的验证码被保存到session中
                if (Session["CheckCode"] != null)
                {
                    string checkcode = Session["CheckCode"].ToString();
                    if (YZM == checkcode)
                    {
                        YHJBXX YHJBXX = YHZCBLL.CreateBasicBySJ(Request["SJ"], Request["MM"]);
                        Session["YHM"] = YHJBXX.YHM;
                        LoggerManager.Info("用户注册成功", "用户：" + YHJBXX.YHM + "创建成功");
                        return Json(new { Result = EnResultType.Success });
                    }
                    else
                    {
                        LoggerManager.Info("用户注册失败", "验证码错误或过期，请重新获取");
                        return Json(new { Result = EnResultType.Failed, Message = "验证码错误或过期，请重新获取", Type = 1 });
                    }
                }
                else
                {
                    LoggerManager.Info("用户注册失败", "请点击获取验证码按钮");
                    return Json(new { Result = EnResultType.Failed, Message = "请点击获取验证码按钮", Type = 1 });
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Info("用户注册失败", ex.Message);
                return Json(new { Result = EnResultType.Failed, Message = ex.Message, Type = 1 });
            }
        }

        //获取验证码
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

            return Json(new { Result = EnResultType.Success, YZM = checkcode });
            return Json(new { Result = EnResultType.Success });
        }

        //验证手机号是否存在
        public JsonResult ValidateSJ()
        {
            string SJ = Request["SJ"];

            if (YHZCBLL.ValidateSJ(SJ) == "0")
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