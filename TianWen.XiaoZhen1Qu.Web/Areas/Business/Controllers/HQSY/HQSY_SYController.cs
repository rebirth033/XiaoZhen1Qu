using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_SYController : BaseController
    {
        public IHQSY_SYBLL HQSY_SYBLL { get; set; }

        public ActionResult HQSY_SY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_SYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_SYBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_SYJBXX HQSY_SYjbxx = JsonHelper.ConvertJsonToObject<HQSY_SYJBXX>(json);
            HQSY_SYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_SYBLL.SaveHQSY_SYJBXX(jcxx, HQSY_SYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_SYJBXX()
        {
            string HQSY_SYJBXXID = Request["HQSY_SYJBXXID"];
            object result = HQSY_SYBLL.LoadHQSY_SYJBXX(HQSY_SYJBXXID);
            return Json(result);
        }
    }
}