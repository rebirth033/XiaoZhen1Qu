using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class LBXXBLL : BaseBLL, ILBXXBLL
    {
        public object LoadDL()
        {
            try
            {
                IList<CODES> list = DAO.Repository.GetObjectList<CODES>(String.Format("FROM CODES WHERE TYPENAME='大类' ORDER BY CODEORDER"));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadXL(string CODEID)
        {
            try
            {
                IList<CODES> list = DAO.Repository.GetObjectList<CODES>(String.Format("FROM CODES WHERE TYPENAME='小类' AND PARENTID='{0}' ORDER BY CODEORDER", CODEID));
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
