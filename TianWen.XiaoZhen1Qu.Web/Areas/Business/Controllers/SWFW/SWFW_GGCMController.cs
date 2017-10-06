using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_GGCMController : BaseController
    {
        public ISWFW_GGCMBLL SWFW_GGCMBLL { get; set; }

        public ActionResult SWFW_GGCM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_GGCMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_GGCMBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_GGCMJBXX SWFW_GGCMjbxx = JsonHelper.ConvertJsonToObject<SWFW_GGCMJBXX>(json);
            SWFW_GGCMjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_GGCMBLL.SaveSWFW_GGCMJBXX(jcxx, SWFW_GGCMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_GGCMJBXX()
        {
            string SWFW_GGCMJBXXID = Request["SWFW_GGCMJBXXID"];
            object result = SWFW_GGCMBLL.LoadSWFW_GGCMJBXX(SWFW_GGCMJBXXID);
            return Json(result);
        }
    }
}