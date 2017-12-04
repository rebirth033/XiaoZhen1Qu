using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.HQSY;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class HQSYCXBLL : BaseBLL, IHQSYCXBLL
    {
        //加载婚庆摄影列表信息
        public object LoadHQSYXX(string TYPE, string Condition, string PageIndex, string PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "HQSYXX_HQGS")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hqgsjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_HCZL")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hczljbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_HYJD")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hyjdjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_CZZX")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_czzxjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_HQYP")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hqypjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_SY")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_syjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_HLGP")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hlgpjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_HSLF")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hslfjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_ZBSS")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_zbssjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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
                if (TYPE == "HQSYXX_HSSY")
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,hqsy_hssyjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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

        //加载婚庆摄影详细信息
        public object LoadHQSYXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "HQSYXX_HQGS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hqgsjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_HCZL")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hczljbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_HYJD")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hyjdjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_CZZX")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_czzxjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_HQYP")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hqypjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_SY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_syjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_HLGP")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hlgpjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_HSLF")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hslfjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_ZBSS")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_zbssjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "HQSYXX_HSSY")
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,hqsy_hssyjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<HQSY_HQGSView> list = ConvertHelper.DataTableToList<HQSY_HQGSView>(dt);
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