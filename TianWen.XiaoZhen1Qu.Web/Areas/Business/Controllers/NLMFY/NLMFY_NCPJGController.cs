using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_NCPJGController : BaseController
    {
        public INLMFY_NCPJGBLL NLMFY_NCPJGBLL { get; set; }

        public ActionResult NLMFY_NCPJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_NCPJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NCPJGJBXX NLMFY_NCPJGjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NCPJGJBXX>(json);
            NLMFY_NCPJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_NCPJGBLL.SaveNLMFY_NCPJGJBXX(jcxx, NLMFY_NCPJGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_NCPJGJBXX()
        {
            string NLMFY_NCPJGJBXXID = Request["NLMFY_NCPJGJBXXID"];
            object result = NLMFY_NCPJGBLL.LoadNLMFY_NCPJGJBXX(NLMFY_NCPJGJBXXID);
            return Json(result);
        }
    }
}