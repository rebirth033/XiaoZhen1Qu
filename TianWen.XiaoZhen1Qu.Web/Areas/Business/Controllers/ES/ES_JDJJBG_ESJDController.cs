using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_JDJJBG_ESJDController : BaseController
    {
        public IES_JDJJBG_ESJDBLL ES_JDJJBG_ESJDBLL { get; set; }

        public ActionResult ES_JDJJBG_ESJD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_JDJJBG_ESJDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_JDJJBG_ESJDBLL.GetLBQCByLBID(jcxx.LBID);
            ES_JDJJBG_ESJDJBXX ES_JDJJBG_ESJDjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_ESJDJBXX>(json);
            ES_JDJJBG_ESJDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_ESJDBLL.SaveES_JDJJBG_ESJDJBXX(jcxx, ES_JDJJBG_ESJDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_JDJJBG_ESJDJBXX()
        {
            string ES_JDJJBG_ESJDJBXXID = Request["ES_JDJJBG_ESJDJBXXID"];
            object result = ES_JDJJBG_ESJDBLL.LoadES_JDJJBG_ESJDJBXX(ES_JDJJBG_ESJDJBXXID);
            return Json(result);
        }
    }
}