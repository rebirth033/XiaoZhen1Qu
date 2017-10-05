using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_GSZCController : BaseController
    {
        public ISWFW_GSZCBLL SWFW_GSZCBLL { get; set; }

        public ActionResult SWFW_GSZC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_GSZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_GSZCBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_GSZCJBXX SWFW_GSZCjbxx = JsonHelper.ConvertJsonToObject<SWFW_GSZCJBXX>(json);
            SWFW_GSZCjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_GSZCBLL.SaveSWFW_GSZCJBXX(jcxx, SWFW_GSZCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_GSZCJBXX()
        {
            string SWFW_GSZCJBXXID = Request["SWFW_GSZCJBXXID"];
            object result = SWFW_GSZCBLL.LoadSWFW_GSZCJBXX(SWFW_GSZCJBXXID);
            return Json(result);
        }
    }
}