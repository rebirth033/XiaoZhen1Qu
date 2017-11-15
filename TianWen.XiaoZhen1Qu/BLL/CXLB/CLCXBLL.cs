﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.CL;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.GY;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class CLCXBLL : BaseBLL, ICLCXBLL
    {
        //加载车辆信息
        public object LoadCLXX(string TYPE, string Condition, string PageIndex, string PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "CLXX_JC")//车辆_轿车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_jcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_JCView> list = ConvertHelper.DataTableToList<CL_JCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_HC")//车辆_货车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_hcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_HCView> list = ConvertHelper.DataTableToList<CL_HCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_KC")//车辆_客车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_kcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_KCView> list = ConvertHelper.DataTableToList<CL_KCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_MTC")//车辆_摩托车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_mtcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_MTCView> list = ConvertHelper.DataTableToList<CL_MTCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_ZXC")//车辆_自行车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_zxcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_ZXCView> list = ConvertHelper.DataTableToList<CL_ZXCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_DDC")//车辆_电动车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_ddcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_DDCView> list = ConvertHelper.DataTableToList<CL_DDCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_SLC")//车辆_三轮车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_slcjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_SLCView> list = ConvertHelper.DataTableToList<CL_SLCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CLXX_GCC")//车辆_工程车
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cl_gccjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CL_GCCView> list = ConvertHelper.DataTableToList<CL_GCCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }

                return new { Result = EnResultType.Failed };

            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //加载信息
        public object LoadCLXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "CLXX_JC") //车辆_轿车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_jcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_JCView> list = ConvertHelper.DataTableToList<CL_JCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_HC") //车辆_货车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_hcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_HCView> list = ConvertHelper.DataTableToList<CL_HCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_KC") //车辆_客车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_kcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_KCView> list = ConvertHelper.DataTableToList<CL_KCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_MTC") //车辆_摩托车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_mtcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_MTCView> list = ConvertHelper.DataTableToList<CL_MTCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_ZXC") //车辆_自行车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_zxcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_ZXCView> list = ConvertHelper.DataTableToList<CL_ZXCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_DDC") //车辆_电动车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_ddcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_DDCView> list = ConvertHelper.DataTableToList<CL_DDCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_SLC") //车辆_三轮车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_slcjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_SLCView> list = ConvertHelper.DataTableToList<CL_SLCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "CLXX_GCC") //车辆_工程车
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cl_gccjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CL_GCCView> list = ConvertHelper.DataTableToList<CL_GCCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                return new { Result = EnResultType.Failed };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}