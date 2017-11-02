using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_SJSM_PBDNController : BaseController
    {
        public IES_SJSM_PBDNBLL ES_SJSM_PBDNBLL { get; set; }

        public ActionResult ES_SJSM_PBDN()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_SJSM_PBDNBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_PBDNJBXX ES_SJSM_PBDNjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_PBDNJBXX>(json);
            ES_SJSM_PBDNjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_PBDNBLL.SaveES_SJSM_PBDNJBXX(jcxx, ES_SJSM_PBDNjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_SJSM_PBDNJBXX()
        {
            string ES_SJSM_PBDNJBXXID = Request["ES_SJSM_PBDNJBXXID"];
            object result = ES_SJSM_PBDNBLL.LoadES_SJSM_PBDNJBXX(ES_SJSM_PBDNJBXXID);
            return Json(result);
        }
    }
}