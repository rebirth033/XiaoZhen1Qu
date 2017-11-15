using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.FC;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.GY;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class FCCXBLL : BaseBLL, IFCCXBLL
    {
        //加载房产信息
        public object LoadFCXX(string TYPE, string Condition, string PageIndex, string PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "FCXX_ZZF")//房产_整租房
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.*,x.* from jcxx a,fc_zzfjbxx b  left join codes_fuzhou_xqjbxx x on b.xqmc = x.xqmc where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<FC_ZZFView> list = ConvertHelper.DataTableToList<FC_ZZFView>(dt);
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
                if (TYPE == "FCXX_DZF")//房产_短租房
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,fc_dzfjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<FC_DZFView> list = ConvertHelper.DataTableToList<FC_DZFView>(dt);
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
                if (TYPE == "FCXX_ESF")//房产_二手房
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,fc_esfjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<FC_ESFView> list = ConvertHelper.DataTableToList<FC_ESFView>(dt);
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
                if (TYPE == "FCXX_SP")//房产_商铺
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,fc_spjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<FC_SPView> list = ConvertHelper.DataTableToList<FC_SPView>(dt);
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
                if (TYPE == "FCXX_XZL")//房产_写字楼
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,fc_xzljbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<FC_XZLView> list = ConvertHelper.DataTableToList<FC_XZLView>(dt);
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
                if (TYPE == "FCXX_CF" || TYPE == "FCXX_CK" || TYPE == "FCXX_TD" || TYPE == "FCXX_CW")//房产_厂房/仓库/土地/车位
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,fc_cfcktdcwjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<FC_CFCKTDCWView> list = ConvertHelper.DataTableToList<FC_CFCKTDCWView>(dt);
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

        //加载房产信息
        public object LoadFCXX(string TYPE, string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "FCXX_ZZF") //房产_整租房
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.*,x.* from jcxx a,fc_zzfjbxx b left join codes_fuzhou_xqjbxx x on b.xqmc = x.xqmc where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<FC_ZZFView> list = ConvertHelper.DataTableToList<FC_ZZFView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "FCXX_DZF") //房产_短租房
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,fc_dzfjbxx b where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<FC_DZFView> list = ConvertHelper.DataTableToList<FC_DZFView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "FCXX_ESF") //房产_二手房
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.*,x.* from jcxx a,fc_esfjbxx b left join codes_fuzhou_xqjbxx x on b.xqmc = x.xqmc where a.jcxxid = b.jcxxid and id = '{0}'  order by zxgxsj desc", ID));
                    List<FC_ESFView> list = ConvertHelper.DataTableToList<FC_ESFView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "FCXX_SP") //房产_商铺
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,fc_spjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<FC_SPView> list = ConvertHelper.DataTableToList<FC_SPView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "FCXX_XZL") //房产_写字楼
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,fc_xzljbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<FC_XZLView> list = ConvertHelper.DataTableToList<FC_XZLView>(dt);
                    foreach (var jcxx in list)
                    {
                        jcxx.PHOTOS = DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}' ORDER BY PHOTONAME", jcxx.JCXXID));
                    }
                    DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", list[0].YHID));
                    List<GRXXView> grxxlist = ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
                    return new { Result = EnResultType.Success, list = list, BCMSString = BinaryHelper.BinaryToString(list[0].BCMS), grxxlist = grxxlist };
                }
                if (TYPE == "FCXX_CF" || TYPE == "FCXX_CK" || TYPE == "FCXX_TD" || TYPE == "FCXX_CW")//房产_厂房/仓库/土地/车位
                {
                    dt = DAO.Repository.GetDataTable(string.Format("select a.*,b.* from jcxx a,fc_cfcktdcwjbxx b where a.jcxxid = b.jcxxid and id = '{0}' order by zxgxsj desc", ID));
                    List<FC_CFCKTDCWView> list = ConvertHelper.DataTableToList<FC_CFCKTDCWView>(dt);
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