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
        public object LoadSZMX(string YHID, string LX, string ZJLX, string PageIndex, string PageSize)
        {
            try
            {
                StringBuilder Condition = new StringBuilder();
                if (!string.IsNullOrEmpty(LX))
                    Condition.AppendFormat(" AND LX='{0}'", LX);
                if (!string.IsNullOrEmpty(ZJLX) && ZJLX == "存入")
                    Condition.AppendFormat(" AND LX in('退款','充值')");
                if (!string.IsNullOrEmpty(ZJLX) && ZJLX == "支出")
                    Condition.AppendFormat(" AND LX in('消费','提现')");
                IList<SZMX> list = new List<SZMX>();
                list = DAO.Repository.GetObjectList<SZMX>(String.Format("FROM SZMX WHERE 0=0 {0} ORDER BY CJSJ DESC", Condition));

                int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                int TotalCount = list.Count;

                var listnew = from p in list
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;
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
