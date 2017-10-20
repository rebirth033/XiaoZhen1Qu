using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_NZWController : BaseController
    {
        public INLMFY_NZWBLL NLMFY_NZWBLL { get; set; }

        public ActionResult NLMFY_NZW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_NZWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_NZWBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_NZWJBXX NLMFY_NZWjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NZWJBXX>(json);
            NLMFY_NZWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_NZWBLL.SaveNLMFY_NZWJBXX(jcxx, NLMFY_NZWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_NZWJBXX()
        {
            string NLMFY_NZWJBXXID = Request["NLMFY_NZWJBXXID"];
            object result = NLMFY_NZWBLL.LoadNLMFY_NZWJBXX(NLMFY_NZWJBXXID);
            return Json(result);
        }
    }
}