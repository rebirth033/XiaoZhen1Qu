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
    public class XXGLBLL : BaseBLL, IXXGLBLL
    {
        public object LoadYHXX(string YHID, string TYPE)
        {
            try
            {
                IList<YHXX> list = new List<YHXX>();
                if (TYPE == "divXTTZLB")//消息类别为系统通知
                {
                    list = DAO.Repository.GetObjectList<YHXX>(String.Format("FROM YHXX WHERE YHID='{0}' AND XXLB=0 ORDER BY XXSJ DESC", YHID));
                }
                foreach (var obj in list)
                {
                    obj.XXLBMC = Enum.GetName(typeof(XXLBMJ), obj.XXLB);
                }
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
