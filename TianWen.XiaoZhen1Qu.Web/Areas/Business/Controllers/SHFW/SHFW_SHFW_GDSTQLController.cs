using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFW_SHFW_GDSTQLController : BaseController
    {
        public ISHFW_SHFW_GDSTQLBLL SHFW_SHFW_GDSTQLBLL { get; set; }

        public ActionResult SHFW_SHFW_GDSTQL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SHFW_SHFW_GDSTQLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SHFW_SHFW_GDSTQLBLL.GetLBQCByLBID(jcxx.LBID);
            SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_GDSTQLJBXX>(json);
            SHFW_SHFW_GDSTQLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_GDSTQLBLL.SaveSHFW_SHFW_GDSTQLJBXX(jcxx, SHFW_SHFW_GDSTQLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_SHFW_GDSTQLJBXX()
        {
            string SHFW_SHFW_GDSTQLJBXXID = Request["SHFW_SHFW_GDSTQLJBXXID"];
            object result = SHFW_SHFW_GDSTQLBLL.LoadSHFW_SHFW_GDSTQLJBXX(SHFW_SHFW_GDSTQLJBXXID);
            return Json(result);
        }
    }
}