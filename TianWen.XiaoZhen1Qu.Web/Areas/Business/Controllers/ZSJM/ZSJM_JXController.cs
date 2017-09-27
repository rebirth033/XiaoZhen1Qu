using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_JXController : BaseController
    {
        public IZSJM_JXBLL ZSJM_JXBLL { get; set; }

        public ActionResult ZSJM_JX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_JXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ZSJM_JXBLL.GetLBQCByLBID(jcxx.LBID);
            ZSJM_JXJBXX ZSJM_JXjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JXJBXX>(json);
            ZSJM_JXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JXBLL.SaveZSJM_JXJBXX(jcxx, ZSJM_JXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_JXJBXX()
        {
            string ZSJM_JXJBXXID = Request["ZSJM_JXJBXXID"];
            object result = ZSJM_JXBLL.LoadZSJM_JXJBXX(ZSJM_JXJBXXID);
            return Json(result);
        }
    }
}