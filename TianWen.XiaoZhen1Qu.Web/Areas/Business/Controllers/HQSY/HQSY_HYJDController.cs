using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HYJDController : BaseController
    {
        public IHQSY_HYJDBLL HQSY_HYJDBLL { get; set; }

        public ActionResult HQSY_HYJD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HYJDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HYJDJBXX HQSY_HYJDjbxx = JsonHelper.ConvertJsonToObject<HQSY_HYJDJBXX>(json);
            HQSY_HYJDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HYJDBLL.SaveHQSY_HYJDJBXX(jcxx, HQSY_HYJDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HYJDJBXX()
        {
            string HQSY_HYJDJBXXID = Request["HQSY_HYJDJBXXID"];
            object result = HQSY_HYJDBLL.LoadHQSY_HYJDJBXX(HQSY_HYJDJBXXID);
            return Json(result);
        }
    }
}