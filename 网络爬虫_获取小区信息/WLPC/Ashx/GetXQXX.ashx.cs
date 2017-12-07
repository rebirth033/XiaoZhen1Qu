﻿using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
            string url = context.Request["url"];
            string pageinfo, childpageinfo;
            try
            {
                //pageinfo = "anshan,鞍山|anyang,安阳|anqing,安庆|ankang,安康|anshun,安顺|aba,阿坝|akesu,阿克苏|ali,阿里|alaer,阿拉尔|alashanm,阿拉善盟|aomen,澳门|  beijing,北京|baoding,保定|baotou,包头|binzhou,滨州|baoji,宝鸡|bengbu,蚌埠|benxi,本溪|beihai,北海|bayinguoleng,巴音郭楞|bazhong,巴中|bayannaoer,巴彦淖尔市|bozhou,亳州|baiyin,白银|baicheng,白城|baise,百色|baishan,白山|boertala,博尔塔拉|bijie,毕节|baoshan,保山|chengdu,成都|chongqing,重庆|cs,长沙|cz,常州|cc,长春|cangzhou,沧州|changji,昌吉|chifeng,赤峰|changde,常德|chenzhou,郴州|chengde,承德|changzhi,长治|chizhou,池州|chuzhou,滁州|chaoyang,朝阳|chaozhou,潮州|chuxiong,楚雄|chaohu,巢湖|changdu,昌都|changge,长葛|chongzuo,崇左|dalian,大连|dg,东莞|deyang,德阳|dali,大理|dezhou,德州|dongying,东营|daqing,大庆|dandong,丹东|datong,大同|dazhou,达州|dafeng,大丰|dehong,德宏|dingzhou,定州|diqing,迪庆|dingxi,定西|dxanling,大兴安岭|eerduosi,鄂尔多斯|enshi,恩施|ezhou,鄂州|foshan,佛山|fz,福州|fuyang,阜阳|fushun,抚顺|fuxin,阜新|fuzhoushi,抚州|fangchenggang,防城港|guangzhou,广州|gy,贵阳|guilin,桂林|ganzhou,赣州|guangan,广安|guigang,贵港|guangyuan,广元|ganzi,甘孜|gannan,甘南|guantao,馆陶|guoluo,果洛|guyuan,固原|hangzhou,杭州|hf,合肥|heb,哈尔滨|haikou,海口|huizhou,惠州|handan,邯郸|huhehaote,呼和浩特|huanggang,黄冈|huainan,淮南|huangshan,黄山|hebi,鹤壁|hengyang,衡阳|huzhou,湖州|hengshui,衡水|hanzhong,汉中|huaian,淮安|huangshi,黄石|heze,菏泽|huaihua,怀化|huaibei,淮北|huludao,葫芦岛|heyuan,河源|honghe,红河|hami,哈密|hegang,鹤岗|hulunbeier,呼伦贝尔|haibei,海北|haidong,海东|hainan,海南|hechi,河池|heihe,黑河|hexian,和县|hezhou,贺州|hailaer,海拉尔|huoqiu,霍邱|hetian,和田|huangnan,黄南|hexi,海西|jinan,济南|jx,嘉兴|jilin,吉林|jiangmen,江门|jingmen,荆门|jinzhou,锦州|jingdezhen,景德镇|jian,吉安|jining,济宁|jinhua,金华|jieyang,揭阳|jinzhong,晋中|jiujiang,九江|jiaozuo,焦作|jincheng,晋城|jingzhou,荆州|jiamusi,佳木斯|jiuquan,酒泉|jixi,鸡西|jiyuan,济源|jinchang,金昌|jiayuguan,嘉峪关|jiangyin,江阴|km,昆明|ks,昆山|kaifeng,开封|kashi,喀什|kelamayi,克拉玛依|kenli,垦利|lezilesu,克孜勒苏|lanzhou,兰州|langfang,廊坊|luoyang,洛阳|liuzhou,柳州|laiwu,莱芜|luan,六安|luzhou,泸州|lijiang,丽江|linyi,临沂|liaocheng,聊城|lianyungang,连云港|lishui,丽水|loudi,娄底|leshan,乐山|liaoyang,辽阳|lasa,拉萨|linfen,临汾|longyan,龙岩|luohe,漯河|liangshan,凉山|liupanshui,六盘水|liaoyuan,辽源|laibin,来宾|lingcang,临沧|linxia,临夏|linyishi,临猗|linzhi,林芝|longnan,陇南|lvliang,吕梁|mianyang,绵阳|maoming,茂名|maanshan,马鞍山|mudanjiang,牡丹江|meishan,眉山|meizhou,梅州|minggang,明港|nanjing,南京|nb,宁波|nc,南昌|nanning,南宁|nantong,南通|nanchong,南充|nanyang,南阳|ningde,宁德|neijiang,内江|nanping,南平|naqu,那曲|nujiang,怒江|panzhihua,攀枝花|pingdingsha,平顶山|panjin,盘锦|pingxiang,萍乡|puyang,濮阳|putian,莆田|puer,普洱|pingliang,平凉|qd,青岛|qinhuangdao,秦皇岛|quanzhou,泉州|qujing,曲靖|qiqihaer,齐齐哈尔|quzhou,衢州|qingyuan,清远|qinzhou,钦州|qingyang,庆阳|qiandongnan,黔东南|qianjiang,潜江|qingxu,清徐|qiannan,黔南|qitaihe,七台河|qianxinan,黔西南|rizhao,日照|rikeze,日喀则|ruian,瑞安|shanghai,上海|shenzhen,深圳|suzhou,苏州|sjz,石家庄|sy,沈阳|sanya,三亚|shaoxing,绍兴|shantou,汕头|shiyan,十堰|sanmenxia,三门峡|sanming,三明|shaoguan,韶关|shangqiu,商丘|suqian,宿迁|suihua,绥化|shaoyang,邵阳|suining,遂宁|shangrao,上饶|siping,四平|shihezi,石河子|shunde,顺德|suzhoushi,宿州|songyuan,松原|shuyang,沭阳|shizuishan,石嘴山|suizhou,随州|shuozhou,朔州|shanwei,汕尾|sansha,三沙|shangluo,商洛|shannan,山南|shennongjia,神农架|shuangyashan,双鸭山|tianjin,天津|ty,太原|taizhou,泰州|tangshan,唐山|taian,泰安|taiz,台州|tieling,铁岭|tongliao,通辽|tongling,铜陵|tianshui,天水|tonghua,通化|taishan,台山|tongchuan,铜川|tulufan,吐鲁番|tianmen,天门|tumushuke,图木舒克|tongcheng,桐城|tongren,铜仁|taiwan,台湾|taicang,太仓|wuhan,武汉|wuxi,无锡|weihai,威海|weifang,潍坊|wulumuqi,乌鲁木齐|wenzhou,温州|wuhu,芜湖|wuzhou,梧州|weinan,渭南|wuhai,乌海|wenshan,文山|wuwei,武威|wulanchabu,乌兰察布|wafangdian,瓦房店|wujiaqu,五家渠|wuyishan,武夷山|wuzhong,吴忠|wuzhishan,五指山|xa,西安|xm,厦门|xuzhou,徐州|xiangtan,湘潭|xiangyang,襄阳|xinxiang,新乡|xinyang,信阳|xianyang,咸阳|xingtai,邢台|xiaogan,孝感|xining,西宁|xuchang,许昌|xinzhou,忻州|xuancheng,宣城|xianning,咸宁|xinganmeng,兴安盟|xinyu,新余|bannan,西双版纳|xianggang,香港|xiangxi,湘西|xiantao,仙桃|xilinguole,锡林郭勒盟|yt,烟台|yangzhou,扬州|yichang,宜昌|yinchuan,银川|yangjiang,阳江|yongzhou,永州|yulinshi,玉林|yancheng,盐城|yueyang,岳阳|yuncheng,运城|yichun,宜春|yingkou,营口|yulin,榆林|yibin,宜宾|yiyang,益阳|yiwu,义乌|yuxi,玉溪|yili,伊犁|yangquan,阳泉|yanan,延安|yingtan,鹰潭|yanbian,延边|yufu,云浮|yaan,雅安|yangchun,阳春|yanling,鄢陵|yichunshi,伊春|yushu,玉树|yueqing,乐清|yuzhou,禹州|yongxin,永新|zhengzhou,郑州|zh,珠海|zs,中山|zhenjiang,镇江|zibo,淄博|zhangjiakou,张家口|zhuzhou,株洲|zhangzhou,漳州|zhanjiang,湛江|zhaoqing,肇庆|zaozhuang,枣庄|zhoushan,舟山|zunyi,遵义|zhumadian,驻马店|zigong,自贡|ziyang,资阳|zhoukou,周口|zhangqiu,章丘|zhangjiajie,张家界|zhucheng,诸城|zhuanghe,庄河|zhengding,正定|zhangbei,张北|zhangye,张掖|zhaotong,昭通|weizhong,中卫|zhaoxian,赵县";
                pageinfo = "anshan,鞍山";
                string[] list = pageinfo.Split('|');
                string connString = "User ID=c##infotownlet;Password=infotownlet;Data Source=10.0.6.1/orcl;";
                OracleConnection conn = new OracleConnection(connString);
                OracleCommand command = new OracleCommand();
                command.Connection = conn;
                conn.Open();
                string sql = string.Empty;
                string pattern = string.Empty;
                Regex regex = new Regex(pattern);

                for (int i = 0; i < list.Length; i++)
                {
                    string id = list[i].Split(',')[0];
                    string text = list[i].Split(',')[1];
                    url = "https://www.anjuke.com/" + list[i].Split(',')[0] + "/cm/";
                    pageinfo = GetPageInfo(url);
                    pattern = "<a class=\"P2a\" href=\"(?<url>([^\"])*)\">(?<text>(.*?))</a>";
                    regex = new Regex(pattern);
                    MatchCollection matches = regex.Matches(pageinfo);

                    for (int j = 0; j < matches.Count; j++)
                    {
                        pattern = "<em><a(\\s+(href=\"(?<url>([^\"])*)\"|'([^'])*'|\\w+=\"(([^\"])*)\"|'([^'])*'))+>(?<text>(.*?))</a></em>";
                        for (int k = 1; k < 30; k++)
                        {
                            url = matches[j].Groups["url"].Value + "p" + k;
                            pageinfo = GetPageInfo(url);
                            regex = new Regex(pattern);
                            matches = regex.Matches(pageinfo);
                            for (int l = 0; l < matches.Count; l++)
                            {
                                sql = "insert into codes_xqjbxx(xqjbxxid,xqmc) values(S_XQJBXX.NEXTVAL,'" + matches[l].Groups["text"].Value + "')";
                                command.CommandText = sql;
                                command.ExecuteNonQuery();
                            }
                        }

                    }
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