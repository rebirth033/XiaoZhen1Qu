using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_KSHSXSController : BaseController
    {
        public ISHFW_SHFW_KSHSXSBLL SHFW_SHFW_KSHSXSBLL { get; set; }

        public ActionResult SHFW_SHFW_KSHSXS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_KSHSXSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_KSHSXSBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_KSHSXSJBXX SHFW_SHFW_KSHSXSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_KSHSXSJBXX>(json);
            SHFW_SHFW_KSHSXSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_KSHSXSBLL.SaveSHFW_SHFW_KSHSXSJBXX(jcxx, SHFW_SHFW_KSHSXSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_KSHSXSJBXX()
        {
            string SHFW_SHFW_KSHSXSJBXXID = Request["SHFW_SHFW_KSHSXSJBXXID"];
            object result = SHFW_SHFW_KSHSXSBLL.LoadSHFW_SHFW_KSHSXSJBXX(SHFW_SHFW_KSHSXSJBXXID);
            return Json(result);
        }
    }
}