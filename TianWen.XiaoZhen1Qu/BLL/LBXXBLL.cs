using System;
using System.Collections.Generic;
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
                return new { Result = EnResultType.Failed, Message = "登录失败" };
            }
        }
    }

   
}
