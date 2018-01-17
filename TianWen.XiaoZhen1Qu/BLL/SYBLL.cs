using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.Models.CODES;
using TianWen.XiaoZhen1Qu.Interface;
using System.Data;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.FC;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.CL;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.CW;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.ES;
using CommonClassLib.Helper;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class SYBLL : BaseBLL, ISYBLL
    {
        public object LoadZXFBXX()
        {
            try
            {
                IList<JCXX> list = new List<JCXX>();
                list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE DH NOT LIKE '%票务%' ORDER BY CJSJ DESC"));

                foreach (var jcxx in list)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadLBByJCXX(string lbid, string jcxxid)
        {
            try
            {
                string fbtable = DAO.Repository.ExecuteScalar(string.Format("select fbtable from xxlb where lbid={0}", lbid)).ToString();
                return
                    new
                    {
                        Result = EnResultType.Success,
                        id =
                            DAO.Repository.ExecuteScalar(string.Format("select id from {0} where jcxxid='{1}'", fbtable,
                                jcxxid)).ToString()
                    };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadSY_ML(string xzq)
        {
            try
            {
                IList<CODES_SY_ML> list = new List<CODES_SY_ML>();
                list = DAO.Repository.GetObjectList<CODES_SY_ML>(String.Format("FROM CODES_SY_ML ORDER BY LBORDER,ID"));
                return new { Result = EnResultType.Success, list = list, xzq = xzq };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadFCSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));
                dt = DAO.Repository.GetDataTable("select a.*,b.*,x.* from jcxx a,fc_zzfjbxx b left join CODES_XQJBXX x on trim(b.xqmc) = x.xqmc where a.jcxxid = b.jcxxid and szs = '" + xzq + "' ");
                List<FC_ZZFView> zzfs = ConvertHelper.DataTableToList<FC_ZZFView>(dt);
                foreach (var jcxx in zzfs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.*,x.* from jcxx a,fc_hzfjbxx b left join CODES_XQJBXX x on trim(b.xqmc) = x.xqmc where a.jcxxid = b.jcxxid and szs = '" + xzq + "' ");
                List<FC_ZZFView> hzfs = ConvertHelper.DataTableToList<FC_ZZFView>(dt);
                foreach (var jcxx in hzfs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,fc_dzfjbxx b where a.jcxxid = b.jcxxid ");
                List<FC_DZFView> dzfs = ConvertHelper.DataTableToList<FC_DZFView>(dt);
                foreach (var jcxx in dzfs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.*,x.* from jcxx a,fc_esfjbxx b left join CODES_XQJBXX x on trim(b.xqmc) = x.xqmc where a.jcxxid = b.jcxxid ");
                List<FC_ESFView> esfs = ConvertHelper.DataTableToList<FC_ESFView>(dt);
                foreach (var jcxx in esfs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, zzfs = zzfs, hzfs = hzfs, dzfs = dzfs, esfs = esfs };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCLSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));
                IList<CODES_CL_JC> jcpp = DAO.GetObjectList<CODES_CL_JC>(string.Format("FROM CODES_CL_JC WHERE TYPENAME='轿车品牌' AND ISHOT='是' ORDER BY CODEORDER"));
                IList<CODES_CL> ddcpp = DAO.GetObjectList<CODES_CL>(string.Format("FROM CODES_CL WHERE TYPENAME='电动车品牌' ORDER BY CODEORDER"));
                IList<CODES_CL> mtcpp = DAO.GetObjectList<CODES_CL>(string.Format("FROM CODES_CL WHERE TYPENAME='摩托车品牌' ORDER BY CODEORDER"));
                IList<CODES_CL> hcpp = DAO.GetObjectList<CODES_CL>(string.Format("FROM CODES_CL WHERE TYPENAME='货车品牌' ORDER BY CODEORDER"));
                IList<CODES_CL> kcpp = DAO.GetObjectList<CODES_CL>(string.Format("FROM CODES_CL WHERE TYPENAME='客车品牌' ORDER BY CODEORDER"));
                IList<CODES_CL> gcccx = DAO.GetObjectList<CODES_CL>(string.Format("FROM CODES_CL WHERE TYPENAME='工程车车型' AND ISHOT = '是' ORDER BY CODEORDER"));
                IList<CODES_CL> zxcpp = DAO.GetObjectList<CODES_CL>(string.Format("FROM CODES_CL WHERE TYPENAME='自行车品牌' ORDER BY CODEORDER"));
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_jcjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_JCView> jcs = ConvertHelper.DataTableToList<CL_JCView>(dt);
                foreach (var jcxx in jcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_ddcjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_DDCView> ddcs = ConvertHelper.DataTableToList<CL_DDCView>(dt);
                foreach (var jcxx in ddcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_hcjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_HCView> hcs = ConvertHelper.DataTableToList<CL_HCView>(dt);
                foreach (var jcxx in hcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_kcjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_KCView> kcs = ConvertHelper.DataTableToList<CL_KCView>(dt);
                foreach (var jcxx in kcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_mtcjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_MTCView> mtcs = ConvertHelper.DataTableToList<CL_MTCView>(dt);
                foreach (var jcxx in mtcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_gccjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_GCCView> gccs = ConvertHelper.DataTableToList<CL_GCCView>(dt);
                foreach (var jcxx in gccs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_zxcjbxx b where a.jcxxid = b.jcxxid ");
                List<CL_ZXCView> zxcs = ConvertHelper.DataTableToList<CL_ZXCView>(dt);
                foreach (var jcxx in zxcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, jcs = jcs, jcpp = jcpp, ddcs = ddcs, ddcpp = ddcpp, hcs = hcs, hcpp = hcpp, kcs = kcs, kcpp = kcpp, mtcs = mtcs, mtcpp = mtcpp, gccs = gccs, gcccx = gcccx, zxcs = zxcs, zxcpp = zxcpp };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCWSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));
                IList<CODES_CW> cwgpz = DAO.GetObjectList<CODES_CW>(string.Format("FROM CODES_CW WHERE TYPENAME='宠物狗品种' ORDER BY CODEORDER"));
                IList<CODES_CW> cwmpz = DAO.GetObjectList<CODES_CW>(string.Format("FROM CODES_CW WHERE TYPENAME='宠物猫品种' ORDER BY CODEORDER"));
                IList<CODES_CW> hnyclb = DAO.GetObjectList<CODES_CW>(string.Format("FROM CODES_CW WHERE TYPENAME='花鸟鱼虫类别' ORDER BY CODEORDER"));
                IList<CODES_CW> cwfwlb = DAO.GetObjectList<CODES_CW>(string.Format("FROM CODES_CW WHERE TYPENAME='宠物服务类别' ORDER BY CODEORDER"));
                IList<CODES_CW> cwyplb = DAO.GetObjectList<CODES_CW>(string.Format("FROM CODES_CW WHERE TYPENAME='宠物用品/食品类别' ORDER BY CODEORDER"));
                IList<CODES_CW> cwgylb = DAO.GetObjectList<CODES_CW>(string.Format("FROM CODES_CW WHERE TYPENAME='宠物公益类别' ORDER BY CODEORDER"));
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_cwgjbxx b where a.jcxxid = b.jcxxid ");
                List<CW_CWGView> cwgs = ConvertHelper.DataTableToList<CW_CWGView>(dt);
                foreach (var jcxx in cwgs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_cwmjbxx b where a.jcxxid = b.jcxxid ");
                List<CW_CWMView> cwms = ConvertHelper.DataTableToList<CW_CWMView>(dt);
                foreach (var jcxx in cwms)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_hnycjbxx b where a.jcxxid = b.jcxxid");
                List<CW_HNYCView> hnycs = ConvertHelper.DataTableToList<CW_HNYCView>(dt);
                foreach (var jcxx in hnycs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_cwfwjbxx b where a.jcxxid = b.jcxxid ");
                List<CW_CWFWView> cwfws = ConvertHelper.DataTableToList<CW_CWFWView>(dt);
                foreach (var jcxx in cwfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_cwypspjbxx b where a.jcxxid = b.jcxxid ");
                List<CW_CWYPSPView> cwyps = ConvertHelper.DataTableToList<CW_CWYPSPView>(dt);
                foreach (var jcxx in cwyps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_cwgyjbxx b where a.jcxxid = b.jcxxid ");
                List<CW_CWGYView> cwgys = ConvertHelper.DataTableToList<CW_CWGYView>(dt);
                foreach (var jcxx in cwgys)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, cwgs = cwgs, cwgpz = cwgpz, cwms = cwms, cwmpz = cwmpz, hnycs = hnycs, hnyclb = hnyclb, cwfws = cwfws, cwfwlb = cwfwlb, cwyps = cwyps, cwyplb = cwyplb, cwgys = cwgys, cwgylb = cwgylb };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadESSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));
                IList<CODES_ES_SJSM> sjpp = DAO.GetObjectList<CODES_ES_SJSM>(string.Format("FROM CODES_ES_SJSM WHERE TYPENAME='手机品牌' ORDER BY CODEORDER"));
                IList<CODES_ES_SJSM> bjbdnpp = DAO.GetObjectList<CODES_ES_SJSM>(string.Format("FROM CODES_ES_SJSM WHERE TYPENAME='笔记本品牌' ORDER BY CODEORDER"));
                IList<CODES_ES_SJSM> pbdnpp = DAO.GetObjectList<CODES_ES_SJSM>(string.Format("FROM CODES_ES_SJSM WHERE TYPENAME='平板品牌' ORDER BY CODEORDER"));
                IList<CODES_ES_SJSM> smcplb = DAO.GetObjectList<CODES_ES_SJSM>(string.Format("FROM CODES_ES_SJSM WHERE TYPENAME='数码产品类别' ORDER BY CODEORDER"));
                IList<CODES_ES_SJSM> tsjlb = DAO.GetObjectList<CODES_ES_SJSM>(string.Format("FROM CODES_ES_SJSM WHERE TYPENAME='台式机/配件类别' ORDER BY CODEORDER"));
                IList<CODES_ES_JDJJBG> jyjdlb = DAO.GetObjectList<CODES_ES_JDJJBG>(string.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME='二手家电类别' ORDER BY CODEORDER"));
                IList<CODES_ES_JDJJBG> jyjjlb = DAO.GetObjectList<CODES_ES_JDJJBG>(string.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME='二手家具类别' ORDER BY CODEORDER"));
                IList<CODES_ES_JDJJBG> jjrylb = DAO.GetObjectList<CODES_ES_JDJJBG>(string.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME='家居/日用品类别' ORDER BY CODEORDER"));
                IList<CODES_ES_JDJJBG> bgyplb = DAO.GetObjectList<CODES_ES_JDJJBG>(string.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME='办公用品/设备类别' ORDER BY CODEORDER"));
                IList<CODES_ES_MYFZMR> myetlb = DAO.GetObjectList<CODES_ES_MYFZMR>(string.Format("FROM CODES_ES_MYFZMR WHERE TYPENAME='母婴/儿童用品/玩具类别' ORDER BY CODEORDER"));
                IList<CODES_ES_MYFZMR> fsxblb = DAO.GetObjectList<CODES_ES_MYFZMR>(string.Format("FROM CODES_ES_MYFZMR WHERE TYPENAME='服装/鞋帽/箱包类别' ORDER BY CODEORDER"));
                IList<CODES_ES_MYFZMR> mrbjlb = DAO.GetObjectList<CODES_ES_MYFZMR>(string.Format("FROM CODES_ES_MYFZMR WHERE TYPENAME='美容/保健类别' ORDER BY CODEORDER"));
                IList<CODES_ES_QTES> essblb = DAO.GetObjectList<CODES_ES_QTES>(string.Format("FROM CODES_ES_QTES WHERE TYPENAME='二手设备类别' ORDER BY CODEORDER"));

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_essjjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_SJSM_ESSJView> sjs = ConvertHelper.DataTableToList<ES_SJSM_ESSJView>(dt);
                foreach (var jcxx in sjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_bjbdnjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_SJSM_BJBDNView> bjbdns = ConvertHelper.DataTableToList<ES_SJSM_BJBDNView>(dt);
                foreach (var jcxx in bjbdns)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_pbdnjbxx b where a.jcxxid = b.jcxxid");
                List<ES_SJSM_PBDNView> pbdns = ConvertHelper.DataTableToList<ES_SJSM_PBDNView>(dt);
                foreach (var jcxx in pbdns)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_smcpjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_SJSM_SMCPView> smcps = ConvertHelper.DataTableToList<ES_SJSM_SMCPView>(dt);
                foreach (var jcxx in smcps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_tsjjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_SJSM_TSJView> tsjs = ConvertHelper.DataTableToList<ES_SJSM_TSJView>(dt);
                foreach (var jcxx in tsjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_esjdjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_ESJDView> jyjds = ConvertHelper.DataTableToList<ES_JDJJBG_ESJDView>(dt);
                foreach (var jcxx in jyjds)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_esjjjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_ESJJView> jyjjs = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                foreach (var jcxx in jyjjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_jjryjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_JJRYView> jjrys = ConvertHelper.DataTableToList<ES_JDJJBG_JJRYView>(dt);
                foreach (var jcxx in jjrys)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_bgsbjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_BGSBView> bgyps = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                foreach (var jcxx in bgyps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_myetypwjjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_BGSBView> myets = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                foreach (var jcxx in myets)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_fzxmxbjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_BGSBView> fsxbs = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                foreach (var jcxx in fsxbs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_mrbjjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_BGSBView> mrbjs = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                foreach (var jcxx in mrbjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_qtes_essbjbxx b where a.jcxxid = b.jcxxid ");
                List<ES_JDJJBG_BGSBView> essbs = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                foreach (var jcxx in essbs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, sjs = sjs, sjpp = sjpp, bjbdns = bjbdns, bjbdnpp = bjbdnpp, pbdns = pbdns, pbdnpp = pbdnpp, tsjs = tsjs, tsjlb = tsjlb, smcps = smcps, smcplb = smcplb, jyjds, jyjdlb = jyjdlb, jyjjs = jyjjs, jyjjlb = jyjjlb, jjrys = jjrys, jjrylb = jjrylb, bgyps = bgyps, bgyplb = bgyplb, myets = myets, myetlb = myetlb, fsxbs = fsxbs, fsxblb = fsxblb, mrbjs = mrbjs, mrbjlb = mrbjlb, essbs = essbs, essblb = essblb };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadZPSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_QZZP> rzzws = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE ISHOT='是' ORDER BY CODEORDER"));
                IList<CODES_QZZP> xszw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='销售类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> sjzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='司机类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> cyzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='餐饮类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> jrzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='金融/银行/证券/投资类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> glzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='高级管理类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> qczw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='汽车类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> wlzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='物流/仓储类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> ggzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='广告/咨询类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> fczw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='房产类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> jzzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='建筑类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> zxzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='装修类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> wluozw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='计算机/互联网类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> txzw = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='通讯类别' ORDER BY CODEORDER"));

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb='销售'");
                List<QZZP_QZZPView> xss = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*, b.* from jcxx a, qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '司机'");
                List<QZZP_QZZPView> sjs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '餐饮'");
                List<QZZP_QZZPView> cys = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '金融'");
                List<QZZP_QZZPView> jrs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '管理'");
                List<QZZP_QZZPView> gls = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '汽车'");
                List<QZZP_QZZPView> qcs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '物流'");
                List<QZZP_QZZPView> wls = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '广告'");
                List<QZZP_QZZPView> ggs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '房产'");
                List<QZZP_QZZPView> fcs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '建筑'");
                List<QZZP_QZZPView> jzs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '装修'");
                List<QZZP_QZZPView> zxs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '网络'");
                List<QZZP_QZZPView> wluos = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,qzzp_qzzpjbxx b where a.jcxxid = b.jcxxid and zwlb = '通讯'");
                List<QZZP_QZZPView> txs = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);

                return new { Result = EnResultType.Success, rzzws = rzzws, xss = xss, sjs = sjs, cys = cys, jrs = jrs, gls = gls, qcs = qcs, wls = wls, ggs = ggs, fcs = fcs, jzs = jzs, zxs = zxs, txs = txs, wluos = wluos, xszw = xszw, sjzw = sjzw, cyzw = cyzw, jrzw, glzw, qczw, wlzw, ggzw, fczw, jzzw, zxzw, wluozw, txzw };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadHYLB(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_QZZP> hylb = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE TYPENAME='职位类别' ORDER BY CODEORDER"));
                IList<CODES_QZZP> zwlb = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE PARENTID IN(SELECT CODEID FROM CODES_QZZP WHERE TYPENAME='职位类别') ORDER BY CODEORDER"));
                IList<CODES_QZZP> zwmc = DAO.GetObjectList<CODES_QZZP>(string.Format("FROM CODES_QZZP WHERE PARENTID IN(SELECT CODEID FROM CODES_QZZP WHERE PARENTID IN(SELECT CODEID FROM CODES_QZZP WHERE TYPENAME='职位类别')) ORDER BY CODEORDER"));

                return new { Result = EnResultType.Success, hylb = hylb, zwlb = zwlb, zwmc = zwmc };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadSHFWTOP(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_XXLB> shfwlb = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE PARENTID = 9 OR FBYM LIKE 'SHFW%' OR FBYM LIKE 'XXYL%' OR FBYM LIKE 'HQSY%' OR FBYM LIKE 'LYJD%'"));
                IList<CODES_SHFW> shfwxl = DAO.GetObjectList<CODES_SHFW>(string.Format("FROM CODES_SHFW WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                IList<CODES_LYJD> lyjdxl = DAO.GetObjectList<CODES_LYJD>(string.Format("FROM CODES_LYJD WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                IList<CODES_HQSY> hqsyxl = DAO.GetObjectList<CODES_HQSY>(string.Format("FROM CODES_HQSY WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                IList<CODES_XXYL> xxylxl = DAO.GetObjectList<CODES_XXYL>(string.Format("FROM CODES_XXYL WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                return new { Result = EnResultType.Success, shfwlb = shfwlb, shfwxl = shfwxl, lyjdxl= lyjdxl, hqsyxl= hqsyxl, xxylxl= xxylxl };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadSHFWSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));

                //dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_essjjbxx b where a.jcxxid = b.jcxxid ");
                //List<ES_SJSM_ESSJView> sjs = ConvertHelper.DataTableToList<ES_SJSM_ESSJView>(dt);
                //foreach (var jcxx in sjs)
                //{
                //    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                //}
                return new { Result = EnResultType.Success, districts = districts };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
