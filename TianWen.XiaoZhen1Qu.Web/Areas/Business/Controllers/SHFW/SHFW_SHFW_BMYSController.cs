using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_BMYSController : BaseController
    {
        public ISHFW_SHFW_BMYSBLL SHFW_SHFW_BMYSBLL { get; set; }

        public ActionResult SHFW_SHFW_BMYS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BMYSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_BMYSBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_BMYSJBXX SHFW_SHFW_BMYSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BMYSJBXX>(json);
            SHFW_SHFW_BMYSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BMYSBLL.SaveSHFW_SHFW_BMYSJBXX(jcxx, SHFW_SHFW_BMYSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_BMYSJBXX()
        {
            string SHFW_SHFW_BMYSJBXXID = Request["SHFW_SHFW_BMYSJBXXID"];
            object result = SHFW_SHFW_BMYSBLL.LoadSHFW_SHFW_BMYSJBXX(SHFW_SHFW_BMYSJBXXID);
            return Json(result);
        }
    }
}