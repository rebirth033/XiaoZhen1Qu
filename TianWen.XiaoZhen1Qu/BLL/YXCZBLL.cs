using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YXCZBLL : BaseBLL, IYXCZBLL
    {
        public object LoadYXJBXX(string YHID, string SZM)
        {
            try
            {
                IList<YXJBXX> list = new List<YXJBXX>();
                if (SZM == "RMYX")
                    list = DAO.Repository.GetObjectList<YXJBXX>(String.Format("FROM YXJBXX WHERE SFRMYX='1'"));
                else
                    list = DAO.Repository.GetObjectList<YXJBXX>(String.Format("FROM YXJBXX WHERE YXMCSZM='{0}'", SZM));
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
