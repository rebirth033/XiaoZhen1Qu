using System;
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
    public class CWCXBLL : BaseBLL, ICWCXBLL
    {
        //加载宠物信息
        public object LoadCWXX(string TYPE, string Condition, string PageIndex, string PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                if (TYPE == "CWXX_CWG")//宠物_宠物狗
                {
                    dt = DAO.Repository.GetDataTable("select a.*,b.* from jcxx a,cw_cwgjbxx b where a.jcxxid = b.jcxxid " + GetConditin(Condition) + " order by zxgxsj desc");
                    List<CW_CWGView> list = ConvertHelper.DataTableToList<CW_CWGView>(dt);
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

        //获取查询条件
        public string GetConditin(string Condition)
        {
            StringBuilder condition = new StringBuilder();
            string[] conditions = Condition.Split(',');
            for (int i = 0; i < conditions.Count(); i++)
            {
                string[] array = conditions[i].Split(':');
                if (array[1] != "不限")
                {
                    if (array[0] == "ZJ")
                    {
                        if (array[1].Contains("-"))
                        {
                            string[] zjarray = array[1].TrimEnd('元').Split('-');
                            condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                        }
                        else if (array[1].Contains("以上"))
                        {
                            string zjsx = array[1].Substring(0, array[1].IndexOf('元'));
                            condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                        }
                        else
                        {
                            string zjxx = array[1].Substring(0, array[1].IndexOf('元'));
                            condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                        }
                    }
                    else
                    {
                        condition.AppendFormat(" and {0} = '{1}'", array[0], array[1]);
                    }
                }
            }
            return condition.ToString();
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