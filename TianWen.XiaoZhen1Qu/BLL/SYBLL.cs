﻿using System;
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
using TianWen.XiaoZhen1Qu.Entities.ViewModels.SHFW;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.SWFW;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.ZSJM;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.PFCG;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.JYPX;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;
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
                IList<CODES_XXLB> shfwlb = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE PARENTID = 9 OR FBYM LIKE 'SHFW%' OR FBYM LIKE 'XXYL%' OR FBYM LIKE 'HQSY%' OR FBYM LIKE 'LYJD%' ORDER BY PARENTID"));
                IList<CODES_SHFW> shfwxl = DAO.GetObjectList<CODES_SHFW>(string.Format("FROM CODES_SHFW WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                IList<CODES_LYJD> lyjdxl = DAO.GetObjectList<CODES_LYJD>(string.Format("FROM CODES_LYJD WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                IList<CODES_HQSY> hqsyxl = DAO.GetObjectList<CODES_HQSY>(string.Format("FROM CODES_HQSY WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                IList<CODES_XXYL> xxylxl = DAO.GetObjectList<CODES_XXYL>(string.Format("FROM CODES_XXYL WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));
                return new { Result = EnResultType.Success, shfwlb = shfwlb, shfwxl = shfwxl, lyjdxl = lyjdxl, hqsyxl = hqsyxl, xxylxl = xxylxl };
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

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bjjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> bjfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in bjfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bmysjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> bmysfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in bmysfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bjqxjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> bjqxfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in bjqxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_gdstqljbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> gdstqlfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in gdstqlfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_shpsjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> shpsfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in shpsfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_jdwxjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> jdwxfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in jdwxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_dnwxjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> dnwxfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in dnwxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_jjwxjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> jjwxfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in jjwxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_fwwxjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> fwwxfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in fwwxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_smwxjbxx b where a.jcxxid = b.jcxxid ");
                List<SHFW_BJView> smwxfws = ConvertHelper.DataTableToList<SHFW_BJView>(dt);
                foreach (var jcxx in smwxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, bjfws = bjfws, bmysfws = bmysfws, bjqxfws = bjqxfws, gdstqlfws = gdstqlfws, shpsfws = shpsfws, jdwxfws = jdwxfws, jjwxfws = jjwxfws, dnwxfws = dnwxfws, smwxfws = smwxfws, fwwxfws = fwwxfws };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadSWFWTOP(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_XXLB> shfwlb = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE PARENTID =10 OR FBYM LIKE 'SWFW%'"));
                IList<CODES_SWFW> shfwxl = DAO.GetObjectList<CODES_SWFW>(string.Format("FROM CODES_SWFW WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));

                return new { Result = EnResultType.Success, shfwlb = shfwlb, shfwxl = shfwxl };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadSWFWSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_gszcjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> gszcfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in gszcfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_sbzljbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> sbzlfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in sbzlfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_ysbzjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> ysbzfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in ysbzfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_phzpjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> phzpfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in phzpfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_sjchjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> sjchfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in sjchfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_ggcmjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> ggcmfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in ggcmfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_zhfwjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> zhfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in zhfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_lpdzjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> lpdzfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in lpdzfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_lyqdjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> qdfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in qdfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,swfw_wlbxwhjbxx b where a.jcxxid = b.jcxxid ");
                List<SWFW_GSZCView> wlbxfws = ConvertHelper.DataTableToList<SWFW_GSZCView>(dt);
                foreach (var jcxx in wlbxfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, gszcfws = gszcfws, sbzlfws = sbzlfws, ysbzfws = ysbzfws, phzpfws = phzpfws, sjchfws = sjchfws, ggcmfws = ggcmfws, zhfws = zhfws, lpdzfws = lpdzfws, qdfws = qdfws, wlbxfws = wlbxfws };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadJYPXTOP(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_XXLB> lb = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE PARENTID = 11 OR FBYM LIKE 'JYPX%'"));
                IList<CODES_JYPX> xl = DAO.GetObjectList<CODES_JYPX>(string.Format("FROM CODES_JYPX WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));

                return new { Result = EnResultType.Success, lb = lb, xl = xl };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadJYPXSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_jjjgjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_JJJGView> jjjgs = ConvertHelper.DataTableToList<JYPX_JJJGView>(dt);
                foreach (var jcxx in jjjgs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_yypxjgjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_YYPXJGView> yypxs = ConvertHelper.DataTableToList<JYPX_YYPXJGView>(dt);
                foreach (var jcxx in yypxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_yspxjgjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_YSPXJGView> yspxs = ConvertHelper.DataTableToList<JYPX_YSPXJGView>(dt);
                foreach (var jcxx in yspxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_zyjnpxjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_ZYJNPXView> zyjnpxs = ConvertHelper.DataTableToList<JYPX_ZYJNPXView>(dt);
                foreach (var jcxx in zyjnpxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_typxjgjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_TYPXJGView> typxs = ConvertHelper.DataTableToList<JYPX_TYPXJGView>(dt);
                foreach (var jcxx in typxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_xljyjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_JJJGView> xljys = ConvertHelper.DataTableToList<JYPX_JJJGView>(dt);
                foreach (var jcxx in xljys)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_itpxjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_ITPXView> itpxs = ConvertHelper.DataTableToList<JYPX_ITPXView>(dt);
                foreach (var jcxx in itpxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_sjpxjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_SJPXView> sjpxs = ConvertHelper.DataTableToList<JYPX_SJPXView>(dt);
                foreach (var jcxx in sjpxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,jypx_glpxjbxx b where a.jcxxid = b.jcxxid ");
                List<JYPX_GLPXView> glpxs = ConvertHelper.DataTableToList<JYPX_GLPXView>(dt);
                foreach (var jcxx in glpxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, jjjgs = jjjgs, yypxs = yypxs, yspxs = yspxs, zyjnpxs = zyjnpxs, typxs = typxs, xljys = xljys, itpxs = itpxs, sjpxs = sjpxs, glpxs = glpxs };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadZSJMTOP(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_XXLB> lb = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE PARENTID =6 OR FBYM LIKE 'ZSJM%'"));
                IList<CODES_ZSJM> xl = DAO.GetObjectList<CODES_ZSJM>(string.Format("FROM CODES_ZSJM WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));

                return new { Result = EnResultType.Success, lb = lb, xl = xl };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadZSJMSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_fzxbjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> fzs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in fzs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_jcjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> jcs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in jcs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_jxjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> jxjgs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in jxjgs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_mrbjjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> mrbjs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in mrbjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_lpspjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> lpsps = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in lpsps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_jjhbjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> jjs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in jjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_jypxjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> jypxs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in jypxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_qcfwjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> qcfws = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in qcfws)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_wlfwjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> wltxs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in wltxs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,zsjm_nyjbxx b where a.jcxxid = b.jcxxid ");
                List<ZSJM_CYView> nyyzs = ConvertHelper.DataTableToList<ZSJM_CYView>(dt);
                foreach (var jcxx in nyyzs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, fzs = fzs, jcs = jcs, jxjgs = jxjgs, mrbjs = mrbjs, lpsps = lpsps, jjs = jjs, jypxs = jypxs, qcfws = qcfws, wltxs = wltxs, nyyzs = nyyzs };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadPFCGTOP(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_XXLB> lb = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE PARENTID = 7 OR FBYM LIKE 'PFCG%'"));
                IList<CODES_PFCG> xl = DAO.GetObjectList<CODES_PFCG>(string.Format("FROM CODES_PFCG WHERE TYPENAME LIKE '%类别%' ORDER BY CODEORDER"));

                return new { Result = EnResultType.Success, lb = lb, xl = xl };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadPFCGSY(string xzqdm, string xzq)
        {
            DataTable dt = new DataTable();
            try
            {
                IList<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", xzqdm));

                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_scsbjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> scsbs = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in scsbs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_hxpjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> hxps = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in hxps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_ybyqjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> dzqjs = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in dzqjs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_djzmjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> djzms = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in djzms)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_spjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> sps = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in sps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_lpjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> lps = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in lps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_fsxmjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> fzxbs = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in fzxbs)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_xbspjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> zbsps = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in zbsps)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,pfcg_sjsmjbxx b where a.jcxxid = b.jcxxid ");
                List<PFCG_SPView> sjsms = ConvertHelper.DataTableToList<PFCG_SPView>(dt);
                foreach (var jcxx in sjsms)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, districts = districts, scsbs = scsbs, hxps = hxps, dzqjs = dzqjs, djzms = djzms, sps = sps, lps = lps, fzxbs = fzxbs, zbsps = zbsps, sjsms = sjsms };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //根据汉字获取关键字
        public object LoadKeyWordByHZ(string SS, string XZQ)
        {
            try
            {
                DataTable list = DAO.Repository.GetDataTable(String.Format(@"select codeid,codename,typename,lbid parentid,fbym url,conditions from 
(select codeid,codename,typename,n.lbid,fbym,conditions from codes_fc n,codes_xxlb m where n.lbid = m.lbid
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_cl n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_cl_jc n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_cw n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_es_sjsm n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_es_jdjjbg n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_es_myfzmr n,codes_xxlb m where n.lbid = m.lbid  
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_es_pwkq n,codes_xxlb m where n.lbid = m.lbid  
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_es_qtes n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_es_whyl n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_hqsy n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_jypx n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_lyjd n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_nlmfy n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_pfcg n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_qzzp n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_shfw n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_swfw n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_xxyl n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_zsjm n,codes_xxlb m where n.lbid = m.lbid 
union all select codeid,codename,typename,n.lbid,fbym,conditions from codes_zxjc n,codes_xxlb m where n.lbid = m.lbid
union all select lbid codeid,lbname codename,lbname typename,lbid,fbym,'' conditions from codes_xxlb where fbym is not null and parentid not in(89,90)) a 
where lbid is not null and codename like '%{0}%' limit 10", SS, XZQ));
                IList<SSJGView> result = list.DataTableToList<SSJGView>();
                return new { Result = EnResultType.Success, list = result };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //根据拼音获取关键字
        public object LoadKeyWordByPY(string SS, string XZQ)
        {
            try
            {
                DataTable list = DAO.Repository.GetDataTable(String.Format(@"select codeid,codename,typename,lbid parentid,fbym url,conditions,codenamepyqkg, codenamepy,codenamepyszm from 
(select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_fc n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_cl n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_cl_jc n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_cw n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_es_sjsm n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_es_jdjjbg n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_es_myfzmr n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_es_pwkq n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_es_qtes n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_es_whyl n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_hqsy n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_jypx n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_lyjd n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_nlmfy n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_pfcg n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_qzzp n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_shfw n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_swfw n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_xxyl n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_zsjm n, codes_xxlb m where n.lbid = m.lbid
union all select codeid, codename, typename, n.lbid, fbym, conditions, codenamepyqkg, codenamepy, codenamepyszm from codes_zxjc n, codes_xxlb m where n.lbid = m.lbid
union all select lbid codeid, lbname codename, lbname typename, lbid, fbym, '' conditions, '' codenamepyqkg, '' codenamepy,  '' codenamepyszm from codes_xxlb where fbym is not null and parentid not in(89, 90)) a
where lbid is not null and (codenamepyqkg like '%{0}%' or codenamepyszm like '%{0}%') limit 10", SS, XZQ));
                IList<SSJGView> result = list.DataTableToList<SSJGView>();
                return new { Result = EnResultType.Success, list = result };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadXXLBByLBID(string lbid)
        {
            try
            {
                IList<CODES_XXLB> xxlbs = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE LBID='{0}' AND FBYM is not null ORDER BY LBORDER", lbid));
                return new { Result = EnResultType.Success, list = xxlbs };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadJCXXByJCXXID(string jcxxid)
        {
            try
            {
                IList<JCXX> jcxxs = DAO.GetObjectList<JCXX>(string.Format("FROM JCXX WHERE JCXXID='{0}'", jcxxid));
                return new { Result = EnResultType.Success, list = jcxxs };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
