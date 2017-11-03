using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface.CXLB;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class FCCXBLL : BaseBLL, IFCCXBLL
    {
        public object LoadFCXX(string TYPE, string PageIndex, string PageSize)
        {
            try
            {
                IList<JCXX> list = new List<JCXX>();
                if (TYPE == "FC")//房产
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE LBID =19 ORDER BY ZXGXSJ DESC"));
                }

                int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                int TotalCount = list.Count;
                var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                int WCCount = WDCountlist.Count();

                var listnew = from p in list
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;

                foreach (var jcxx in listnew)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
