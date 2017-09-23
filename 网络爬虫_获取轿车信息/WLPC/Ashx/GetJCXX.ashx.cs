using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Data.OracleClient;
using CommonClassLib.Helper;

namespace WLPC.Ashx
{
    /// <summary>
    /// GetXZQXX 的摘要说明
    /// </summary>
    public class GetJCXX : IHttpHandler
    {
        public class CX
        {
            public string val { get; set; }
            public string text { get; set; }
            public string makename { get; set; }
        }
        public class KS
        {
            public string caryear { get; set; }
            public string displacement { get; set; }
            public string gearbox { get; set; }
            public string price { get; set; }
            public string text { get; set; }
            public string value { get; set; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string sql = String.Empty;
            int ppcount = 30;
            int cxcount = 228;
            string ids = "408810,408844,420187,420263,420298,901010,681912,409261,409596,409658,409819,410181,410387,410595,410767,411111,411455,420587,431511,511490,661179,678306,754181,900960,670379,754171,754170,617884,901011,551029,411135,411439,411463,420648,717761,411611,412363,412398,412421,412455,420241,420306,431513,516802,553888,754484,754486,681910,412569,412596,413097,413201,413316,419797,420394,667826,681913,413179,420314,420346,517369,661192,901006,521267,413481,413505,413566,413659,413750,413937,414109,419822,507608,661199,719510,901007,901005,681911,681909,419983,420651,413876,414297,414477,414498,414548,414662,420386,420593,420650,431512,431514,681914,902042,414807,414845,414860,414911,661302,668113,668368,720768,754694,414815,414832,414998,415046,415137,415142,415266,415579,415738,420198,420317,420590,431515,667827,754600,754690,519653,683586,737604,415812,415891,415902,415955,416130,420048,667828,667829,900968,419994,420384,431516,415931,416072,525126,420236,420321,416172,416526,420325,525140,616566,681990,416805,417253,417686,661303,902043,417227,417330,417741,417826,417913,418029,418138,420343,420355,420603,554217,660767,678307,681638,754576,420069,667830,668044,754473,679616,418136,418243,418281,420332,554270,748246,681816,754710,418514,418789,419174,420115,420122,420340,553271,419006,419390,420143,507587,719942,902045,419444,419558,419610,420170,420291,754681,754593";
            string[] idarray = ids.Split(',');
            string pageinfo;
            try
            {
                string connString = "User ID=c##infotownlet;Password=infotownlet;Data Source=localhost/orcl;";
                OracleConnection conn = new OracleConnection(connString);
                OracleCommand command = new OracleCommand();
                command.Connection = conn;
                conn.Open();
                for (int i = 0; i < idarray.Length; i++)
                {
                    pageinfo = GetPageInfo("http://post.58.com/ajax?action=chexi&source=car&cateid=29&value=" + idarray[i]);
                    List<CX> CXs = JsonHelper.ConvertJsonToObject<List<CX>>(pageinfo);
                    for (int j = 0; j < CXs.Count; j++)
                    {
                        sql = "insert into codes_cl_jc values("+ cxcount + ",'轿车车系','" + CXs[j].text + "','" + CXs[j].makename + "'," + (j+1) + "," + ppcount + ")";
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        cxcount++;
                        pageinfo = GetPageInfo("http://post.58.com/ajax?action=chexingdetail&source=car&cateid=29&value=" + CXs[j].val);
                        List<KS> KSs = JsonHelper.ConvertJsonToObject<List<KS>>(pageinfo);
                        int kscount = cxcount;
                        for (int k = 0; k < KSs.Count; k++)
                        {
                            sql = "insert into codes_cl_jc values("+ kscount + ",'轿车款式','" + KSs[k].text + "','" + KSs[k].price + "'," + (k+1) + "," + (cxcount-1) + ")";
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                            kscount++;
                        }
                        cxcount = cxcount + KSs.Count;
                    }
                    ppcount++;
                }
            }
            catch (System.Exception ex)
            {
                //context.Response.Write(code + ex.Message);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("完成");
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}