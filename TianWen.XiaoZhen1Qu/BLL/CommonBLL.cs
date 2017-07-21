using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class CommonBLL : BaseBLL, ICommonBLL
    {

        public object GetIDByJCXXIDAndLBID(string JCXXID, string LBID)
        {
            try
            {
                List<XXLB> xxlbs = DAO.GetObjectList<XXLB>(string.Format("FROM XXLB WHERE LBID = {0}", LBID)).ToList();
                if (xxlbs.Count > 0)
                {
                    DataTable dt = DAO.GetDataTable(string.Format("SELECT * FROM {0} WHERE JCXXID = '{1}'", xxlbs[0].FBTABLE, JCXXID));
                    if (dt.Rows.Count > 0)
                    {
                        return new { Result = EnResultType.Success, Message = "获取成功", Value = new { Value = dt.Rows[0][xxlbs[0].FBTABLE + "ID"], Key = xxlbs[0].FBTABLE + "ID", FBYM = xxlbs[0].FBYM, LBID = xxlbs[0].LBID } };
                    }
                }
                return new { Result = EnResultType.Failed, Message = "不存在" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CommonBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
