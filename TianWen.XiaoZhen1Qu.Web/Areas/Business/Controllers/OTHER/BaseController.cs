using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CommonClassLib.Helper;
using Newtonsoft.Json;
using Spring.Objects.Factory.Parsing;
using TianWen.Nhibernate.TianWen.Nhibernate.Repository;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BaseController : Controller
    {
        public static IRepository DataFactory = DbFactory.Instance.GetRepository();

        public void GetSession()
        {
            object result = GetAdrByIp("60.205.226.255");
            if (Session["XZQ"] == null)
            {
                ViewData["XZQ"] = "北京";
                Session["XZQ"] = "北京";
                Session["XZQDM"] = "28";
            }
            else
            {
                ViewData["XZQ"] = Session["XZQ"];
            }
            ViewData["YHM"] = Session["YHM"];
        }

        public List<PHOTOS> GetTP(string fwzp)
        {
            List<PHOTOS> photos = new List<PHOTOS>();
            string[] zps = fwzp.Split(',');
            foreach (var zp in zps)
            {
                PHOTOS photo = new PHOTOS();
                photo.PHOTOURL = zp;
                photo.PHOTONAME = photo.PHOTOURL.Substring(photo.PHOTOURL.LastIndexOf('/') + 1, photo.PHOTOURL.Length - photo.PHOTOURL.LastIndexOf('/') - 1);
                photos.Add(photo);
            }
            return photos;
        }

        public JCXX CreateJCXX(YHJBXX yhjbxx, string json)
        {
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 3;//待审核
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + GetLBQCByLBID(jcxx.LBID);
            jcxx.XZQDM = int.Parse(Session["XZQDM"].ToString());
            return jcxx;
        }

        public string GetLBQCByLBID(int LBID)
        {
            CODES_XXLB xl = DataFactory.GetObjectById<CODES_XXLB>(LBID);
            CODES_XXLB dl = DataFactory.GetObjectById<CODES_XXLB>(xl.PARENTID);
            return dl.LBNAME + "-" + xl.LBNAME;
        }

        public string GetIP()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public string GetAdrByIp(string ip)
        {
            string url = "http://www.cz88.net/ip/";
            string regStr = "(?<=<span\\s*id=\\\"cz_addr\\\">).*?(?=</span>)";

            //得到网页源码
            string html = GetPageInfo(url);
            Regex reg = new Regex(regStr, RegexOptions.None);
            Match ma = reg.Match(html);
            html = ma.Value;
            string[] arr = html.Split(' ');
            return arr[0];
        }

        public string GetPageInfo(string url)
        {
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(url);
                myReq.Accept =
                    "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                myReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
                HttpWebResponse myRep = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = myRep.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}