using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WDSCBLL : BaseBLL, IWDSCBLL
    {
        public object LoadSCXX(string YHID)
        {
            try
            {
                IList<YHSCXX> YHSCXXs = DAO.Repository.GetObjectList<YHSCXX>(String.Format("FROM YHSCXX WHERE YHID='{0}'", YHID));
                if (YHSCXXs.Count > 0)
                {
                    IList<JCXX> JCXXs = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID='{0}'", YHSCXXs[0].JCXXID));
                    if (JCXXs.Count > 0)
                    {
                        foreach (var jcxx in JCXXs)
                        {
                            jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        }
                    }
                    return new { Result = EnResultType.Success, list = JCXXs };
                }
                return new { Result = EnResultType.Success };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object DeleteYHSCXX(string YHID, string JCXXID)
        {
            try
            {
                IList<YHSCXX> YHSCXXs = DAO.Repository.GetObjectList<YHSCXX>(String.Format("FROM YHSCXX WHERE YHID='{0}' AND JCXXID='{1}'", YHID, JCXXID));
                foreach (var YHSCXX in YHSCXXs)
                {
                    DAO.Remove(YHSCXX);
                }
                return new { Result = EnResultType.Success };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "删除失败" };
            }
        }
    }
}
