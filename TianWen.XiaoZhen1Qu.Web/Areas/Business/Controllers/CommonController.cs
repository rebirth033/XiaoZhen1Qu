﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CommonController : BaseController
    {
        public ICommonBLL CommonBLL { get; set; }
        public JsonResult GetIDByJCXXIDAndLBID()
        {
            string LBID = Request["LBID"];
            string JCXXID = Request["JCXXID"];
            object result = CommonBLL.GetIDByJCXXIDAndLBID(JCXXID, LBID);
            return Json(result);
        }

        public JsonResult GetDistrictByGrade()
        {
            string Grade = Request["Grade"];
            object result = CommonBLL.GetDistrictByGrade(Grade);
            return Json(result);
        }

        public JsonResult GetDistrictBySuperCode()
        {
            string SupserCode = Request["SupserCode"];
            object result = CommonBLL.GetDistrictBySuperCode(SupserCode);
            return Json(result);
        }

        public JsonResult LoadCODES()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES(TYPENAME));
        }

        public JsonResult QHXZQ()
        {
            Session["XZQ"] = Request["XZQ"];
            return Json(new { Result = EnResultType.Success });
        }

        public JsonResult LoadQY()
        {
            return Json(CommonBLL.LoadQYBySuperName(Session["XZQ"].ToString()));
        }

        public JsonResult LoadSQ()
        {
            return Json(CommonBLL.LoadSQByQY(Request["QY"]));
        }

        public JsonResult LoadSJXH()
        {
            return Json(CommonBLL.LoadSJXHBySJPP(Request["SJPP"]));
        }
    }
}