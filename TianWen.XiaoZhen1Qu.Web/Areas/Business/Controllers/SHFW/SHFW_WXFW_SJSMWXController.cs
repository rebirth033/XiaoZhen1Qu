using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_WXFW_SJSMWXController : BaseController
    {
        public ISHFW_WXFW_SJSMWXBLL SHFW_WXFW_SJSMWXBLL { get; set; }

        public ActionResult SHFW_WXFW_SJSMWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_WXFW_SJSMWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_WXFW_SJSMWXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_WXFW_SJSMWXJBXX SHFW_WXFW_SJSMWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_SJSMWXJBXX>(json);
            SHFW_WXFW_SJSMWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_SJSMWXBLL.SaveSHFW_WXFW_SJSMWXJBXX(jcxx, SHFW_WXFW_SJSMWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_WXFW_SJSMWXJBXX()
        {
            string SHFW_WXFW_SJSMWXJBXXID = Request["SHFW_WXFW_SJSMWXJBXXID"];
            object result = SHFW_WXFW_SJSMWXBLL.LoadSHFW_WXFW_SJSMWXJBXX(SHFW_WXFW_SJSMWXJBXXID);
            return Json(result);
        }
    }
}