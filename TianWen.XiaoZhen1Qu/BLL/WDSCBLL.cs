using System;
using System.Collections.Generic;
using System.Linq;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WDSCBLL : BaseBLL, IWDSCBLL
    {
        public object LoadYHSCXX(string YHID, string PageIndex, string PageSize)
        {
            try
            {
                IList<JCXX> JCXXs = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID IN(SELECT JCXXID FROM HTGL_YHSCXX WHERE YHID='{0}') ORDER BY JCXXID", YHID));
                IList<HTGL_YHSCXX> HTGL_YHSCXXs = DAO.Repository.GetObjectList<HTGL_YHSCXX>(String.Format("FROM HTGL_YHSCXX WHERE YHID='{0}' ORDER BY JCXXID", YHID));
                int PageCount = (JCXXs.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                int TotalCount = JCXXs.Count;
                var WDCountlist = from p in JCXXs.Where(p => p.STATUS == 0) select p;
                int WCCount = WDCountlist.Count();

                var listnew = from p in JCXXs
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;

                 PageCount = (JCXXs.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                 TotalCount = JCXXs.Count;
                 WDCountlist = from p in JCXXs.Where(p => p.STATUS == 0) select p;
                 WCCount = WDCountlist.Count();

                var listnewscxx = from p in HTGL_YHSCXXs
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;
                return new { Result = EnResultType.Success, JCXXs = listnew, SCXXs= listnewscxx, PageCount = PageCount };
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
