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
                if (TYPE == "divZJFBXX")//最近发布信息，暂定三个月以内
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' AND CJSJ >= TO_DATE(to_char(add_months(sysdate, -3), 'yyyy-mm-dd hh24:mi:ss'), 'yyyy-mm-dd hh24:mi:ss') ORDER BY CJSJ", YHID));
                }
                if (TYPE == "divXSZXX")//显示中信息
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' AND STATUS = 1 ORDER BY CJSJ", YHID));
                }
                if (TYPE == "divDSHXX")//待审核信息
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' AND STATUS = 3 ORDER BY CJSJ", YHID));
                }
                if (TYPE == "divYSCXX")//已删除信息
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' AND STATUS = 0 ORDER BY CJSJ", YHID));
                }
                if (TYPE == "divWXSXX")//未显示信息
                {
                    list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE YHID='{0}' AND STATUS = 2 ORDER BY CJSJ", YHID));
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


        public object UpdateYHFBXX(string JCXXID, string OPTYPE)
        {
            try
            {
                JCXX jcxx = DAO.GetObjectByID<JCXX>(JCXXID);
                if (OPTYPE == "DELETE")
                    jcxx.STATUS = 0;
                if (OPTYPE == "RESTORE")
                    jcxx.STATUS = 1;
                DAO.Update(jcxx);
                return new { Result = EnResultType.Success };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "修改失败" };
            }
        }
    }
}
