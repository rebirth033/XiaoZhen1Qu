using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_GHSPNJYCController : BaseController
    {
        public ISHFW_CLFW_GHSPNJYCBLL SHFW_CLFW_GHSPNJYCBLL { get; set; }

        public ActionResult SHFW_CLFW_GHSPNJYC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_GHSPNJYCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_GHSPNJYCBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_GHSPNJYCJBXX>(json);
            SHFW_CLFW_GHSPNJYCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_GHSPNJYCBLL.SaveSHFW_CLFW_GHSPNJYCJBXX(jcxx, SHFW_CLFW_GHSPNJYCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_GHSPNJYCJBXX()
        {
            string SHFW_CLFW_GHSPNJYCJBXXID = Request["SHFW_CLFW_GHSPNJYCJBXXID"];
            object result = SHFW_CLFW_GHSPNJYCBLL.LoadSHFW_CLFW_GHSPNJYCJBXX(SHFW_CLFW_GHSPNJYCJBXXID);
            return Json(result);
        }
    }
}