﻿using System;
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

        //根据用户ID获取用户账户ID
        public string GetYHZHXXIDByYHID(string YHID)
        {
            try
            {
                IList<YHZHXX> list = DAO.Repository.GetObjectList<YHZHXX>(String.Format("FROM YHZHXX WHERE YHID='{0}'", YHID));
                if (list.Count > 0)
                    return list.FirstOrDefault().YHZHXXID;
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return string.Empty;
            }
        }

        //根据ID获取基础信息
        public JCXX GetJCXXByID(string JCXXID)
        {
            IList<JCXX> list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID='{0}'", JCXXID));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        //根据基础信息获取图片集
        public List<PHOTOS> GetPhtosByJCXXID(string JCXXID)
        {
            return DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}'", JCXXID)).ToList();
        }
    }

}
