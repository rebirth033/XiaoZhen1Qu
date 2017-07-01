using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.Nhibernate;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class BaseBLL : IBaseBLL
    {
        public IDAO DAO { set; get; }

        public object LoadCODES(string TYPENAME)
        {
            try
            {
                IList<CODES> list = DAO.Repository.GetObjectList<CODES>(String.Format("FROM CODES WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
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
