using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_QTES_CRYPController : BaseController
    {
        public IES_QTES_CRYPBLL ES_QTES_CRYPBLL { get; set; }

        public ActionResult ES_QTES_CRYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_QTES_CRYPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_QTES_CRYPJBXX ES_QTES_CRYPJBXX = JsonHelper.ConvertJsonToObject<ES_QTES_CRYPJBXX>(json);
            ES_QTES_CRYPJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_QTES_CRYPBLL.SaveES_QTES_CRYPJBXX(jcxx, ES_QTES_CRYPJBXX, photos);
            return Json(result);
        }

        public JsonResult LoadES_QTES_CRYPJBXX()
        {
            string ES_QTES_CRYPJBXXID = Request["ES_QTES_CRYPJBXXID"];
            object result = ES_QTES_CRYPBLL.LoadES_QTES_CRYPJBXX(ES_QTES_CRYPJBXXID);
            return Json(result);
        }
    }
}