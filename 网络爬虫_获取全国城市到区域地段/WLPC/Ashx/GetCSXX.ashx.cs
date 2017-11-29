using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Data.OracleClient;
using System.Net.PeerToPeer.Collaboration;
using CommonClassLib.Helper;
using Newtonsoft.Json;

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
                pageinfo = "北京,1|上海,2|重庆,37|天津,18|合肥,837|芜湖,2045|蚌埠,3470|阜阳,2325|淮南,2319|安庆,3251|宿州,3359|六安,2328|淮北,9357|滁州,10266|马鞍山,2039|铜陵,10285|宣城,5633|亳州,2329|黄山,2323|池州,10260|巢湖,10229|和县,10892|霍邱,11226|桐城,11296|宁国,5645|天长,10273|福州,304|厦门,606|泉州,291|莆田,2429|漳州,710|宁德,7951|三明,2048|南平,10291|龙岩,6752|武夷山,10761|石狮,296|晋江,297|南安,293|龙海,713|深圳,4|广州,3|东莞,413|佛山,222|中山,771|珠海,910|惠州,722|江门,629|汕头,783|湛江,791|肇庆,901|茂名,679|揭阳,927|梅州,9389|清远,7303|阳江,2284|韶关,2192|河源,10467|云浮,10485|汕尾,9449|潮州,10461|台山,11263|阳春,8566|顺德,8716|惠东,725|博罗,726|海丰,9444|南宁,845|柳州,7133|桂林,1039|玉林,2337|梧州,2046|北海,10536|贵港,6770|钦州,2335|百色,10513|河池,2340|来宾,10552|贺州,10549|防城港,10539|崇左,10524|贵阳,2015|遵义,7620|黔东南,9363|黔南,10492|六盘水,10506|毕节,10564|铜仁,10417|安顺,7468|黔西南,10434|仁怀,7628|兰州,952|天水,8601|白银,10304|庆阳,10475|平凉,7154|酒泉,10387|张掖,10454|武威,10448|定西,10322|金昌,7428|陇南,10415|临夏,7112|嘉峪关,10362|甘南,10343|海口,2053|三亚,2422|五指山,9952|三沙,13722|琼海,10136|文昌,9984|万宁,10022|屯昌,10044|琼中,10064|陵水,10184|东方,10250|定安,10303|澄迈,10331|保亭,10367|白沙,10380|儋州,10394|郑州,342|洛阳,556|新乡,1016|南阳,592|许昌,977|平顶山,1005|安阳,1096|焦作,3266|商丘,1029|开封,2342|濮阳,2346|周口,933|信阳,8694|驻马店,1067|漯河,2347|三门峡,9317|鹤壁,2344|济源,9918|明港,8541|鄢陵,9123|禹州,979|长葛,9344|灵宝,9307|杞县,7389|汝州,1010|项城,935|偃师,7121|长垣,5936|哈尔滨,202|大庆,375|齐齐哈尔,5853|牡丹江,3489|绥化,6718|佳木斯,6776|鸡西,7289|双鸭山,9837|鹤岗,9061|黑河,9862|伊春,9773|七台河,9848|大兴安岭,9878|武汉,158|宜昌,858|襄阳,891|荆州,3479|十堰,2032|黄石,1734|孝感,3434|黄冈,2299|恩施,2302|荆门,2296|咸宁,9617|鄂州,9709|随州,9656|潜江,9669|天门,9517|仙桃,9736|神农架,9605|宜都,864|汉川,3439|枣阳,896|长沙,414|株洲,1086|益阳,10198|常德,872|衡阳,914|湘潭,2047|岳阳,821|郴州,5695|邵阳,2303|怀化,5756|永州,2307|娄底,9481|湘西,10219|张家界,6788|醴陵,1091|石家庄,241|保定,424|唐山,276|廊坊,772|邯郸,572|秦皇岛,1078|沧州,652|邢台,751|衡水,993|张家口,3328|承德,6760|定州,8398|馆陶,8706|张北,11201|赵县,9048|正定,3198|迁安市,284|任丘,656|三河,776|武安,577|雄安新区,111234|燕郊,12730|涿州,428|苏州,5|南京,172|无锡,93|常州,463|徐州,471|南通,394|扬州,637|盐城,613|淮安,968|连云港,2049|泰州,693|宿迁,2350|镇江,645|沭阳,5772|大丰,11279|如皋,397|启东,400|溧阳,469|海门,399|东海,2147|扬中,649|兴化,699|新沂,478|泰兴,696|如东,402|邳州,477|沛县,11349|靖江,698|建湖,618|海安,401|东台,615|丹阳,648|宝应县,14451|灌南,2150|灌云,2148|姜堰,697|金坛,468|昆山,16|泗洪,5958|泗阳,5959|南昌,669|赣州,2363|九江,2247|宜春,5709|吉安,2364|上饶,10120|萍乡,2248|抚州,10134|景德镇,2360|新余,10115|鹰潭,3209|永新,11077|乐平,9048|长春,319|吉林,700|四平,10171|延边,3184|松原,2315|白城,5918|通化,10159|白山,10179|辽源,2501|公主岭,10171|沈阳,188|大连,147|鞍山,523|锦州,2354|抚顺,5722|营口,5898|盘锦,2041|朝阳,10106|丹东,3445|辽阳,2038|本溪,5845|葫芦岛,10088|铁岭,6729|阜新,10097|庄河,3306|瓦房店,3279|银川,2054|吴忠,9962|石嘴山,9971|中卫,9951|固原,2421|呼和浩特,811|包头,801|赤峰,6700|鄂尔多斯,2037|通辽,10015|呼伦贝尔,10039|巴彦淖尔市,10070|乌兰察布,9993|锡林郭勒,2408|兴安盟,9976|乌海,2404|阿拉善盟,10083|海拉尔,2043|西宁,2052|海西,9902|海北,9917|果洛,9936|海东,9909|黄南,9896|玉树,9888|海南,10574|青岛,122|济南,265|烟台,228|潍坊,362|临沂,505|淄博,385|济宁,450|泰安,686|聊城,882|威海,518|枣庄,961|德州,728|日照,3177|东营,623|菏泽,5632|滨州,944|莱芜,2292|章丘,8680|垦利,11313|诸城,9146|寿光,369|龙口,233|曹县,5638|单县,5636|肥城,690|高密,371|广饶,627|桓台,7335|莒县,3180|莱州,235|蓬莱,237|青州,367|荣成,522|乳山,520|滕州,967|新泰,689|招远,3325|邹城,455|邹平,946|太原,740|临汾,5669|大同,6964|运城,5653|晋中,8854|长治,6921|晋城,3350|阳泉,8760|吕梁,3222|忻州,3453|朔州,9871|临猗,9193|清徐,10908|西安,483|咸阳,7453|宝鸡,2044|渭南,5733|汉中,3163|榆林,5942|延安,8973|安康,3157|商洛,9854|铜川,9832|神木,5944|成都,102|绵阳,1057|德阳,2373|南充,2378|宜宾,2380|自贡,6745|乐山,3237|泸州,2372|达州,9799|内江,5928|遂宁,9688|攀枝花,2371|眉山,9704|广安,2381|资阳,6803|凉山,9717|广元,9749|雅安,9687|巴中,9811|阿坝,9817|甘孜,9764|安岳,6806|广汉,8719|简阳,6805|仁寿,9706|乌鲁木齐,984|昌吉,8582|巴音郭楞,9530|伊犁,9472|阿克苏,9499|喀什,9326|哈密,7452|克拉玛依,2042|博尔塔拉,9529|吐鲁番,9475|和田,9489|石河子,9551|克孜勒苏,9519|阿拉尔,9539|五家渠,9562|图木舒克,9559|库尔勒,7168|阿勒泰,18837|塔城,18845|拉萨,2055|日喀则,9615|山南,9576|林芝,9646|昌都,9648|那曲,9618|阿里,9678|日土,9682|改则,9684|昆明,541|曲靖,2389|大理,2398|红河,2394|玉溪,2040|丽江,2392|文山,2395|楚雄,2393|西双版纳,2397|昭通,9409|德宏,9437|普洱,9444|保山,2390|临沧,9422|迪庆,9432|怒江,9462|杭州,79|宁波,135|温州,330|金华,531|嘉兴,497|台州,403|绍兴,355|湖州,831|丽水,7921|衢州,6793|舟山,8481|乐清,13950|瑞安,13951|义乌,12291|余姚,5333|诸暨,357|象山,6738|温岭,408|桐乡,502|慈溪,5334|长兴,834|嘉善,14357|海宁,500|德清,835|东阳,536|安吉,836|苍南,7579|临海,407|永康,537|玉环,409";
                string[] list = pageinfo.Split('|');
                string connString = "User ID=c##infotownlet;Password=infotownlet;Data Source=10.0.6.1/orcl;";
                OracleConnection conn = new OracleConnection(connString);
                OracleCommand command = new OracleCommand();
                command.Connection = conn;
                conn.Open();

                string pattern = string.Empty;
                Regex regex = new Regex(pattern);
                for (int i = 0; i < list.Length; i++)
                {
                    string text = list[i].Split(',')[0];
                    string id = list[i].Split(',')[1];
                    string sql = string.Format("select codeid from codes_district where typename='市级' and codename='{0}'", text);
                    command.CommandText = sql;
                    object tempvalue = command.ExecuteScalar();
                    if (tempvalue != null)
                    {
                        if (tempvalue == "362")
                        {

                        }
                        url = "http://post.58.com/hy/" + id + "/96/s5?PGTID=0d500000-0013-02c3-a614-4be5706c8a56&ClickID=2";
                        pageinfo = GetPageInfo(url);
                        pattern = "\"localArea\":(?<text>(.*)),\"qqlist";
                        regex = new Regex(pattern);
                        MatchCollection matches = regex.Matches(pageinfo);
                        var result = matches[0].Groups["text"].Value.Replace(';', ' ');
                        pattern = "localArea\",\"text\":\"\",\"values\":(?<text>(.*))}";
                        regex = new Regex(pattern);
                        matches = regex.Matches(result);
                        result = matches[0].Groups["text"].Value;
                        List<first> firstlist = JsonHelper.ConvertJsonToObject<List<first>>(result);
                        foreach (first obj in firstlist)
                        {
                            sql = "insert into codes_district values(S_DISTRICT.NEXTVAL,'县区级','" + obj.text + "','1',1," + tempvalue + ",null)";
                            command.CommandText = sql;
                            command.ExecuteNonQuery();

                            sql = string.Format("select codeid from codes_district where typename='县区级' and codename='{0}'", obj.text);
                            command.CommandText = sql;
                            object tempresult = command.ExecuteScalar();

                            foreach (third thirdobj in obj.children[0].values)
                            {
                                sql = "insert into codes_district values(S_DISTRICT.NEXTVAL,'街道级','" + thirdobj.text + "','1',1," + tempresult + ",null)";
                                command.CommandText = sql;
                                command.ExecuteNonQuery();
                            }
                        }
                    }
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

        public class LocalArea
        {
            public int id { get; set; }
            public string name { get; set; }
            public string text { get; set; }
            public List<first> values { get; set; }
        }

        public class first
        {
            //public int id { get; set; }
            //public string name { get; set; }
            public string text { get; set; }
            public List<second> children { get; set; }
            public string val { get; set; }
        }

        public class second
        {
            public int id { get; set; }
            public string name { get; set; }
            public List<third> values { get; set; }
        }

        public class third
        {
            public int order { get; set; }
            public string text { get; set; }
            public string val { get; set; }
        }
    }
}