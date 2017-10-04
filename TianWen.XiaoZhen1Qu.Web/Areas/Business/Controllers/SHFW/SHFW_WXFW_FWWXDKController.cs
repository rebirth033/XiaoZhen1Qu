using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_WXFW_FWWXDKController : BaseController
    {
        public ISHFW_WXFW_FWWXDKBLL SHFW_WXFW_FWWXDKBLL { get; set; }

        public ActionResult SHFW_WXFW_FWWXDK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_WXFW_FWWXDKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_WXFW_FWWXDKBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_FWWXDKJBXX>(json);
            SHFW_WXFW_FWWXDKjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_FWWXDKBLL.SaveSHFW_WXFW_FWWXDKJBXX(jcxx, SHFW_WXFW_FWWXDKjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_WXFW_FWWXDKJBXX()
        {
            string SHFW_WXFW_FWWXDKJBXXID = Request["SHFW_WXFW_FWWXDKJBXXID"];
            object result = SHFW_WXFW_FWWXDKBLL.LoadSHFW_WXFW_FWWXDKJBXX(SHFW_WXFW_FWWXDKJBXXID);
            return Json(result);
        }
    }
}