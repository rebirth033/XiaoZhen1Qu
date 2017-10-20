using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HSSYController : BaseController
    {
        public IHQSY_HSSYBLL HQSY_HSSYBLL { get; set; }

        public ActionResult HQSY_HSSY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HSSYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_HSSYBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_HSSYJBXX HQSY_HSSYjbxx = JsonHelper.ConvertJsonToObject<HQSY_HSSYJBXX>(json);
            HQSY_HSSYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HSSYBLL.SaveHQSY_HSSYJBXX(jcxx, HQSY_HSSYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HSSYJBXX()
        {
            string HQSY_HSSYJBXXID = Request["HQSY_HSSYJBXXID"];
            object result = HQSY_HSSYBLL.LoadHQSY_HSSYJBXX(HQSY_HSSYJBXXID);
            return Json(result);
        }
    }
}