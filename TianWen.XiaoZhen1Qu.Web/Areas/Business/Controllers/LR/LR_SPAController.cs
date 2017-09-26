using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_SPAController : BaseController
    {
        public ILR_SPABLL LR_SPABLL { get; set; }

        public ActionResult LR_SPA()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_SPABLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_SPABLL.GetLBQCByLBID(jcxx.LBID);
            LR_SPAJBXX LR_SPAjbxx = JsonHelper.ConvertJsonToObject<LR_SPAJBXX>(json);
            LR_SPAjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_SPABLL.SaveLR_SPAJBXX(jcxx, LR_SPAjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_SPAJBXX()
        {
            string LR_SPAJBXXID = Request["LR_SPAJBXXID"];
            object result = LR_SPABLL.LoadLR_SPAJBXX(LR_SPAJBXXID);
            return Json(result);
        }
    }
}