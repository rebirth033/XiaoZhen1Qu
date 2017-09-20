using System;
using System.Collections.Generic;
using System.Linq;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class BaseBLL : IBaseBLL
    {
        public IDAO DAO { set; get; }

        public object LoadCODES_FC(string TYPENAME)
        {
            try
            {
                IList<CODES_FC> list = DAO.Repository.GetObjectList<CODES_FC>(String.Format("FROM CODES_FC WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ES_SJSM(string TYPENAME)
        {
            try
            {
                IList<CODES_ES_SJSM> list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ES_JDJJBG(string TYPENAME)
        {
            try
            {
                IList<CODES_ES_JDJJBG> list = DAO.Repository.GetObjectList<CODES_ES_JDJJBG>(String.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ES_MYFZMR(string TYPENAME)
        {
            try
            {
                IList<CODES_ES_MYFZMR> list = DAO.Repository.GetObjectList<CODES_ES_MYFZMR>(String.Format("FROM CODES_ES_MYFZMR WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ES_WHYL(string TYPENAME)
        {
            try
            {
                IList<CODES_ES_WHYL> list = DAO.Repository.GetObjectList<CODES_ES_WHYL>(String.Format("FROM CODES_ES_WHYL WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ES_QTES(string TYPENAME)
        {
            try
            {
                IList<CODES_ES_QTES> list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_CL(string TYPENAME)
        {
            try
            {
                IList<CODES_CL> list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadQYBySuperName(string SUPERNAME)
        {
            try
            {
                IList<DISTRICT> list = DAO.Repository.GetObjectList<DISTRICT>(String.Format("FROM DISTRICT WHERE SUPERNAME like '%{0}%' and NAME != '市辖区' ORDER BY CODE", SUPERNAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadSQByQY(string QY)
        {
            try
            {
                IList<DISTRICT> list = DAO.Repository.GetObjectList<DISTRICT>(String.Format("FROM DISTRICT WHERE SUPERCODE like '%{0}%' ORDER BY CODE", QY));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }

        }

        public object LoadSJXHBySJPP(string SJPP)
        {
            try
            {
                IList<CODES_ES_SJSM> list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE PARENTID like '%{0}%' ORDER BY CODEORDER", SJPP));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadBJBXHByBJBPP(string BJBPP)
        {
            try
            {
                IList<CODES_ES_SJSM> list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE PARENTID like '%{0}%' ORDER BY CODEORDER", BJBPP));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadPBXHByPBPP(string PBPP)
        {
            try
            {
                IList<CODES_ES_SJSM> list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE PARENTID like '%{0}%' ORDER BY CODEORDER", PBPP));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadGCQXJBXX(string GCQX)
        {
            try
            {
                IList<CODES_ES_QTES> list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE CODEVALUE like '%{0}%' ORDER BY CODEORDER", GCQX));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadHCJBXX(string HC)
        {
            try
            {
                IList<CODES_CL> list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME = '货车品牌' AND CODEVALUE like '%{0}%' ORDER BY CODEORDER", HC));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadGCCJBXX(string GCC)
        {
            try
            {
                IList<CODES_CL> list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME = '工程车' AND CODEVALUE like '%{0}%' ORDER BY CODEORDER", GCC));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadGCCPPXX(string GCCLX, string GCCBQ)
        {
            try
            {
                IList<CODES_CL> list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME = '{0}' AND CODEVALUE like '%{1}%' ORDER BY CODEORDER", GCCLX, GCCBQ));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadGCQXXH(string PPID)
        {
            try
            {
                IList<CODES_ES_QTES> list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE PARENTID like '%{0}%' ORDER BY CODEORDER", PPID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //根据用户ID获取用户账户ID
        public string GetYHZHXXIDByYHID(string YHID)
        {
            try
            {
                IList<YHZHXX> list = DAO.Repository.GetObjectList<YHZHXX>(String.Format("FROM YHZHXX WHERE YHID='{0}'", YHID));
                if (list.Count > 0)
                    return list.FirstOrDefault().YHZHXXID;
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return string.Empty;
            }
        }

        //根据ID获取基础信息
        public JCXX GetJCXXByID(string JCXXID)
        {
            IList<JCXX> list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID='{0}'", JCXXID));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        //根据基础信息获取图片集
        public List<PHOTOS> GetPhtosByJCXXID(string JCXXID)
        {
            return DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}'", JCXXID)).ToList();
        }

        //根据用户名获取用户基本信息
        public YHJBXX GetYHJBXXByYHM(string YHM)
        {
            IList<YHJBXX> list = DAO.Repository.GetObjectList<YHJBXX>(String.Format("FROM YHJBXX WHERE YHM='{0}'", YHM));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        //根据类别ID获取类别全称
        public string GetLBQCByLBID(int LBID)
        {
            XXLB xl = DAO.Repository.GetObjectById<XXLB>(LBID);
            XXLB dl = DAO.Repository.GetObjectById<XXLB>(xl.PARENTID);
            return dl.LBNAME + "-" + xl.LBNAME;
        }
    }

}
