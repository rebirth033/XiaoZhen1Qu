using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WDFBBLL : BaseBLL,IWDFBBLL
    {
        public object LoadZXXX(string YHID)
        {
            try
            {
                IList<JCXX> list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' ORDER BY ZXGXSJ", YHID));
                return new {Result = EnResultType.Success, list = list};
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new {Result = EnResultType.Failed, Message = "加载失败"};
            }
        }
    }
}
