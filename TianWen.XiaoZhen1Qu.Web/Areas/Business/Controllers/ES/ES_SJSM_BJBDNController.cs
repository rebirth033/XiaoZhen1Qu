using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_SJSM_BJBDNController : BaseController
    {
        public IES_SJSM_BJBDNBLL ES_SJSM_BJBDNBLL { get; set; }

        public ActionResult ES_SJSM_BJBDN()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_SJSM_BJBDNBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + ES_SJSM_BJBDNBLL.GetLBQCByLBID(jcxx.LBID);
            ES_SJSM_BJBDNJBXX ES_SJSM_BJBDNjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_BJBDNJBXX>(json);
            ES_SJSM_BJBDNjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_BJBDNBLL.SaveES_SJSM_BJBDNJBXX(jcxx, ES_SJSM_BJBDNjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_SJSM_BJBDNJBXX()
        {
            string ES_SJSM_BJBDNJBXXID = Request["ES_SJSM_BJBDNJBXXID"];
            object result = ES_SJSM_BJBDNBLL.LoadES_SJSM_BJBDNJBXX(ES_SJSM_BJBDNJBXXID);
            return Json(result);
        }
    }
}