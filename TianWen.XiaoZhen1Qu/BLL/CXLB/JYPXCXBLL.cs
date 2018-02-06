using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.JYPX;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class JYPXCXBLL : BaseBLL, IJYPXCXBLL
    {
        //加载列表信息
        public object LoadJYPXXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType, string XZQDM)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "JYPXXX_ZXXFDB")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_zxxfdbjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_ZXXYDY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_zxxydyjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_JJJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_jjjgjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_JJJGView> list = ConvertHelper.DataTableToList<JYPX_JJJGView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_JJGR")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_jjgrjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_JJGRView> list = ConvertHelper.DataTableToList<JYPX_JJGRView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_YYPXJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yypxjgjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_YYPXJGView> list = ConvertHelper.DataTableToList<JYPX_YYPXJGView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_YYPXJS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yypxjsjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_YSPXJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_YSPXJGJBXX b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_YSPXJGView> list = ConvertHelper.DataTableToList<JYPX_YSPXJGView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_YSPXJS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yspxjsjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_ZYJNPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_zyjnpxjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_ZYJNPXView> list = ConvertHelper.DataTableToList<JYPX_ZYJNPXView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_TYPXJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_TYPXJGJBXX b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_TYPXJGView> list = ConvertHelper.DataTableToList<JYPX_TYPXJGView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_TYJL")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_tyjljbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_TYJLView> list = ConvertHelper.DataTableToList<JYPX_TYJLView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_XLJY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_xljyjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_XLJYView> list = ConvertHelper.DataTableToList<JYPX_XLJYView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_ITPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_itpxjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_ITPXView> list = ConvertHelper.DataTableToList<JYPX_ITPXView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_SJPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_sjpxjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_SJPXView> list = ConvertHelper.DataTableToList<JYPX_SJPXView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_GLPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_glpxjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_GLPXView> list = ConvertHelper.DataTableToList<JYPX_GLPXView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_YYEJY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yyejyjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_YYEJYView> list = ConvertHelper.DataTableToList<JYPX_YYEJYView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_LX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_lxjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_LXView> list = ConvertHelper.DataTableToList<JYPX_LXView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_YM")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_ymjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_YMView> list = ConvertHelper.DataTableToList<JYPX_YMView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "JYPXXX_PBPK")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_pbpkjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<JYPX_PBPKView> list = ConvertHelper.DataTableToList<JYPX_PBPKView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
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

        //加载详细信息
        public object LoadJYPXXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "JYPXXX_ZXXFDB") 
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_zxxfdbjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_ZXXYDY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_zxxydyjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_JJJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_jjjgjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_JJJGView> list = ConvertHelper.DataTableToList<JYPX_JJJGView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_JJGR")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_jjgrjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_JJGRView> list = ConvertHelper.DataTableToList<JYPX_JJGRView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_YYPXJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yypxjgjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_YYPXJGView> list = ConvertHelper.DataTableToList<JYPX_YYPXJGView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_YYPXJS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yypxjsjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_YSPXJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yspxjgjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_YSPXJGView> list = ConvertHelper.DataTableToList<JYPX_YSPXJGView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_YSPXJS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yspxjsjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_ZYJNPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_zyjnpxjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ZYJNPXView> list = ConvertHelper.DataTableToList<JYPX_ZYJNPXView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_TYPXJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_TYPXJGJBXX b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_TYPXJGView> list = ConvertHelper.DataTableToList<JYPX_TYPXJGView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_TYJL")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_tyjljbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_TYJLView> list = ConvertHelper.DataTableToList<JYPX_TYJLView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_XLJY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_xljyjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_XLJYView> list = ConvertHelper.DataTableToList<JYPX_XLJYView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_ITPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_itpxjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ITPXView> list = ConvertHelper.DataTableToList<JYPX_ITPXView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_SJPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_sjpxjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_SJPXView> list = ConvertHelper.DataTableToList<JYPX_SJPXView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_GLPX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_glpxjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_GLPXView> list = ConvertHelper.DataTableToList<JYPX_GLPXView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_JJJG")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_jjjgjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_ZXXFDBView> list = ConvertHelper.DataTableToList<JYPX_ZXXFDBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_YYEJY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_yyejyjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_YYEJYView> list = ConvertHelper.DataTableToList<JYPX_YYEJYView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_LX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_lxjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_LXView> list = ConvertHelper.DataTableToList<JYPX_LXView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_YM")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_ymjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_YMView> list = ConvertHelper.DataTableToList<JYPX_YMView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "JYPXXX_PBPK")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,jypx_pbpkjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<JYPX_PBPKView> list = ConvertHelper.DataTableToList<JYPX_PBPKView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
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