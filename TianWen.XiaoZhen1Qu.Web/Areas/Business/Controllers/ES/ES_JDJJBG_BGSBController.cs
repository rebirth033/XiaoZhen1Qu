using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_JDJJBG_BGSBController : BaseController
    {
        public IES_JDJJBG_BGSBBLL ES_JDJJBG_BGSBBLL { get; set; }

        public ActionResult ES_JDJJBG_BGSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_JDJJBG_BGSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_JDJJBG_BGSBBLL.GetLBQCByLBID(jcxx.LBID);
            ES_JDJJBG_BGSBJBXX ES_JDJJBG_BGSBjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_BGSBJBXX>(json);
            ES_JDJJBG_BGSBjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_BGSBBLL.SaveES_JDJJBG_BGSBJBXX(jcxx, ES_JDJJBG_BGSBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_JDJJBG_BGSBJBXX()
        {
            string ES_JDJJBG_BGSBJBXXID = Request["ES_JDJJBG_BGSBJBXXID"];
            object result = ES_JDJJBG_BGSBBLL.LoadES_JDJJBG_BGSBJBXX(ES_JDJJBG_BGSBJBXXID);
            return Json(result);
        }
    }
}