using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.Models.CODES;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class SYBLL : BaseBLL, ISYBLL
    {
        public object LoadZXFBXX()
        {
            try
            {
                IList<JCXX> list = new List<JCXX>();
                list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX ORDER BY CJSJ DESC"));

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

        public object LoadSY_ML(string typename, string xzq)
        {
            try
            {
                IList<CODES_SY_ML> list = new List<CODES_SY_ML>();
                list = DAO.Repository.GetObjectList<CODES_SY_ML>(String.Format("FROM CODES_SY_ML WHERE TYPENAME = '{0}' ORDER BY ID", typename));
                return new { Result = EnResultType.Success, list = list, xzq = xzq };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
