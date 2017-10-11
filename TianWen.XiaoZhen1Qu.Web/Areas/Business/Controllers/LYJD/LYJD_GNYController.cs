using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_GNYController : BaseController
    {
        public ILYJD_GNYBLL LYJD_GNYBLL { get; set; }

        public ActionResult LYJD_GNY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_GNYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string xlts = Request["XLTS"];
            string xcap = Request["XCAP"];
            string ydxz = Request["YDXZ"];
            string fybh = Request["FYBH"];
            string zfxm = Request["ZFXM"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + LYJD_GNYBLL.GetLBQCByLBID(jcxx.LBID);
            LYJD_GNYJBXX LYJD_GNYjbxx = JsonHelper.ConvertJsonToObject<LYJD_GNYJBXX>(json);
            LYJD_GNYjbxx.XLTS = xlts;
            LYJD_GNYjbxx.XCAP = xcap;
            LYJD_GNYjbxx.YDXZ = ydxz;
            LYJD_GNYjbxx.FYBH = fybh;
            LYJD_GNYjbxx.ZFXM = zfxm;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_GNYBLL.SaveLYJD_GNYJBXX(jcxx, LYJD_GNYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_GNYJBXX()
        {
            string LYJD_GNYJBXXID = Request["LYJD_GNYJBXXID"];
            object result = LYJD_GNYBLL.LoadLYJD_GNYJBXX(LYJD_GNYJBXXID);
            return Json(result);
        }
    }
}