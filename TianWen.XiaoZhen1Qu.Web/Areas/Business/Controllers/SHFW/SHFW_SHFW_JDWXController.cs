using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_JDWXController : BaseController
    {
        public ISHFW_SHFW_JDWXBLL SHFW_SHFW_JDWXBLL { get; set; }

        public ActionResult SHFW_SHFW_JDWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_JDWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_JDWXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_JDWXJBXX SHFW_SHFW_JDWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_JDWXJBXX>(json);
            SHFW_SHFW_JDWXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_JDWXBLL.SaveSHFW_SHFW_JDWXJBXX(jcxx, SHFW_SHFW_JDWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_JDWXJBXX()
        {
            string SHFW_SHFW_JDWXJBXXID = Request["SHFW_SHFW_JDWXJBXXID"];
            object result = SHFW_SHFW_JDWXBLL.LoadSHFW_SHFW_JDWXJBXX(SHFW_SHFW_JDWXJBXXID);
            return Json(result);
        }
    }
}