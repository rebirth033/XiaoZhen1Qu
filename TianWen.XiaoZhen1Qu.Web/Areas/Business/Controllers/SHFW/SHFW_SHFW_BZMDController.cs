using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_BZMDController : BaseController
    {
        public ISHFW_SHFW_BZMDBLL SHFW_SHFW_BZMDBLL { get; set; }

        public ActionResult SHFW_SHFW_BZMD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BZMDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_BZMDBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BZMDJBXX>(json);
            SHFW_SHFW_BZMDjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BZMDBLL.SaveSHFW_SHFW_BZMDJBXX(jcxx, SHFW_SHFW_BZMDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_BZMDJBXX()
        {
            string SHFW_SHFW_BZMDJBXXID = Request["SHFW_SHFW_BZMDJBXXID"];
            object result = SHFW_SHFW_BZMDBLL.LoadSHFW_SHFW_BZMDJBXX(SHFW_SHFW_BZMDJBXXID);
            return Json(result);
        }
    }
}