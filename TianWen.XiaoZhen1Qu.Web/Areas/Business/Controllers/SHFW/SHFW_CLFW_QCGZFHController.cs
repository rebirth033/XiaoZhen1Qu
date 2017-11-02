using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_QCGZFHController : BaseController
    {
        public ISHFW_CLFW_QCGZFHBLL SHFW_CLFW_QCGZFHBLL { get; set; }

        public ActionResult SHFW_CLFW_QCGZFH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCGZFHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCGZFHJBXX>(json);
            SHFW_CLFW_QCGZFHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCGZFHBLL.SaveSHFW_CLFW_QCGZFHJBXX(jcxx, SHFW_CLFW_QCGZFHjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_QCGZFHJBXX()
        {
            string SHFW_CLFW_QCGZFHJBXXID = Request["SHFW_CLFW_QCGZFHJBXXID"];
            object result = SHFW_CLFW_QCGZFHBLL.LoadSHFW_CLFW_QCGZFHJBXX(SHFW_CLFW_QCGZFHJBXXID);
            return Json(result);
        }
    }
}