using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_DNWXController : BaseController
    {
        public ISHFW_SHFW_DNWXBLL SHFW_SHFW_DNWXBLL { get; set; }

        public ActionResult SHFW_SHFW_DNWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_DNWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_DNWXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_DNWXJBXX SHFW_SHFW_DNWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_DNWXJBXX>(json);
            SHFW_SHFW_DNWXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_DNWXBLL.SaveSHFW_SHFW_DNWXJBXX(jcxx, SHFW_SHFW_DNWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_DNWXJBXX()
        {
            string SHFW_SHFW_DNWXJBXXID = Request["SHFW_SHFW_DNWXJBXXID"];
            object result = SHFW_SHFW_DNWXBLL.LoadSHFW_SHFW_DNWXJBXX(SHFW_SHFW_DNWXJBXXID);
            return Json(result);
        }
    }
}