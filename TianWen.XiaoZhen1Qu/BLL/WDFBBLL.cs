using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WDFBBLL : BaseBLL, IWDFBBLL
    {
        public object LoadYHFBXX(string YHID, string TYPE)
        {
            try
            {
                IList<JCXX> list = new List<JCXX>();
                if (TYPE == "ZJFBXX")//最近发布信息，暂定三个月以内
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' AND CJSJ >= TO_DATE(to_char(add_months(sysdate, -3), 'yyyy-mm-dd hh24:mi:ss'), 'yyyy-mm-dd hh24:mi:ss') ORDER BY CJSJ", YHID));
                }
                foreach (var jcxx in list)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
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
