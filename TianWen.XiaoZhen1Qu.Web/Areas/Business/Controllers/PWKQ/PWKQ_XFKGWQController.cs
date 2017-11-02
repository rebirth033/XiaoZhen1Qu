using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PWKQ_XFKGWQController : BaseController
    {
        public IPWKQ_XFKGWQBLL PWKQ_XFKGWQBLL { get; set; }

        public ActionResult PWKQ_XFKGWQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PWKQ_XFKGWQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_XFKGWQJBXX PWKQ_XFKGWQjbxx = JsonHelper.ConvertJsonToObject<PWKQ_XFKGWQJBXX>(json);
            PWKQ_XFKGWQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_XFKGWQBLL.SavePWKQ_XFKGWQJBXX(jcxx, PWKQ_XFKGWQjbxx);
            return Json(result);
        }

        public JsonResult LoadPWKQ_XFKGWQJBXX()
        {
            string PWKQ_XFKGWQJBXXID = Request["PWKQ_XFKGWQJBXXID"];
            object result = PWKQ_XFKGWQBLL.LoadPWKQ_XFKGWQJBXX(PWKQ_XFKGWQJBXXID);
            return Json(result);
        }
    }
}