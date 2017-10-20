using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_CZZXController : BaseController
    {
        public IHQSY_CZZXBLL HQSY_CZZXBLL { get; set; }

        public ActionResult HQSY_CZZX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_CZZXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_CZZXBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_CZZXJBXX HQSY_CZZXjbxx = JsonHelper.ConvertJsonToObject<HQSY_CZZXJBXX>(json);
            HQSY_CZZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_CZZXBLL.SaveHQSY_CZZXJBXX(jcxx, HQSY_CZZXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_CZZXJBXX()
        {
            string HQSY_CZZXJBXXID = Request["HQSY_CZZXJBXXID"];
            object result = HQSY_CZZXBLL.LoadHQSY_CZZXJBXX(HQSY_CZZXJBXXID);
            return Json(result);
        }
    }
}