using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_CLFW_QCPLController : BaseController
    {
        public ISHFW_CLFW_QCPLBLL SHFW_CLFW_QCPLBLL { get; set; }

        public ActionResult SHFW_CLFW_QCPL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCPLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_CLFW_QCPLBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCPLJBXX>(json);
            SHFW_CLFW_QCPLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCPLBLL.SaveSHFW_CLFW_QCPLJBXX(jcxx, SHFW_CLFW_QCPLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_QCPLJBXX()
        {
            string SHFW_CLFW_QCPLJBXXID = Request["SHFW_CLFW_QCPLJBXXID"];
            object result = SHFW_CLFW_QCPLBLL.LoadSHFW_CLFW_QCPLJBXX(SHFW_CLFW_QCPLJBXXID);
            return Json(result);
        }
    }
}