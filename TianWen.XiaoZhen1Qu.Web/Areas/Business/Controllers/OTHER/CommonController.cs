﻿using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CommonController : BaseController
    {
        public ICommonBLL CommonBLL { get; set; }

        //根据基础信息ID和类别ID获取
        public JsonResult GetIDByJCXXIDAndLBID()
        {
            string LBID = Request["LBID"];
            string JCXXID = Request["JCXXID"];
            object result = CommonBLL.GetIDByJCXXIDAndLBID(JCXXID, LBID);
            return Json(result);
        }
        //根据行政区级别获取行政区
        public JsonResult GetDistrictByGrade()
        {
            string Grade = Request["Grade"];
            object result = CommonBLL.GetDistrictByGrade(Grade);
            return Json(result);
        }
        //根据行政区简称获取行政区
        public JsonResult GetDistrictByShortName()
        {
            string Grade = Request["ShortName"];
            object result = CommonBLL.GetDistrictByShortName(Grade);
            return Json(result);
        }
        //获取父级行政区
        public JsonResult GetDistrictBySuperCode()
        {
            string SuperCode = Request["SuperCode"];
            object result = CommonBLL.GetDistrictBySuperCode(SuperCode);
            return Json(result);
        }
        //根据行政区编码获取省内同级行政区
        public JsonResult GetDistrictTJByXZQDM()
        {
            string XZQDM = Request["XZQDM"];
            object result = CommonBLL.GetDistrictTJByXZQDM(XZQDM);
            return Json(result);
        }
        //切换行政区
        public JsonResult QHXZQ()
        {
            Session["XZQ"] = Request["XZQ"];
            Session["XZQDM"] = Request["XZQDM"];
            return Json(new { Result = EnResultType.Success });
        }
        //根据TYPENAME获取字典表
        public JsonResult LoadCODESByTYPENAME()
        {
            string TYPENAME = Request["TYPENAME"];
            string TBName = Request["TBName"];
            return Json(CommonBLL.LoadCODESByTYPENAME(TYPENAME, TBName));
        }
        //加载区域
        public JsonResult LoadQY()
        {
            return Json(CommonBLL.LoadQYBySuperName(Session["XZQ"].ToString()));
        }
        //加载商圈
        public JsonResult LoadSQ()
        {
            return Json(CommonBLL.LoadSQByQY(Request["QY"]));
        }
        //加载职位类别信息
        public JsonResult LoadZWLBXX()
        {
            return Json(CommonBLL.LoadZWLBXX(Request["TYPENAME"]));
        }
        //根据CODEVALUE和TYPENAME加载字典表
        public JsonResult LoadByCodeValueAndTypeName()
        {
            return Json(CommonBLL.LoadByCodeValueAndTypeName(Request["CODEVALUE"], Request["TYPENAME"], Request["TBName"]));
        }
        //根据PARENTID加载字典表
        public JsonResult LoadByParentID()
        {
            return Json(CommonBLL.LoadByParentID(Request["ParentID"], Request["TBName"]));
        }
    }
}