using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_QCWXBYController : BaseController
    {
        public ISHFW_CLFW_QCWXBYBLL SHFW_CLFW_QCWXBYBLL { get; set; }

        public ActionResult SHFW_CLFW_QCWXBY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCWXBYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_QCWXBYBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_QCWXBYJBXX SHFW_CLFW_QCWXBYjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCWXBYJBXX>(json);
            SHFW_CLFW_QCWXBYjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCWXBYBLL.SaveSHFW_CLFW_QCWXBYJBXX(jcxx, SHFW_CLFW_QCWXBYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_QCWXBYJBXX()
        {
            string SHFW_CLFW_QCWXBYJBXXID = Request["SHFW_CLFW_QCWXBYJBXXID"];
            object result = SHFW_CLFW_QCWXBYBLL.LoadSHFW_CLFW_QCWXBYJBXX(SHFW_CLFW_QCWXBYJBXXID);
            return Json(result);
        }
    }
}