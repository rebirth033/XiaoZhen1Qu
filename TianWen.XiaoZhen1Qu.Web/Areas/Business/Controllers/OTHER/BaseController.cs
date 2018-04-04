using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.Nhibernate.TianWen.Nhibernate.Repository;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BaseController : Controller
    {
        public static IRepository DataFactory = DbFactory.Instance.GetRepository();

        public void GetSession()
        {
            if (Session["XZQ"] == null)
            {
                GetUserIp();
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
            if (!string.IsNullOrEmpty(fwzp))
            {
                string[] zps = fwzp.Split(',');
                foreach (var zp in zps)
                {
                    PHOTOS photo = new PHOTOS();
                    photo.PHOTOURL = zp;
                    photo.PHOTONAME = photo.PHOTOURL.Substring(photo.PHOTOURL.LastIndexOf('/') + 1, photo.PHOTOURL.Length - photo.PHOTOURL.LastIndexOf('/') - 1);
                    photos.Add(photo);
                }
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

        /// <summary>
        /// 客户端ip(访问用户)
        /// </summary>
        public void GetUserIp()
        {
            string realRemoteIP = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                realRemoteIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0];
            }
            if (string.IsNullOrEmpty(realRemoteIP))
            {
                realRemoteIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(realRemoteIP))
            {
                realRemoteIP = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            string PostUrl = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?ip=" + realRemoteIP;
            string res = GetDataByPost(PostUrl);//该条请求返回的数据为：res=1\t115.193.210.0\t115.194.201.255\t中国\t浙江\t杭州\t电信

            string[] arr = getAreaInfoList(res);
            Session["XZQ"] = arr[1].Trim();
            DataTable dt =DataFactory.GetDataTable(string.Format("select codeid from codes_district where codename ='{0}'",arr[1].Trim()));
            if (dt.Rows.Count > 0)
                Session["XZQDM"] = dt.Rows[0][0];
            ViewData["XZQ"] = arr[1].Trim();
            LoggerManager.Info("用户ID", "用户ip:" + realRemoteIP + ",所在城市:" + arr[1].Trim());
        }

        public string GetDataByPost(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            string s = "anything";
            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(s);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = requestBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
            string backstr = sr.ReadToEnd();
            sr.Close();
            res.Close();
            return backstr;
        }

        public static string[] getAreaInfoList(string ipData)
        {
            //1\t115.193.210.0\t115.194.201.255\t中国\t浙江\t杭州\t电信
            string[] areaArr = new string[10];
            string[] newAreaArr = new string[2];
            try
            {
                //取所要的数据，这里只取省市
                areaArr = ipData.Split('\t');
                newAreaArr[0] = areaArr[4];//省
                newAreaArr[1] = areaArr[5];//市
            }
            catch (Exception e)
            {
                // TODO: handle exception
            }
            return newAreaArr;
        }
    }
}