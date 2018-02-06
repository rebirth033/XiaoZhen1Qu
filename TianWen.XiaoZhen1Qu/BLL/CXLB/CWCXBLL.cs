using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.CW;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class CWCXBLL : BaseBLL, ICWCXBLL
    {
        //加载宠物信息
        public object LoadCWXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType, string XZQDM)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "CWXX_CWG")//宠物_宠物狗
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwgjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<CW_CWGView> list = ConvertHelper.DataTableToList<CW_CWGView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CWXX_CWM")//宠物_宠物猫
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwmjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<CW_CWMView> list = ConvertHelper.DataTableToList<CW_CWMView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CWXX_HNYC")//宠物_花鸟鱼虫
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_hnycjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<CW_HNYCView> list = ConvertHelper.DataTableToList<CW_HNYCView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CWXX_CWFW")//宠物_宠物服务
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwfwjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<CW_CWFWView> list = ConvertHelper.DataTableToList<CW_CWFWView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CWXX_CWYPSP")//宠物_宠物用品食品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwypspjbxx b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<CW_CWYPSPView> list = ConvertHelper.DataTableToList<CW_CWYPSPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "CWXX_CWGY")//宠物_宠物赠送领养
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,CW_CWGYJBXX b where a.jcxxid = b.jcxxid and xzqdm = {0} " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType), XZQDM));
                    List<CW_CWGYView> list = ConvertHelper.DataTableToList<CW_CWGYView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
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
        public object LoadCWXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "CWXX_CWG") //宠物_宠物狗
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwgjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CW_CWGView> list = ConvertHelper.DataTableToList<CW_CWGView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "CWXX_CWM") //宠物_宠物猫
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwmjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CW_CWMView> list = ConvertHelper.DataTableToList<CW_CWMView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "CWXX_HNYC") //宠物_花鸟鱼虫
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_hnycjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CW_HNYCView> list = ConvertHelper.DataTableToList<CW_HNYCView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "CWXX_CWFW") //宠物_宠物服务
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwfwjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CW_CWFWView> list = ConvertHelper.DataTableToList<CW_CWFWView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "CWXX_CWYPSP") //宠物_宠物用品食品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,cw_cwypspjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CW_CWYPSPView> list = ConvertHelper.DataTableToList<CW_CWYPSPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "CWXX_CWGY") //宠物_宠物赠送领养
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,CW_CWGYJBXX b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<CW_CWGYView> list = ConvertHelper.DataTableToList<CW_CWGYView>(dt);
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