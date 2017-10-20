using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_DJSJWPController : BaseController
    {
        public ISHFW_CLFW_DJSJWPBLL SHFW_CLFW_DJSJWPBLL { get; set; }

        public ActionResult SHFW_CLFW_DJSJWP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_DJSJWPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_DJSJWPBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_DJSJWPJBXX SHFW_CLFW_DJSJWPjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_DJSJWPJBXX>(json);
            SHFW_CLFW_DJSJWPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_DJSJWPBLL.SaveSHFW_CLFW_DJSJWPJBXX(jcxx, SHFW_CLFW_DJSJWPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_DJSJWPJBXX()
        {
            string SHFW_CLFW_DJSJWPJBXXID = Request["SHFW_CLFW_DJSJWPJBXXID"];
            object result = SHFW_CLFW_DJSJWPBLL.LoadSHFW_CLFW_DJSJWPJBXX(SHFW_CLFW_DJSJWPJBXXID);
            return Json(result);
        }
    }
}