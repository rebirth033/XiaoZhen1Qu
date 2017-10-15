using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_SCController : BaseController
    {
        public INLMFY_SCBLL NLMFY_SCBLL { get; set; }

        public ActionResult NLMFY_SC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_SCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_SCBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_SCJBXX NLMFY_SCjbxx = JsonHelper.ConvertJsonToObject<NLMFY_SCJBXX>(json);
            NLMFY_SCjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_SCBLL.SaveNLMFY_SCJBXX(jcxx, NLMFY_SCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_SCJBXX()
        {
            string NLMFY_SCJBXXID = Request["NLMFY_SCJBXXID"];
            object result = NLMFY_SCBLL.LoadNLMFY_SCJBXX(NLMFY_SCJBXXID);
            return Json(result);
        }
    }
}