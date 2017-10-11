using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_CJYController : BaseController
    {
        public ILYJD_CJYBLL LYJD_CJYBLL { get; set; }

        public ActionResult LYJD_CJY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_CJYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LYJD_CJYBLL.GetLBQCByLBID(jcxx.LBID);
            LYJD_CJYJBXX LYJD_CJYjbxx = JsonHelper.ConvertJsonToObject<LYJD_CJYJBXX>(json);
            LYJD_CJYjbxx.XLTS = xlts;
            LYJD_CJYjbxx.XCAP = xcap;
            LYJD_CJYjbxx.YDXZ = ydxz;
            LYJD_CJYjbxx.FYBH = fybh;
            LYJD_CJYjbxx.ZFXM = zfxm;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_CJYBLL.SaveLYJD_CJYJBXX(jcxx, LYJD_CJYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_CJYJBXX()
        {
            string LYJD_CJYJBXXID = Request["LYJD_CJYJBXXID"];
            object result = LYJD_CJYBLL.LoadLYJD_CJYJBXX(LYJD_CJYJBXXID);
            return Json(result);
        }
    }
}