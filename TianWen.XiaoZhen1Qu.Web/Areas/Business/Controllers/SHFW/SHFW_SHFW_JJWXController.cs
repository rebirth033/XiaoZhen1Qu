using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_JJWXController : BaseController
    {
        public ISHFW_SHFW_JJWXBLL SHFW_SHFW_JJWXBLL { get; set; }

        public ActionResult SHFW_SHFW_JJWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_JJWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_JJWXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_JJWXJBXX SHFW_SHFW_JJWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_JJWXJBXX>(json);
            SHFW_SHFW_JJWXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_JJWXBLL.SaveSHFW_SHFW_JJWXJBXX(jcxx, SHFW_SHFW_JJWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_JJWXJBXX()
        {
            string SHFW_SHFW_JJWXJBXXID = Request["SHFW_SHFW_JJWXJBXXID"];
            object result = SHFW_SHFW_JJWXBLL.LoadSHFW_SHFW_JJWXJBXX(SHFW_SHFW_JJWXJBXXID);
            return Json(result);
        }
    }
}