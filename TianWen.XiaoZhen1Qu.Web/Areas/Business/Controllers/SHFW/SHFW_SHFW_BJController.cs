using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_BJController : BaseController
    {
        public ISHFW_SHFW_BJBLL SHFW_SHFW_BJBLL { get; set; }

        public ActionResult SHFW_SHFW_BJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_BJBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_BJJBXX SHFW_SHFW_BJjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BJJBXX>(json);
            SHFW_SHFW_BJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BJBLL.SaveSHFW_SHFW_BJJBXX(jcxx, SHFW_SHFW_BJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_BJJBXX()
        {
            string SHFW_SHFW_BJJBXXID = Request["SHFW_SHFW_BJJBXXID"];
            object result = SHFW_SHFW_BJBLL.LoadSHFW_SHFW_BJJBXX(SHFW_SHFW_BJJBXXID);
            return Json(result);
        }
    }
}