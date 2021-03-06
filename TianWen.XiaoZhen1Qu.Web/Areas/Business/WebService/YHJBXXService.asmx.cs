﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Services;
using TianWen.Framework.Log;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.WebService
{
    /// <summary>
    /// YHJBXXService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class YHJBXXService : System.Web.Services.WebService
    {
        //获取验证码
        [WebMethod(EnableSession = true)]
        public string HQYZM(string SJ)
        {
            try
            {
                LoggerManager.Info("调用获取验证码服务", "手机：" + SJ);
                Random random = new Random();
                string checkcode = random.Next(100000, 999999).ToString(); //6位验证码
                Context.Session["CheckCode"] = checkcode;
                Context.Session["Time"] = DateTime.Now.ToLongTimeString();
                LoggerManager.Info("调用获取验证码服务", "验证码：" + checkcode);
                string smsText = "您的验证码是:" + checkcode + ",.如果非本人操作，请忽略本短信.";
                string targeturl = "http://utf8.sms.webchinese.cn/?Uid=rebirth033&Key=c64526354aba20e8f3d4&smsMob= " + SJ + " & smsText = " + smsText;

                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.Timeout = 30 * 60 * 1000;
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                string strRet = ser.ReadToEnd();
                LoggerManager.Info("调用获取验证码服务", "返回结果：1");
                return "1";
            }
            catch (Exception ex)
            {
                LoggerManager.Info("调用获取验证码服务", "错误：" + ex.Message);
                return "0";
            }
        }
    }
}
