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
                IList<CODES_XXLB> list = DAO.Repository.GetObjectList<CODES_XXLB>(String.Format("FROM CODES_XXLB WHERE LBLX='大类' AND LBNAME !='餐饮' ORDER BY LBORDER"));
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
                IList<CODES_XXLB> result = new List<CODES_XXLB>();
                IList<CODES_XXLB> list = DAO.Repository.GetObjectList<CODES_XXLB>(String.Format("FROM CODES_XXLB WHERE LBLX='小类' ORDER BY LBORDER"));

                foreach (var obj in list)
                {
                    if (obj.PARENTID.ToString() == LBID)
                    {
                        foreach (var childobj in list)
                        {
                            if (childobj.PARENTID == obj.LBID)
                            {
                                obj.CODES_XXLBS.Add(childobj);
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
                IList<CODES_XXLB> list = DAO.Repository.GetObjectList<CODES_XXLB>(String.Format("FROM CODES_XXLB WHERE LBID='{0}'", LBID));

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
