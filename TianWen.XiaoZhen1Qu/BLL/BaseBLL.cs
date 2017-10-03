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

        public object LoadCODES_CW(string TYPENAME)
        {
            try
            {
                IList<CODES_CW> list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_PWKQ(string TYPENAME)
        {
            try
            {
                IList<CODES_PWKQ> list = DAO.Repository.GetObjectList<CODES_PWKQ>(String.Format("FROM CODES_PWKQ WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_CY(string TYPENAME)
        {
            try
            {
                IList<CODES_CY> list = DAO.Repository.GetObjectList<CODES_CY>(String.Format("FROM CODES_CY WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_XXYL(string TYPENAME)
        {
            try
            {
                IList<CODES_XXYL> list = DAO.Repository.GetObjectList<CODES_XXYL>(String.Format("FROM CODES_XXYL WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_LR(string TYPENAME)
        {
            try
            {
                IList<CODES_LR> list = DAO.Repository.GetObjectList<CODES_LR>(String.Format("FROM CODES_LR WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ZSJM(string TYPENAME)
        {
            try
            {
                IList<CODES_ZSJM> list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_PFCG(string TYPENAME)
        {
            try
            {
                IList<CODES_PFCG> list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_QZZP(string TYPENAME)
        {
            try
            {
                IList<CODES_QZZP> list = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_SHFW(string TYPENAME)
        {
            try
            {
                IList<CODES_SHFW> list = DAO.Repository.GetObjectList<CODES_SHFW>(String.Format("FROM CODES_SHFW WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
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

        public object LoadKCPPXX(string KCLX, string KCBQ)
        {
            try
            {
                IList<CODES_CL> list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME = '{0}' AND CODEVALUE like '%{1}%' ORDER BY CODEORDER", KCLX, KCBQ));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadJCPPXX(string JCLX, string JCBQ)
        {
            try
            {
                IList<CODES_CL_JC> list = DAO.Repository.GetObjectList<CODES_CL_JC>(String.Format("FROM CODES_CL_JC WHERE TYPENAME = '{0}' AND CODEVALUE like '%{1}%' ORDER BY CODEORDER", JCLX, JCBQ));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
        
        public object LoadKCCXXX(string PPID)
        {
            try
            {
                IList<CODES_CL> list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE PARENTID = '{0}' ORDER BY CODEORDER", PPID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadJXXX(string JXID)
        {
            try
            {
                IList<CODES_ZSJM> list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE PARENTID = '{0}' ORDER BY CODEORDER", JXID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadHNCYXX(string PZID)
        {
            try
            {
                IList<CODES_CW> list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE PARENTID = '{0}' ORDER BY CODEORDER", PZID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCWYPSPXX(string LBID)
        {
            try
            {
                IList<CODES_CW> list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE PARENTID = '{0}' ORDER BY CODEORDER", LBID));
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

        public object LoadLPXX(string LPID)
        {
            try
            {
                IList<CODES_PFCG> list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE PARENTID like '%{0}%' ORDER BY CODEORDER", LPID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCWPZXX(string CWBQ)
        {
            try
            {
                IList<CODES_CW> list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE CODEVALUE like '%{0}%' ORDER BY CODEORDER", CWBQ));
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

        public object LoadMRBJXX(string name)
        {
            try
            {
                IList<CODES_ZSJM> listmrbjxx = new List<CODES_ZSJM>();
                IList<CODES_ZSJM> list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE CODENAME = '{0}' ORDER BY CODEORDER", name));
                if (list.Count > 0)
                {
                    listmrbjxx = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE PARENTID = '{0}' ORDER BY CODEORDER", list.FirstOrDefault().CODEID));
                }
                return new { Result = EnResultType.Success, list = listmrbjxx };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadLPXSPXX(string name)
        {
            try
            {
                IList<CODES_ZSJM> listmrbjxx = new List<CODES_ZSJM>();
                IList<CODES_ZSJM> list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE CODENAME = '{0}' ORDER BY CODEORDER", name));
                if (list.Count > 0)
                {
                    listmrbjxx = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE PARENTID = '{0}' ORDER BY CODEORDER", list.FirstOrDefault().CODEID));
                }
                return new { Result = EnResultType.Success, list = listmrbjxx };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadZWLBXX(string typename)
        {
            try
            {
                IList<CODES_QZZP> list_first = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE TYPENAME = '{0}' ORDER BY CODEORDER", typename));
                foreach (var obj in list_first)
                {
                    obj.childs = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE PARENTID = '{0}' ORDER BY CODEORDER", obj.CODEID)).ToList();
                    foreach (var objchild in obj.childs)
                    {
                        objchild.childs = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE PARENTID = '{0}' ORDER BY CODEORDER", objchild.CODEID)).ToList();
                    }
                }
                return new { Result = EnResultType.Success, list = list_first };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }

}
