using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace WLPC.Ashx
{
    /// <summary>
    /// GetXQXX 的摘要说明
    /// </summary>
    public class GetXQXX : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request["lianjie"];
            string page = context.Request["page"];
            string area = context.Request["area"];
            string pageinfo;
            try
            {
                pageinfo = GetPageInfo(url);

                string connString = "User ID=c##XIAOZHEN1QU;Password=XIAOZHEN1QU;Data Source=ORCL;";
                OracleConnection conn = new OracleConnection(connString);
                OracleCommand command = new OracleCommand();
                command.Connection = conn;
                conn.Open();

                string pattern = "<em><a(\\s+(href=\"(?<url>([^\"])*)\"|'([^'])*'|\\w+=\"(([^\"])*)\"|'([^'])*'))+>(?<text>(.*?))</a></em>";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(pageinfo);
                for (int i = 0; i < matches.Count; i++)
                {
                    string sql = "insert into xqjbxx values(s_xqjbxx.nextval,'" + matches[i].Groups["text"].Value + "','','" + page + "','" + area + "','')";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                context.Response.Write(ex.Message);
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
            return sr.ReadToEnd().ToString();
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