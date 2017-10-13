using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_ZBSSController : BaseController
    {
        public IHQSY_ZBSSBLL HQSY_ZBSSBLL { get; set; }

        public ActionResult HQSY_ZBSS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_ZBSSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_ZBSSBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_ZBSSJBXX HQSY_ZBSSjbxx = JsonHelper.ConvertJsonToObject<HQSY_ZBSSJBXX>(json);
            HQSY_ZBSSjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_ZBSSBLL.SaveHQSY_ZBSSJBXX(jcxx, HQSY_ZBSSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_ZBSSJBXX()
        {
            string HQSY_ZBSSJBXXID = Request["HQSY_ZBSSJBXXID"];
            object result = HQSY_ZBSSBLL.LoadHQSY_ZBSSJBXX(HQSY_ZBSSJBXXID);
            return Json(result);
        }
    }
}