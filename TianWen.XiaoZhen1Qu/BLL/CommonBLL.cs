﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class CommonBLL : BaseBLL, ICommonBLL
    {
        //根据基础信息ID和类别ID获取
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
                        return new { Result = EnResultType.Success, Message = "获取成功", Value = new { Value = dt.Rows[0]["ID"], Key = "ID", FBYM = xxlbs[0].FBYM, LBID = xxlbs[0].LBID } };
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

        //根据行政区级别获取行政区
        public object GetDistrictByGrade(string Grade)
        {
            try
            {
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME = '{0}' ORDER BY CODEORDER", Grade)).ToList();
                return new { Result = EnResultType.Success, list = districts };
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

        //根据行政区简称获取行政区
        public object GetDistrictByShortName(string ShortName)
        {
            try
            {
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE ShortName = '{0}' ORDER BY CODE", ShortName)).ToList();
                return new { Result = EnResultType.Success, list = districts };
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

        //根据父级行政区编码获取行政区
        public object GetDistrictBySuperCode(string SuperCode)
        {
            try
            {
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE PARENTID = '{0}' ORDER BY CODEORDER", SuperCode)).ToList();
                return new { Result = EnResultType.Success, list = districts };
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
        
        //根据行政区编码获取省内同级行政区
        public object GetDistrictTJByXZQDM(string XZQDM)
        {
            try
            {
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE PARENTID = '{0}' ORDER BY CODEORDER", XZQDM.Substring(0, 2) + "0000")).ToList();
                return new { Result = EnResultType.Success, list = districts };
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
