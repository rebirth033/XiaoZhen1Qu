using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class HFCZBLL : BaseBLL, IHFCZBLL
    {
        public object SearchMobilePhoneGuiSuArea(string YHID, string MobileNo)
        {
            string pageinfo = GetPageInfo("http://www.99cha.com/mobile/" + MobileNo + ".html");
            string pattern = "<li class=\"value\">(?<text>(.*?))</li>";
            List<string> values = new List<string>();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(pageinfo);
            for (int i = 0; i < matches.Count; i++)
            {
                values.Add(matches[i].Groups["text"].Value);
            }
            return new { Result = EnResultType.Success, Message = "获取成功!", Values = values };
        }

        public string GetPageInfo(string url)
        {
            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(url);
            myReq.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            myReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
            HttpWebResponse myRep = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = myRep.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
            return sr.ReadToEnd();
        }
    }
}
