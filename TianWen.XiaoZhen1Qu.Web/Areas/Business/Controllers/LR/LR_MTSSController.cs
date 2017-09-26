using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_MTSSController : BaseController
    {
        public ILR_MTSSBLL LR_MTSSBLL { get; set; }

        public ActionResult LR_MTSS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_MTSSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_MTSSBLL.GetLBQCByLBID(jcxx.LBID);
            LR_MTSSJBXX LR_MTSSjbxx = JsonHelper.ConvertJsonToObject<LR_MTSSJBXX>(json);
            LR_MTSSjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_MTSSBLL.SaveLR_MTSSJBXX(jcxx, LR_MTSSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_MTSSJBXX()
        {
            string LR_MTSSJBXXID = Request["LR_MTSSJBXXID"];
            object result = LR_MTSSBLL.LoadLR_MTSSJBXX(LR_MTSSJBXXID);
            return Json(result);
        }
    }
}