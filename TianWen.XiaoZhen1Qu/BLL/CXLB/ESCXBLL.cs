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
        //加载二手信息
        public object LoadESXX(string TYPE, string Condition, string PageIndex, string PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "ESXX_SJSM_ESSJ")//二手_手机数码_二手手机
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_essjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_SJSM_ESSJView> list = ConvertHelper.DataTableToList<ES_SJSM_ESSJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_BJBDN")//二手_手机数码_笔记本电脑
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_bjbdnjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_SJSM_BJBDNView> list = ConvertHelper.DataTableToList<ES_SJSM_BJBDNView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_PBDN")//二手_手机数码_平板电脑
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_pbdnjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_SJSM_PBDNView> list = ConvertHelper.DataTableToList<ES_SJSM_PBDNView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_SMCP")//二手_手机数码_数码产品
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_smcpjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_SJSM_SMCPView> list = ConvertHelper.DataTableToList<ES_SJSM_SMCPView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_SJSM_TSJ")//二手_手机数码_台式机/配件
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_sjsm_tsjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_SJSM_TSJView> list = ConvertHelper.DataTableToList<ES_SJSM_TSJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_ESJD")//二手_家电家具办公_二手家电
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_esjdjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_JDJJBG_ESJDView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJDView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_ESJJ")//二手_家电家具办公_二手家具
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_esjjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_JDJJBG_ESJJView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_JJRY")//二手_家电家具办公_家居日用
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_jjryjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_JDJJBG_ESJJView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_JDJJBG_BGSB")//二手_家电家具办公_办公设备
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_jdjjbg_bgsbjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

                    var listnew = from p in list.Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize)).Take(int.Parse(PageSize)) select p;

                    foreach (var jcxx in listnew)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                        jcxx.BCMSString = BinaryHelper.BinaryToString(jcxx.BCMS);
                    }
                    return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount };
                }
                if (TYPE == "ESXX_MYFZMR_MYETYPWJ")//二手_母婴服装美容_母婴儿童用品玩具
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,es_myfzmr_myetypwjjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);
                    int TotalCount = list.Count;
                    var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                    int WCCount = WDCountlist.Count();

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
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_SJSM_BJBDN") //二手_手机数码_笔记本电脑
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_bjbdnjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_BJBDNView> list = ConvertHelper.DataTableToList<ES_SJSM_BJBDNView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_SJSM_PBDN") //二手_手机数码_平板电脑
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_pbdnjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_PBDNView> list = ConvertHelper.DataTableToList<ES_SJSM_PBDNView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_SJSM_SMCP") //二手_手机数码_数码产品
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_smcpjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_SMCPView> list = ConvertHelper.DataTableToList<ES_SJSM_SMCPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_SJSM_TSJ") //二手_手机数码_台式机/配件
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_sjsm_tsjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_SJSM_TSJView> list = ConvertHelper.DataTableToList<ES_SJSM_TSJView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_JDJJBG_ESJD") //二手_家电家具办公_二手家电
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_esjdjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_ESJDView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJDView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_JDJJBG_ESJJ") //二手_家电家具办公_二手家具
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_esjjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_ESJJView> list = ConvertHelper.DataTableToList<ES_JDJJBG_ESJJView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_JDJJBG_JJRY") //二手_家电家具办公_二手家具
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_jjryjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_JJRYView> list = ConvertHelper.DataTableToList<ES_JDJJBG_JJRYView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_JDJJBG_BGSB") //二手_家电家具办公_办公设备
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_jdjjbg_bgsbjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "ESXX_MYFZMR_MYETYPWJ") //二手_母婴服装美容_母婴儿童用品玩具
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,es_myfzmr_myetypwjjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<ES_JDJJBG_BGSBView> list = ConvertHelper.DataTableToList<ES_JDJJBG_BGSBView>(dt);
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