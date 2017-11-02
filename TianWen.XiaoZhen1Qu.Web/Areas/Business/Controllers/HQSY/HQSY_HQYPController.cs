using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HQYPController : BaseController
    {
        public IHQSY_HQYPBLL HQSY_HQYPBLL { get; set; }

        public ActionResult HQSY_HQYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HQYPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HQYPJBXX HQSY_HQYPjbxx = JsonHelper.ConvertJsonToObject<HQSY_HQYPJBXX>(json);
            HQSY_HQYPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HQYPBLL.SaveHQSY_HQYPJBXX(jcxx, HQSY_HQYPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HQYPJBXX()
        {
            string HQSY_HQYPJBXXID = Request["HQSY_HQYPJBXXID"];
            object result = HQSY_HQYPBLL.LoadHQSY_HQYPJBXX(HQSY_HQYPJBXXID);
            return Json(result);
        }
    }
}