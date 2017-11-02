using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HQGSController : BaseController
    {
        public IHQSY_HQGSBLL HQSY_HQGSBLL { get; set; }

        public ActionResult HQSY_HQGS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HQGSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HQGSJBXX HQSY_HQGSjbxx = JsonHelper.ConvertJsonToObject<HQSY_HQGSJBXX>(json);
            HQSY_HQGSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HQGSBLL.SaveHQSY_HQGSJBXX(jcxx, HQSY_HQGSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HQGSJBXX()
        {
            string HQSY_HQGSJBXXID = Request["HQSY_HQGSJBXXID"];
            object result = HQSY_HQGSBLL.LoadHQSY_HQGSJBXX(HQSY_HQGSJBXXID);
            return Json(result);
        }
    }
}