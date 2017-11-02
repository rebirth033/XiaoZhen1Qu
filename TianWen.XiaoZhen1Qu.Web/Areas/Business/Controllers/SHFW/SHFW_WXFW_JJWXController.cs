using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_WXFW_JJWXController : BaseController
    {
        public ISHFW_WXFW_JJWXBLL SHFW_WXFW_JJWXBLL { get; set; }

        public ActionResult SHFW_WXFW_JJWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_WXFW_JJWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_JJWXJBXX SHFW_WXFW_JJWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_JJWXJBXX>(json);
            SHFW_WXFW_JJWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_JJWXBLL.SaveSHFW_WXFW_JJWXJBXX(jcxx, SHFW_WXFW_JJWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_WXFW_JJWXJBXX()
        {
            string SHFW_WXFW_JJWXJBXXID = Request["SHFW_WXFW_JJWXJBXXID"];
            object result = SHFW_WXFW_JJWXBLL.LoadSHFW_WXFW_JJWXJBXX(SHFW_WXFW_JJWXJBXXID);
            return Json(result);
        }
    }
}