using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HLGPController : BaseController
    {
        public IHQSY_HLGPBLL HQSY_HLGPBLL { get; set; }

        public ActionResult HQSY_HLGP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HLGPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_HLGPBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_HLGPJBXX HQSY_HLGPjbxx = JsonHelper.ConvertJsonToObject<HQSY_HLGPJBXX>(json);
            HQSY_HLGPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HLGPBLL.SaveHQSY_HLGPJBXX(jcxx, HQSY_HLGPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HLGPJBXX()
        {
            string HQSY_HLGPJBXXID = Request["HQSY_HLGPJBXXID"];
            object result = HQSY_HLGPBLL.LoadHQSY_HLGPJBXX(HQSY_HLGPJBXXID);
            return Json(result);
        }
    }
}