using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_JDJJBG_ESJJController : BaseController
    {
        public IES_JDJJBG_ESJJBLL ES_JDJJBG_ESJJBLL { get; set; }

        public ActionResult ES_JDJJBG_ESJJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_JDJJBG_ESJJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_JDJJBG_ESJJBLL.GetLBQCByLBID(jcxx.LBID);
            ES_JDJJBG_ESJJJBXX ES_JDJJBG_ESJJjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_ESJJJBXX>(json);
            ES_JDJJBG_ESJJjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_ESJJBLL.SaveES_JDJJBG_ESJJJBXX(jcxx, ES_JDJJBG_ESJJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_JDJJBG_ESJJJBXX()
        {
            string ES_JDJJBG_ESJJJBXXID = Request["ES_JDJJBG_ESJJJBXXID"];
            object result = ES_JDJJBG_ESJJBLL.LoadES_JDJJBG_ESJJJBXX(ES_JDJJBG_ESJJJBXXID);
            return Json(result);
        }
    }
}