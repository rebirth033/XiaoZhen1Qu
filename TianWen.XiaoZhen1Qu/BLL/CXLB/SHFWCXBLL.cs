using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.FC;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class SHFWCXBLL : BaseBLL, ISHFWCXBLL
    {
        //加载生活服务列表信息
        public object LoadSHFWXX(string TYPE, string Condition, string PageIndex, string PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "SHFWXX_BJ")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_BMYS")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bmysjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_BJQX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bjqxjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_KSHSXS")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_kshsxsjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_GDSTQL")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_gdstqljbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_SHPS")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_shpsjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_BZMD")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_bzmdjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_JDWX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_jdwxjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_DNWX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_dnwxjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_FWWXDK")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_fwwxdkjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_JJWX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,shfw_jjwxjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_SJWX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,SHFW_SJWXJBXX b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "SHFWXX_SMWX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,SHFW_SMWXJBXX b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
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

        //加载生活服务详细信息
        public object LoadSHFWXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "SHFWXX_BJ")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_bjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_BMYS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_bmysjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_BJQX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_bjqxjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_KSHSXS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_kshsxsjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_GDSTQL")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_gdstqljbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_SHPS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_shpsjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_BZMD")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_bzmdjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_JDWX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_jdwxjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_DNWX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_dnwxjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_FWWXDK")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_fwwxdkjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_JJWX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,shfw_jjwxjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_SJWX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,SHFW_SJWXJBXX b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "SHFWXX_SMWX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,SHFW_SMWXJBXX b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<QZZP_QZZPView> list = ConvertHelper.DataTableToList<QZZP_QZZPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
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