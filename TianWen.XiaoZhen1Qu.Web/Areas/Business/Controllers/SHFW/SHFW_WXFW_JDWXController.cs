using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_WXFW_JDWXController : BaseController
    {
        public ISHFW_WXFW_JDWXBLL SHFW_WXFW_JDWXBLL { get; set; }

        public ActionResult SHFW_WXFW_JDWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_WXFW_JDWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_WXFW_JDWXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_WXFW_JDWXJBXX SHFW_WXFW_JDWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_JDWXJBXX>(json);
            SHFW_WXFW_JDWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_JDWXBLL.SaveSHFW_WXFW_JDWXJBXX(jcxx, SHFW_WXFW_JDWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_WXFW_JDWXJBXX()
        {
            string SHFW_WXFW_JDWXJBXXID = Request["SHFW_WXFW_JDWXJBXXID"];
            object result = SHFW_WXFW_JDWXBLL.LoadSHFW_WXFW_JDWXJBXX(SHFW_WXFW_JDWXJBXXID);
            return Json(result);
        }
    }
}