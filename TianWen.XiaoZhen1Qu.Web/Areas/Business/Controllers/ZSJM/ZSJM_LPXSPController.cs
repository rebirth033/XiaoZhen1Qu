using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_LPXSPController : BaseController
    {
        public IZSJM_LPXSPBLL ZSJM_LPXSPBLL { get; set; }

        public ActionResult ZSJM_LPXSP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_LPXSPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ZSJM_LPXSPBLL.GetLBQCByLBID(jcxx.LBID);
            ZSJM_LPXSPJBXX ZSJM_LPXSPjbxx = JsonHelper.ConvertJsonToObject<ZSJM_LPXSPJBXX>(json);
            ZSJM_LPXSPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_LPXSPBLL.SaveZSJM_LPXSPJBXX(jcxx, ZSJM_LPXSPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_LPXSPJBXX()
        {
            string ZSJM_LPXSPJBXXID = Request["ZSJM_LPXSPJBXXID"];
            object result = ZSJM_LPXSPBLL.LoadZSJM_LPXSPJBXX(ZSJM_LPXSPJBXXID);
            return Json(result);
        }
    }
}