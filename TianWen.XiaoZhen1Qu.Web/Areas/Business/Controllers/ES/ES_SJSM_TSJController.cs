using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_SJSM_TSJController : BaseController
    {
        public IES_SJSM_TSJBLL ES_SJSM_TSJBLL { get; set; }

        public ActionResult ES_SJSM_TSJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_SJSM_TSJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_SJSM_TSJBLL.GetLBQCByLBID(jcxx.LBID);
            ES_SJSM_TSJJBXX ES_SJSM_TSJjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_TSJJBXX>(json);
            ES_SJSM_TSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_TSJBLL.SaveES_SJSM_TSJJBXX(jcxx, ES_SJSM_TSJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_SJSM_TSJJBXX()
        {
            string ES_SJSM_TSJJBXXID = Request["ES_SJSM_TSJJBXXID"];
            object result = ES_SJSM_TSJBLL.LoadES_SJSM_TSJJBXX(ES_SJSM_TSJJBXXID);
            return Json(result);
        }
    }
}