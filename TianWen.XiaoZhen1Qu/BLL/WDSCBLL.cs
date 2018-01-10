using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WDSCBLL : BaseBLL, IWDSCBLL
    {
        public object LoadYHSCXX(string YHID)
        {
            try
            {
                IList<JCXX> JCXXs = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID IN(SELECT JCXXID FROM HTGL_YHSCXX WHERE YHID='{0}') ORDER BY JCXXID", YHID));
                IList<HTGL_YHSCXX> HTGL_YHSCXXs = DAO.Repository.GetObjectList<HTGL_YHSCXX>(String.Format("FROM HTGL_YHSCXX WHERE YHID='{0}' ORDER BY JCXXID", YHID));
                //if (HTGL_YHSCXXs.Count > 0)
                //{
                //    JCXXs = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID='{0}'", HTGL_YHSCXXs[0].JCXXID));
                //    if (JCXXs.Count > 0)
                //    {
                //        foreach (var jcxx in JCXXs)
                //        {
                //            jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                //        }
                //    }
                //    return new { Result = EnResultType.Success, list = JCXXs };
                //}
                return new { Result = EnResultType.Success, JCXXs = JCXXs, SCXXs= HTGL_YHSCXXs };
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
                IList<HTGL_YHSCXX> HTGL_YHSCXXs = DAO.Repository.GetObjectList<HTGL_YHSCXX>(String.Format("FROM HTGL_YHSCXX WHERE YHID='{0}' AND JCXXID='{1}'", YHID, JCXXID));
                foreach (var HTGL_YHSCXX in HTGL_YHSCXXs)
                {
                    DAO.Remove(HTGL_YHSCXX);
                }
                return new { Result = EnResultType.Success };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "删除失败" };
            }
        }

        public object AddYHSCXX(string YHM, string JCXXID, string TYPE,string LBID,string TYPEID)
        {
            try
            {
                IList<HTGL_YHSCXX> HTGL_YHSCXXs = DAO.Repository.GetObjectList<HTGL_YHSCXX>(String.Format("FROM HTGL_YHSCXX WHERE YHID='{0}' AND JCXXID='{1}'", YHM, JCXXID));
                if (HTGL_YHSCXXs.Count == 0)
                {
                    HTGL_YHSCXX newobj = new HTGL_YHSCXX();
                    newobj.JCXXID = JCXXID;
                    newobj.YHID = YHM;
                    newobj.TYPE = TYPE;
                    newobj.LBID = LBID;
                    newobj.TYPEID = TYPEID;
                    newobj.YHSCXXID = Guid.NewGuid().ToString();
                    DAO.Save(newobj);
                }
                return new { Result = EnResultType.Success };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "收藏失败" };
            }
        }
        
    }
}
