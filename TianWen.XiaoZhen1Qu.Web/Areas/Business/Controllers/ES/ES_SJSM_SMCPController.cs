using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_SJSM_SMCPController : BaseController
    {
        public IES_SJSM_SMCPBLL ES_SJSM_SMCPBLL { get; set; }

        public ActionResult ES_SJSM_SMCP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_SJSM_SMCPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_SMCPJBXX ES_SJSM_SMCPjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_SMCPJBXX>(json);
            ES_SJSM_SMCPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_SMCPBLL.SaveES_SJSM_SMCPJBXX(jcxx, ES_SJSM_SMCPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_SJSM_SMCPJBXX()
        {
            string ES_SJSM_SMCPJBXXID = Request["ES_SJSM_SMCPJBXXID"];
            object result = ES_SJSM_SMCPBLL.LoadES_SJSM_SMCPJBXX(ES_SJSM_SMCPJBXXID);
            return Json(result);
        }
    }
}