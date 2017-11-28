using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Data.OracleClient;

namespace WLPC.Ashx
{
    /// <summary>
    /// GetXZQXX 的摘要说明
    /// </summary>
    public class GetCSXX : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request["url"];
            string code = string.Empty;
            string pageinfo, childpageinfo;
            try
            {
                pageinfo = GetPageInfo(url);

                string connString = "User ID=c##infotownlet;Password=infotownlet;Data Source=10.0.6.1/orcl;";
                OracleConnection conn = new OracleConnection(connString);
                OracleCommand command = new OracleCommand();
                command.Connection = conn;
                conn.Open();
                
                string pattern = "\"(?<text>(.*?))\"\\:\"[\\w]+\\|(?<value>(.*?))\"";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(pageinfo);
                for (int i = 0; i < matches.Count; i++)
                {
                    //string address = string.Empty;
                    //childpageinfo = GetPageInfo("http://www.tcmap.com.cn/" + xzq + "/" + matches[i].Groups["text"].Value + ".html");
                    //pattern = "<td  align=center  >  <strong><a href=/" + xzq + "/.*?.html  class=blue>(?<text>(.*?))</a></strong></td> <td  nowrap> (?<value>(.*?))</td>";
                    //regex = new Regex(pattern);
                    //MatchCollection childmatches = regex.Matches(childpageinfo);
                    //for (int j = 0; j < childmatches.Count; j++)
                    //{
                    //    if (childmatches[j].Groups["value"].Value.Length > 6)
                    //    {
                    //        code = childmatches[j].Groups["value"].Value;
                    //        string sql = string.Format("select code from district where code='{0}'", code);
                    //        command.CommandText = sql;
                    //        object tempvalue = command.ExecuteScalar();
                    //        if (tempvalue == null)
                    //        {
                    //            sql = "insert into district(name,code) values('" + childmatches[j].Groups["text"].Value + "','" + childmatches[j].Groups["value"].Value + "')";
                    //            command.CommandText = sql;
                    //            command.ExecuteNonQuery();
                    //        }
                    //    }
                    //}
                }
            }
            catch (System.Exception ex)
            {
                context.Response.Write(code + ex.Message);
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