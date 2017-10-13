using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HSLFController : BaseController
    {
        public IHQSY_HSLFBLL HQSY_HSLFBLL { get; set; }

        public ActionResult HQSY_HSLF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HSLFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_HSLFBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_HSLFJBXX HQSY_HSLFjbxx = JsonHelper.ConvertJsonToObject<HQSY_HSLFJBXX>(json);
            HQSY_HSLFjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HSLFBLL.SaveHQSY_HSLFJBXX(jcxx, HQSY_HSLFjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HSLFJBXX()
        {
            string HQSY_HSLFJBXXID = Request["HQSY_HSLFJBXXID"];
            object result = HQSY_HSLFBLL.LoadHQSY_HSLFJBXX(HQSY_HSLFJBXXID);
            return Json(result);
        }
    }
}