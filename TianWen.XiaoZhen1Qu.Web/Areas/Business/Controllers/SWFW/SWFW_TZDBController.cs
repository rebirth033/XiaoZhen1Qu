using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_TZDBController : BaseController
    {
        public ISWFW_TZDBBLL SWFW_TZDBBLL { get; set; }

        public ActionResult SWFW_TZDB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_TZDBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_TZDBBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_TZDBJBXX SWFW_TZDBjbxx = JsonHelper.ConvertJsonToObject<SWFW_TZDBJBXX>(json);
            SWFW_TZDBjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_TZDBBLL.SaveSWFW_TZDBJBXX(jcxx, SWFW_TZDBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_TZDBJBXX()
        {
            string SWFW_TZDBJBXXID = Request["SWFW_TZDBJBXXID"];
            object result = SWFW_TZDBBLL.LoadSWFW_TZDBJBXX(SWFW_TZDBJBXXID);
            return Json(result);
        }
    }
}