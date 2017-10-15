using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_SLSYController : BaseController
    {
        public INLMFY_SLSYBLL NLMFY_SLSYBLL { get; set; }

        public ActionResult NLMFY_SLSY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_SLSYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_SLSYBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_SLSYJBXX NLMFY_SLSYjbxx = JsonHelper.ConvertJsonToObject<NLMFY_SLSYJBXX>(json);
            NLMFY_SLSYjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_SLSYBLL.SaveNLMFY_SLSYJBXX(jcxx, NLMFY_SLSYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_SLSYJBXX()
        {
            string NLMFY_SLSYJBXXID = Request["NLMFY_SLSYJBXXID"];
            object result = NLMFY_SLSYBLL.LoadNLMFY_SLSYJBXX(NLMFY_SLSYJBXXID);
            return Json(result);
        }
    }
}