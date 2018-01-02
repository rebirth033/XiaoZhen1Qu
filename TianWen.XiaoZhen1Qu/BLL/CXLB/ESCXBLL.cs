using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.ES;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.GY;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class ESCXBLL : BaseBLL, IESCXBLL
    {
        //加载二手列表信息
        public object LoadESXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "ESXX_SJSM_ESSJ")//二手_手机数码_二手手机
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_essjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_SJSM_ESSJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_BJBDN")//二手_手机数码_笔记本电脑
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_bjbdnjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_SJSM_BJBDNView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;
                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_PBDN")//二手_手机数码_平板电脑
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_pbdnjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_SJSM_PBDNView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_SMCP")//二手_手机数码_数码产品
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_smcpjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_SJSM_SMCPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_TSJ")//二手_手机数码_台式机/配件
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_tsjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_SJSM_TSJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_ESJD")//二手_家电家具办公_二手家电
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_esjdjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJDView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_ESJJ")//二手_家电家具办公_二手家具
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_esjjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_JJRY")//二手_家电家具办公_家居日用
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_jjryjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_BGSB")//二手_家电家具办公_办公设备
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_bgsbjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_MYFZMR_MYETYPWJ")//二手_母婴服装美容_母婴儿童用品玩具
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_myetypwjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_MYFZMR_FZXMXB")//二手_母婴服装美容_服装鞋帽
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_fzxmxbjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_MYFZMR_MRBJ")//二手_母婴服装美容_美容保健
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_mrbjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_WHYL_YSPSCP")//二手_文化娱乐_艺术品收藏品
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_whyl_yspscpjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_WHYL_WTHWYQ")//二手_文化娱乐_文体户外乐器
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_whyl_wthwyqjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_WHYL_TSYXRJ")//二手_文化娱乐_图书音像软件
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_whyl_tsyxrjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_WHYL_WYXNWP")//二手_文化娱乐_网游虚拟物品
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_whyl_wyxnwpjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_PWKQ_MPKQ")//二手_票务卡券_门票卡券
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_pwkq_MPKQjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_PWKQ_MPKQView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_QTES_ESSB")//二手_其它二手_二手设备
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_qtes_essbjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_QTES_CRYP")//二手_其它二手_成人用品
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_qtes_crypjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + GetOrder(OrderColumn, OrderType));
                    var list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var obj in listnew)
                    {
                        obj.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", obj.JCXXID));
                        obj.BCMSString = BinaryHelper.BinaryToString(obj.BCMS);
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

        //加载二手详细信息
        public object LoadESXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "ESXX_SJSM_ESSJ") //二手_手机数码_二手手机
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_essjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_ESSJView> list = ConvertHelper.DataTableToList<ES_SJSM_ESSJView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_SJSM_BJBDN") //二手_手机数码_笔记本电脑
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_bjbdnjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_BJBDNView> list = ConvertHelper.DataTableToList<ES_SJSM_BJBDNView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_SJSM_PBDN") //二手_手机数码_平板电脑
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_pbdnjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_PBDNView> list = ConvertHelper.DataTableToList<ES_SJSM_PBDNView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_SJSM_SMCP") //二手_手机数码_数码产品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_smcpjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_SMCPView> list = ConvertHelper.DataTableToList<ES_SJSM_SMCPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_SJSM_TSJ") //二手_手机数码_台式机/配件
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_tsjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_TSJView> list = ConvertHelper.DataTableToList<ES_SJSM_TSJView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_JDJJBG_ESJD") //二手_家电家具办公_二手家电
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_esjdjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_ESJDView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJDView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_JDJJBG_ESJJ") //二手_家电家具办公_二手家具
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_esjjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_ESJJView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_JDJJBG_JJRY") //二手_家电家具办公_二手家具
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_jjryjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_JJRYView> list = ConvertHelper.DataTableToList<ES_JDJJBG_JJRYView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_JDJJBG_BGSB") //二手_家电家具办公_办公设备
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_bgsbjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_MYFZMR_MYETYPWJ") //二手_母婴服装美容_母婴儿童用品玩具
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_myfzmr_myetypwjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_MYFZMR_FZXMXB") //二手_母婴服装美容_服装鞋帽箱包
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_myfzmr_fzxmxbjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_MYFZMR_MRBJ") //二手_母婴服装美容_美容保健
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_myfzmr_mrbjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_WHYL_YSPSCP") //二手_文化娱乐_艺术品收藏品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_whyl_yspscpjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_WHYL_WTHWYQ") //二手_文化娱乐_文体户外乐器
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_whyl_wthwyqjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_WHYL_TSYXRJ") //二手_文化娱乐_图书音像软件
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_whyl_tsyxrjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_WHYL_WYXNWP") //二手_文化娱乐_网游虚拟物品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_whyl_wyxnwpjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_PWKQ_MPKQ") //二手_票务卡券_门票卡券
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_pwkq_MPKQjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_PWKQ_MPKQView> list = ConvertHelper.DataTableToList<ES_PWKQ_MPKQView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_QTES_ESSB") //二手_其它二手_二手设备
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_qtes_essbjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    UpdateLLCS(list[0].JCXXID);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = GetGRXX(list[0].YHID) };
                }
                if (TYPE == "ESXX_QTES_CRYP") //二手_其它二手_成人用品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_qtes_crypjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
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