using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_QMFSSMController : BaseController
    {
        public ISHFW_SHFW_QMFSSMBLL SHFW_SHFW_QMFSSMBLL { get; set; }

        public ActionResult SHFW_SHFW_QMFSSM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_QMFSSMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_QMFSSMBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_QMFSSMJBXX SHFW_SHFW_QMFSSMjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_QMFSSMJBXX>(json);
            SHFW_SHFW_QMFSSMjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_QMFSSMBLL.SaveSHFW_SHFW_QMFSSMJBXX(jcxx, SHFW_SHFW_QMFSSMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_QMFSSMJBXX()
        {
            string SHFW_SHFW_QMFSSMJBXXID = Request["SHFW_SHFW_QMFSSMJBXXID"];
            object result = SHFW_SHFW_QMFSSMBLL.LoadSHFW_SHFW_QMFSSMJBXX(SHFW_SHFW_QMFSSMJBXXID);
            return Json(result);
        }
    }
}