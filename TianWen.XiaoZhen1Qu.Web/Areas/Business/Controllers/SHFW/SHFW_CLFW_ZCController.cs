using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_ZCController : BaseController
    {
        public ISHFW_CLFW_ZCBLL SHFW_CLFW_ZCBLL { get; set; }

        public ActionResult SHFW_CLFW_ZC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_ZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_ZCBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_ZCJBXX SHFW_CLFW_ZCjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_ZCJBXX>(json);
            SHFW_CLFW_ZCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_ZCBLL.SaveSHFW_CLFW_ZCJBXX(jcxx, SHFW_CLFW_ZCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_ZCJBXX()
        {
            string SHFW_CLFW_ZCJBXXID = Request["SHFW_CLFW_ZCJBXXID"];
            object result = SHFW_CLFW_ZCBLL.LoadSHFW_CLFW_ZCJBXX(SHFW_CLFW_ZCJBXXID);
            return Json(result);
        }
    }
}