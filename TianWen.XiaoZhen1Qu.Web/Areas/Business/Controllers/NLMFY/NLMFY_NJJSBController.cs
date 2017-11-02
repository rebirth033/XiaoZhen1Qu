using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_NJJSBController : BaseController
    {
        public INLMFY_NJJSBBLL NLMFY_NJJSBBLL { get; set; }

        public ActionResult NLMFY_NJJSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_NJJSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NJJSBJBXX NLMFY_NJJSBjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NJJSBJBXX>(json);
            NLMFY_NJJSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_NJJSBBLL.SaveNLMFY_NJJSBJBXX(jcxx, NLMFY_NJJSBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_NJJSBJBXX()
        {
            string NLMFY_NJJSBJBXXID = Request["NLMFY_NJJSBJBXXID"];
            object result = NLMFY_NJJSBBLL.LoadNLMFY_NJJSBJBXX(NLMFY_NJJSBJBXXID);
            return Json(result);
        }
    }
}