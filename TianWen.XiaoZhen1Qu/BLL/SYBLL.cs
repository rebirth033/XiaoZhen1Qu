using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.Models.CODES;
using TianWen.XiaoZhen1Qu.Interface;
using System.Data;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.FC;
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

        public object LoadFCSY(string xzqdm,string xzq)
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
    }
}
