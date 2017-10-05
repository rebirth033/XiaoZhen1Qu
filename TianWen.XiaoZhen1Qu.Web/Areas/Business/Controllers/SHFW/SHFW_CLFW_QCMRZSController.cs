using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_QCMRZSController : BaseController
    {
        public ISHFW_CLFW_QCMRZSBLL SHFW_CLFW_QCMRZSBLL { get; set; }

        public ActionResult SHFW_CLFW_QCMRZS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCMRZSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_QCMRZSBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCMRZSJBXX>(json);
            SHFW_CLFW_QCMRZSjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCMRZSBLL.SaveSHFW_CLFW_QCMRZSJBXX(jcxx, SHFW_CLFW_QCMRZSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_QCMRZSJBXX()
        {
            string SHFW_CLFW_QCMRZSJBXXID = Request["SHFW_CLFW_QCMRZSJBXXID"];
            object result = SHFW_CLFW_QCMRZSBLL.LoadSHFW_CLFW_QCMRZSJBXX(SHFW_CLFW_QCMRZSJBXXID);
            return Json(result);
        }
    }
}