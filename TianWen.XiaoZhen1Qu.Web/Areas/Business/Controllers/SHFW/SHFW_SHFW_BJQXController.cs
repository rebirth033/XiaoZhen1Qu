using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_BJQXController : BaseController
    {
        public ISHFW_SHFW_BJQXBLL SHFW_SHFW_BJQXBLL { get; set; }

        public ActionResult SHFW_SHFW_BJQX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BJQXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_BJQXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_BJQXJBXX SHFW_SHFW_BJQXjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BJQXJBXX>(json);
            SHFW_SHFW_BJQXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BJQXBLL.SaveSHFW_SHFW_BJQXJBXX(jcxx, SHFW_SHFW_BJQXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_BJQXJBXX()
        {
            string SHFW_SHFW_BJQXJBXXID = Request["SHFW_SHFW_BJQXJBXXID"];
            object result = SHFW_SHFW_BJQXBLL.LoadSHFW_SHFW_BJQXJBXX(SHFW_SHFW_BJQXJBXXID);
            return Json(result);
        }
    }
}