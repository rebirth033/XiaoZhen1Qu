using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_WXFW_DNWXController : BaseController
    {
        public ISHFW_WXFW_DNWXBLL SHFW_WXFW_DNWXBLL { get; set; }

        public ActionResult SHFW_WXFW_DNWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_WXFW_DNWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_WXFW_DNWXBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_DNWXJBXX>(json);
            SHFW_WXFW_DNWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_DNWXBLL.SaveSHFW_WXFW_DNWXJBXX(jcxx, SHFW_WXFW_DNWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_WXFW_DNWXJBXX()
        {
            string SHFW_WXFW_DNWXJBXXID = Request["SHFW_WXFW_DNWXJBXXID"];
            object result = SHFW_WXFW_DNWXBLL.LoadSHFW_WXFW_DNWXJBXX(SHFW_WXFW_DNWXJBXXID);
            return Json(result);
        }
    }
}