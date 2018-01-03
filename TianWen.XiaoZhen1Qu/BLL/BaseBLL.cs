using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using CommonClassLib.Helper;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.GY;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class BaseBLL : IBaseBLL
    {
        public IDAO DAO { set; get; }

        //根据父级ID获取字典表
        public object LoadByParentID(string ParentID, string TBName)
        {
            try
            {
                if (TBName == "CODES_ES_SJSM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ES_JDJJBG")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_JDJJBG>(String.Format("FROM CODES_ES_JDJJBG WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ES_MYFZMR")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_MYFZMR>(String.Format("FROM CODES_ES_MYFZMR WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ES_WHYL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_WHYL>(String.Format("FROM CODES_ES_WHYL WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ES_PWKQ")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_PWKQ>(String.Format("FROM CODES_ES_PWKQ WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ES_QTES")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_PFCG")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_JYPX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX>(String.Format("FROM CODES_JYPX WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_CL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_CL_JC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CL_JC>(String.Format("FROM CODES_CL_JC WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_CW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_LYJD")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_LYJD>(String.Format("FROM CODES_LYJD WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ZXJC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_ZSJM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_SWFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_SHFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SHFW>(String.Format("FROM CODES_SHFW WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_NLMFY")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_NLMFY>(String.Format("FROM CODES_NLMFY WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                if (TBName == "CODES_QZZP")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE PARENTID = '{0}' ORDER BY CODEORDER", ParentID)) };
                return new { Result = EnResultType.Failed, Message = "表名未找到" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //根据CODEVALUE和TYPENAME获取字典表
        public object LoadByCodeValueAndTypeName(string CODEVALUE, string TYPENAME, string TBName)
        {
            try
            {
                if (TBName == "CODES_ES_SJSM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_ES_QTES")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
                if (TBName == "CODES_ES_WHYL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_WHYL>(String.Format("FROM CODES_ES_WHYL WHERE CODEVALUE = '{0}' AND TYPENAME = '{1}' ORDER BY CODEORDER", CODEVALUE, TYPENAME)) };
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

        //根据TYPENAME获取字典表
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
                if (TBName == "CODES_ES_PWKQ")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ES_PWKQ>(String.Format("FROM CODES_ES_PWKQ WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
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
                if (TBName == "CODES_LR")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_LR>(String.Format("FROM CODES_LR WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_XXYL")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_XXYL>(String.Format("FROM CODES_XXYL WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ZXJC")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_ZSJM")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_QZZP")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_SWFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_SHFW")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_SHFW>(String.Format("FROM CODES_SHFW WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_JYPX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX>(String.Format("FROM CODES_JYPX WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_JYPX_XX")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_JYPX_XX>(String.Format("FROM CODES_JYPX_XX WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
                if (TBName == "CODES_LYJD")
                    return new { Result = EnResultType.Success, list = DAO.Repository.GetObjectList<CODES_LYJD>(String.Format("FROM CODES_LYJD WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME)) };
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

        //根据TYPENAME获取字典表
        public object LoadCODESByTYPENAMES(string TYPENAMES, string TBName, string XZQDM)
        {
            try
            {
                IList<CODES_DISTRICT> districts = DAO.Repository.GetObjectList<CODES_DISTRICT>(String.Format("FROM CODES_DISTRICT WHERE PARENTID = '{0}' ORDER BY CODEORDER", XZQDM));
                if (TBName == "CODES_FC")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_FC>(String.Format("FROM CODES_FC WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ES_SJSM")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ES_SJSM>(String.Format("FROM CODES_ES_SJSM WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ES_JDJJBG")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ES_JDJJBG>(String.Format("FROM CODES_ES_JDJJBG WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ES_MYFZMR")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ES_MYFZMR>(String.Format("FROM CODES_ES_MYFZMR WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ES_QTES")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ES_QTES>(String.Format("FROM CODES_ES_QTES WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ES_WHYL")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ES_WHYL>(String.Format("FROM CODES_ES_WHYL WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ES_PWKQ")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ES_PWKQ>(String.Format("FROM CODES_ES_PWKQ WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_PFCG")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_PFCG>(String.Format("FROM CODES_PFCG WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_CL")
                {
                    if (TYPENAMES.Contains("轿车品牌"))
                        return new { Result = EnResultType.Success, districts, jclist = DAO.Repository.GetObjectList<CODES_CL_JC>(String.Format("FROM CODES_CL_JC WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", "'轿车品牌'")), list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                    else
                        return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_CL>(String.Format("FROM CODES_CL WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                }
                if (TBName == "CODES_CW")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_CW>(String.Format("FROM CODES_CW WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_CY")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_CY>(String.Format("FROM CODES_CY WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_LR")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_LR>(String.Format("FROM CODES_LR WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_XXYL")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_XXYL>(String.Format("FROM CODES_XXYL WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ZXJC")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ZXJC>(String.Format("FROM CODES_ZXJC WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_ZSJM")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_ZSJM>(String.Format("FROM CODES_ZSJM WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_QZZP")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE TYPENAME in({0}) AND CODENAME !='面议' ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_SWFW")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_SWFW>(String.Format("FROM CODES_SWFW WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_SHFW")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_SHFW>(String.Format("FROM CODES_SHFW WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_JYPX")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_JYPX>(String.Format("FROM CODES_JYPX WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_JYPX_XX")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_JYPX_XX>(String.Format("FROM CODES_JYPX_XX WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_LYJD")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_LYJD>(String.Format("FROM CODES_LYJD WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_HQSY")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_HQSY>(String.Format("FROM CODES_HQSY WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                if (TBName == "CODES_NLMFY")
                    return new { Result = EnResultType.Success, districts, list = DAO.Repository.GetObjectList<CODES_NLMFY>(String.Format("FROM CODES_NLMFY WHERE TYPENAME in({0}) ORDER BY TYPENAME,CODEORDER", TYPENAMES)) };
                return new { Result = EnResultType.Failed, Message = "表名未找到" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //根据SUPERNAME获取行政区
        public object LoadQYBySuperName(string PARENTID)
        {
            try
            {
                IList<CODES_DISTRICT> list = DAO.Repository.GetObjectList<CODES_DISTRICT>(String.Format("FROM CODES_DISTRICT WHERE PARENTID = '{0}' ORDER BY CODEORDER", PARENTID));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        //根据SUPERCODE获取行政区
        public object LoadDDByQY(string SUPERCODE)
        {
            try
            {
                IList<CODES_DISTRICT> list = DAO.Repository.GetObjectList<CODES_DISTRICT>(String.Format("FROM CODES_DISTRICT WHERE PARENTID = '{0}' ORDER BY CODEORDER", SUPERCODE));
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
            CODES_XXLB xl = DAO.Repository.GetObjectById<CODES_XXLB>(LBID);
            CODES_XXLB dl = DAO.Repository.GetObjectById<CODES_XXLB>(xl.PARENTID);
            return dl.LBNAME + "-" + xl.LBNAME;
        }

        //根据TYPENAME获取字典表职位类别信息
        public object LoadZWLBXX(string TYPENAME)
        {
            try
            {
                IList<CODES_QZZP> list_first = DAO.Repository.GetObjectList<CODES_QZZP>(String.Format("FROM CODES_QZZP WHERE TYPENAME = '{0}' ORDER BY CODEORDER", TYPENAME));
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

        //保存照片
        public void SavePhotos(List<PHOTOS> photos, string JCXXID)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            if (photos.Count > 0)
            {
                //照片全删全插
                List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", JCXXID)).ToList();
                foreach (var obj in old_photos)
                {
                    DAO.Remove(obj);
                }
            }
            foreach (var obj in photos)
            {
                obj.JCXXID = JCXXID;
                DAO.Save(obj);
            }

            if (photos.Count > 0)
            {
                //删除多余照片文件
                foreach (FileInfo fileobj in fileinfos)
                {
                    if (!photoNames.Contains(fileobj.Name))
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/" + fileobj.Name);
                }
            }
        }

        //修改浏览次数
        public void UpdateLLCS(string JCXXID)
        {
            JCXX obj = DAO.GetObjectByID<JCXX>(JCXXID);
            obj.LLCS += 1;
            DAO.Update(obj);
        }

        //获取查询条件
        public string GetConditin(string Condition)
        {
            StringBuilder condition = new StringBuilder();
            if (!string.IsNullOrEmpty(Condition))
            {
                string[] conditions = Condition.Split(',');
                for (int i = 0; i < conditions.Count(); i++)
                {
                    string[] array = conditions[i].Split(':');
                    if (array[1] != "全部")
                    {
                        if (array[0] == "ZJ" || array[0] == "JG" || array[0] == "SJ" || array[0] == "PFM" || array[0] == "MJ" || array[0] == "NL" || array[0] == "MSJ" || array[0] == "JG_CR" || array[0] == "S")
                        {
                            if (array[1].Contains("万元"))
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("万元")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("万元"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("万元"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                            else if (array[1].Contains("平米"))
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("平米")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("平米"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("平米"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                            else if (array[1].Contains("月龄"))
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("月龄")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("月龄"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("月龄"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                            else if (array[1].Contains("元"))
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("元")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("元"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("元"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                            else if (array[1].Contains("套"))
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("套")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("套"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("套"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                            else if (array[1].Contains("日游"))
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("日游")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("及以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("日游"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("日游"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                            else if (array[1].Contains("室"))
                            {
                                if (array[1].Contains("以上"))
                                {
                                    condition.AppendFormat(" and S >= 4");
                                }
                                else
                                {
                                    if (array[1].Contains("一"))
                                        condition.AppendFormat(" and S = 1");
                                    if (array[1].Contains("二"))
                                        condition.AppendFormat(" and S = 2");
                                    if (array[1].Contains("三"))
                                        condition.AppendFormat(" and S = 3");
                                    if (array[1].Contains("四"))
                                        condition.AppendFormat(" and S = 4");
                                }
                            }
                            else
                            {
                                if (array[1].Contains("-"))
                                {
                                    string[] zjarray = array[1].Substring(0, array[1].IndexOf("元")).Split('-');
                                    condition.AppendFormat(" and {0} >= {1} and {0} <= {2}", array[0], zjarray[0], zjarray[1]);
                                }
                                else if (array[1].Contains("以上"))
                                {
                                    string zjsx = array[1].Substring(0, array[1].IndexOf("元"));
                                    condition.AppendFormat(" and {0} >= {1}", array[0], zjsx);
                                }
                                else
                                {
                                    string zjxx = array[1].Substring(0, array[1].IndexOf("元"));
                                    condition.AppendFormat(" and {0} <= {1}", array[0], zjxx);
                                }
                            }
                        }
                        else
                        {
                            condition.AppendFormat(" and {0} like '%{1}%'", array[0], array[1]);
                        }
                    }
                }
            }
            return condition.ToString();
        }

        //获取排序条件
        public string GetOrder(string OrderColumn, string OrderType)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(OrderColumn) && !string.IsNullOrEmpty(OrderType))
            {
                string[] columns = OrderColumn.Split(',');
                string[] types = OrderType.Split(',');
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i == 0)
                    {
                        if (!string.IsNullOrEmpty(columns[i]) && !string.IsNullOrEmpty(types[i]))
                        {
                            if (columns[i] == "ZJ")
                                result += " ORDER BY TO_NUMBER(" + columns[i] + ") " + types[i];
                            else
                                result += " ORDER BY " + columns[i] + " " + types[i];
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(columns[i]) && !string.IsNullOrEmpty(types[i]))
                        {
                            if (columns[i] == "ZJ")
                                result += ",TO_NUMBER(" + columns[i] + ") " + types[i];
                            else
                                result += "," + columns[i] + " " + types[i];
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(result))
                result = " ORDER BY ZXGXSJ DESC";
            return result;
        }

        //获取个人信息
        public List<GRXXView> GetGRXX(string yhid)
        {
            DataTable dtgrxx = DAO.Repository.GetDataTable(string.Format("select * from yhjbxx y where y.yhid = '{0}'", yhid));
            return ConvertHelper.DataTableToList<GRXXView>(dtgrxx);
        }

        //相关类目
        public object LoadXGLM(string TYPE, string XZQ)
        {
            try
            {
                string[] array = TYPE.Split(',');
                IList<CODES_XXLB> list = DAO.Repository.GetObjectList<CODES_XXLB>(String.Format("FROM CODES_XXLB WHERE FBYM LIKE '{0}_%' OR FBYM LIKE '{1}_%' ORDER BY LBORDER", array[0], array[1]));
                return new { Result = EnResultType.Success, list = list, xzq = XZQ };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }

}
