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


        public object LoadCODESByTYPENAME(string TYPENAME, string TBName)
        {
            try
            {
                if (TBName == "CODES_FC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_FC>(String.Format("FROM CODES_FC WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ES_SJSM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ES_JDJJBG")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_JDJJBG>(String.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ES_MYFZMR")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_MYFZMR>(String.Format("FROM CODES_ES_MYFZMR WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ES_QTES")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ES_WHYL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_WHYL>(String.Format("FROM CODES_ES_WHYL WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_PWKQ")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_PWKQ>(String.Format("FROM CODES_PWKQ WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_PFCG")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_CL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_CL_JC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL_JC>(String.Format("FROM CODES_CL_JC WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_CW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_CY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CY>(String.Format("FROM CODES_CY WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_XXYL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_XXYL>(String.Format("FROM CODES_XXYL WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ZXJC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ZSJM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_SWFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_JYPX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX>(String.Format("FROM CODES_JYPX WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_JYPX_XX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX_XX>(String.Format("FROM CODES_JYPX_XX WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_HQSY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_HQSY>(String.Format("FROM CODES_HQSY WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_NLMFY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_NLMFY>(String.Format("FROM CODES_NLMFY WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                return new { Result = EnResultType.Failed, Message = "表名未找到" };
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

        public object LoadCODES_SWFW(string TYPENAME)
        {
            try
            {
                IList<CODES_SWFW> list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_JYPX(string TYPENAME)
        {
            try
            {
                IList<CODES_JYPX> list = DAO.Repository.GetObjectList<CODES_JYPX>(String.Format("FROM CODES_JYPX WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_LYJD(string TYPENAME)
        {
            try
            {
                IList<CODES_LYJD> list = DAO.Repository.GetObjectList<CODES_LYJD>(String.Format("FROM CODES_LYJD WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_ZXJC(string TYPENAME)
        {
            try
            {
                IList<CODES_ZXJC> list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_HQSY(string TYPENAME)
        {
            try
            {
                IList<CODES_HQSY> list = DAO.Repository.GetObjectList<CODES_HQSY>(String.Format("FROM CODES_HQSY WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadCODES_NLMFY(string TYPENAME)
        {
            try
            {
                IList<CODES_NLMFY> list = DAO.Repository.GetObjectList<CODES_NLMFY>(String.Format("FROM CODES_NLMFY WHERE TYPENAME='{0}' ORDER BY CODEORDER", TYPENAME));
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


        public object LoadBJQXXX(string LBID)
        {
            try
            {
                IList<CODES_SHFW> list = DAO.Repository.GetObjectList<CODES_SHFW>(String.Format("FROM CODES_SHFW WHERE PARENTID = '{0}' ORDER BY CODEORDER", LBID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadByParentID(string ParentID, string TBName)
        {
            try
            {
                if (TBName == "CODES_ES_SJSM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_PFCG")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_CL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_CW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ZXJC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ZSJM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_SWFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_NLMFY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_NLMFY>(String.Format("FROM CODES_NLMFY WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                return new { Result = EnResultType.Failed, Message = "表名未找到" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadByCodeValueAndTypeName(string CODEVALUE, string TYPENAME, string TBName)
        {
            try
            {
                if (TBName == "CODES_ES_SJSM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_ES_QTES")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_PFCG")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_CL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_CL_JC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL_JC>(String.Format("FROM CODES_CL_JC WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_CW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_ZXJC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_ZSJM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_SWFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_JYPX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX>(String.Format("FROM CODES_JYPX WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_JYPX_XX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX_XX>(String.Format("FROM CODES_JYPX_XX WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_HQSY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_HQSY>(String.Format("FROM CODES_HQSY WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_NLMFY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_NLMFY>(String.Format("FROM CODES_NLMFY WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                return new { Result = EnResultType.Failed, Message = "表名未找到" };
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
