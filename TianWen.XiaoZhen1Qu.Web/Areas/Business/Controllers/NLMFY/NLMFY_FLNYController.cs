using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_FLNYController : BaseController
    {
        public INLMFY_FLNYBLL NLMFY_FLNYBLL { get; set; }

        public ActionResult NLMFY_FLNY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_FLNYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_FLNYBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_FLNYJBXX NLMFY_FLNYjbxx = JsonHelper.ConvertJsonToObject<NLMFY_FLNYJBXX>(json);
            NLMFY_FLNYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_FLNYBLL.SaveNLMFY_FLNYJBXX(jcxx, NLMFY_FLNYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_FLNYJBXX()
        {
            string NLMFY_FLNYJBXXID = Request["NLMFY_FLNYJBXXID"];
            object result = NLMFY_FLNYBLL.LoadNLMFY_FLNYJBXX(NLMFY_FLNYJBXXID);
            return Json(result);
        }
    }
}