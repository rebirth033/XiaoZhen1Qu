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
    }
}
