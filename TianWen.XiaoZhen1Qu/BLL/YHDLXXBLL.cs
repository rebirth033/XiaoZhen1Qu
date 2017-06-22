using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YHDLXXBLL : BaseBLL, IYHDLXXBLL
    {
        public object CheckLogin(string YHM, string MM)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", YHM));
            if (int.Parse(o1.ToString()) == 0)
            {
                return new { Result = EnResultType.Failed, Message = "用户名不存在，请重新输入"};
            }
            o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}' and MM='{1}'", YHM, EncryptionHelper.MD5Encrypt64(MM)));
            if (int.Parse(o1.ToString()) == 0)
            {
                return new {Result = EnResultType.Failed, Message = "密码错误，请重新输入"};
            }
            else
            {
                return new { Result = EnResultType.Success, Message = "登录成功" };
            }
        }
    }
}
