﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.CL;
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
                List<CODES_XXLB> CODES_XXLBs = DAO.GetObjectList<CODES_XXLB>(string.Format("FROM CODES_XXLB WHERE LBID = {0}", LBID)).ToList();
                if (CODES_XXLBs.Count > 0)
                {
                    DataTable dt = DAO.GetDataTable(string.Format("SELECT * FROM {0} WHERE JCXXID = '{1}'", CODES_XXLBs[0].FBTABLE, JCXXID));
                    if (dt.Rows.Count > 0)
                    {
                        return new { Result = EnResultType.Success, Message = "获取成功", Value = new { Value = dt.Rows[0]["ID"], Key = "ID", FBYM = CODES_XXLBs[0].FBYM, LBID = CODES_XXLBs[0].LBID } };
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
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME in('{0}') OR SHORTNAME IN('京','津','沪','渝') ORDER BY TYPENAME, CODEORDER", Grade)).ToList();
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
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE CODEVALUE = '{0}' ORDER BY CODEORDER", ShortName)).ToList();
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
                int PARENTID = 0;
                List<CODES_DISTRICT> result = new List<CODES_DISTRICT>();
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='市级' ORDER BY CODEORDER")).ToList();
                foreach (var district in districts)
                {
                    if (district.CODEID == int.Parse(XZQDM))
                    {
                        PARENTID = district.PARENTID;
                    }
                }
                foreach (var district in districts)
                {
                    if (district.PARENTID == PARENTID)
                    {
                        result.Add(district);
                    }
                }
                return new { Result = EnResultType.Success, list = result };
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

        //根据行政区编码获取县区级行政区
        public object GetDistrictXQJByXZQDM(string XZQDM)
        {
            try
            {
                int PARENTID = 0;
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT WHERE TYPENAME='县区级' AND PARENTID='{0}' ORDER BY CODEORDER", XZQDM)).ToList();
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

        public object GetAllDistrictByXZQDM(string XZQDM)
        {
            try
            {
                List<CODES_DISTRICT> qylist = new List<CODES_DISTRICT>();
                List<CODES_DISTRICT> ddlist = new List<CODES_DISTRICT>();
                List<CODES_DISTRICT> districts = DAO.GetObjectList<CODES_DISTRICT>(string.Format("FROM CODES_DISTRICT")).ToList();
                foreach (var qy in districts)
                {
                    if (qy.PARENTID.ToString() == XZQDM)
                        qylist.Add(qy);
                }
                foreach (var qy in qylist)
                {
                    foreach (var dd in districts)
                    {
                        if (dd.PARENTID == qy.CODEID)
                            ddlist.Add(dd);
                    }
                }
                return new { Result = EnResultType.Success, qylist = qylist, ddlist = ddlist };
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

        public object LoadCommonXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType, string XZQDM)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = DAO.Repository.GetDataTable(string.Format("select * from jcxx where bt like '%{0}%' and status = 1 and xzqdm = {1}", Condition, XZQDM));
                List<CL_JCView> list = ConvertHelper.DataTableToList<CL_JCView>(dt);
                int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                int TotalCount = list.Count;
                var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                foreach (var jcxx in listnew)
                {
                    jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                }
                return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
