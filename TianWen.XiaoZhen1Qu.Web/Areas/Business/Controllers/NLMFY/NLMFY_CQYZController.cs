using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_CQYZController : BaseController
    {
        public INLMFY_CQYZBLL NLMFY_CQYZBLL { get; set; }

        public ActionResult NLMFY_CQYZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_CQYZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_CQYZBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_CQYZJBXX NLMFY_CQYZjbxx = JsonHelper.ConvertJsonToObject<NLMFY_CQYZJBXX>(json);
            NLMFY_CQYZjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_CQYZBLL.SaveNLMFY_CQYZJBXX(jcxx, NLMFY_CQYZjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_CQYZJBXX()
        {
            string NLMFY_CQYZJBXXID = Request["NLMFY_CQYZJBXXID"];
            object result = NLMFY_CQYZBLL.LoadNLMFY_CQYZJBXX(NLMFY_CQYZJBXXID);
            return Json(result);
        }
    }
}