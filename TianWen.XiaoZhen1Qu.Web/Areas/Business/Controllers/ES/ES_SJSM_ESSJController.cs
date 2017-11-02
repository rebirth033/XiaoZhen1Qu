using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_SJSM_ESSJController : BaseController
    {
        public IES_SJSM_ESSJBLL ES_SJSM_ESSJBLL { get; set; }

        public ActionResult ES_SJSM_ESSJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_SJSM_ESSJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_ESSJJBXX ES_SJSM_ESSJjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_ESSJJBXX>(json);
            ES_SJSM_ESSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_ESSJBLL.SaveES_SJSM_ESSJJBXX(jcxx, ES_SJSM_ESSJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_SJSM_ESSJJBXX()
        {
            string ES_SJSM_ESSJJBXXID = Request["ES_SJSM_ESSJJBXXID"];
            object result = ES_SJSM_ESSJBLL.LoadES_SJSM_ESSJJBXX(ES_SJSM_ESSJJBXXID);
            return Json(result);
        }
    }
}