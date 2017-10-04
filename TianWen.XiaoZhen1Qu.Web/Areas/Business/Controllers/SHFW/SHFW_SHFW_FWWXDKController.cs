using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_FWWXDKController : BaseController
    {
        public ISHFW_SHFW_FWWXDKBLL SHFW_SHFW_FWWXDKBLL { get; set; }

        public ActionResult SHFW_SHFW_FWWXDK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_FWWXDKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_FWWXDKBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_FWWXDKJBXX SHFW_SHFW_FWWXDKjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_FWWXDKJBXX>(json);
            SHFW_SHFW_FWWXDKjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_FWWXDKBLL.SaveSHFW_SHFW_FWWXDKJBXX(jcxx, SHFW_SHFW_FWWXDKjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_FWWXDKJBXX()
        {
            string SHFW_SHFW_FWWXDKJBXXID = Request["SHFW_SHFW_FWWXDKJBXXID"];
            object result = SHFW_SHFW_FWWXDKBLL.LoadSHFW_SHFW_FWWXDKJBXX(SHFW_SHFW_FWWXDKJBXXID);
            return Json(result);
        }
    }
}