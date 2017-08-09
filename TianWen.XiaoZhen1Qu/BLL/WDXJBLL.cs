using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Enum;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WDXJBLL : BaseBLL, IWDXJBLL
    {
        public object LoadSZMX(string YHID, string TYPE, string PageIndex, string PageSize)
        {
            try
            {
                IList<SZMX> list = new List<SZMX>();
                list = DAO.Repository.GetObjectList<SZMX>(String.Format("FROM SZMX ORDER BY CJSJ DESC"));

                int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                int TotalCount = list.Count;

                var listnew = from p in list
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;
                return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount};
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
