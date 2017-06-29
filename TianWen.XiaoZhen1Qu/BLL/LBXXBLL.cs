using System;
using System.Collections.Generic;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class LBXXBLL : BaseBLL, ILBXXBLL
    {
        public object LoadDL()
        {
            try
            {
                IList<XXLB> list = DAO.Repository.GetObjectList<XXLB>(String.Format("FROM XXLB WHERE LBLX='大类' ORDER BY LBORDER"));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadXL(string LBID)
        {
            try
            {
                IList<XXLB> result = new List<XXLB>();
                IList<XXLB> list = DAO.Repository.GetObjectList<XXLB>(String.Format("FROM XXLB WHERE LBLX='小类' ORDER BY LBORDER"));

                foreach (var obj in list)
                {
                    if (obj.PARENTID.ToString() == LBID)
                    {
                        foreach (var childobj in list)
                        {
                            if (childobj.PARENTID == obj.LBID)
                            {
                                obj.XXLBS.Add(childobj);
                            }
                        }
                        result.Add(obj);
                    }
                }

                return new { Result = EnResultType.Success, list = result };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadLBByID(string LBID)
        {
            try
            {
                IList<XXLB> list = DAO.Repository.GetObjectList<XXLB>(String.Format("FROM XXLB WHERE LBID='{0}'", LBID));

                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }


}
