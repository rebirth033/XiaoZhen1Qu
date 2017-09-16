using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_QTES_ESSBController : BaseController
    {
        public IES_QTES_ESSBBLL ES_QTES_ESSBBLL { get; set; }

        public ActionResult ES_QTES_ESSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_QTES_ESSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_QTES_ESSBBLL.GetLBQCByLBID(jcxx.LBID);
            ES_QTES_ESSBJBXX ES_QTES_ESSBJBXX = JsonHelper.ConvertJsonToObject<ES_QTES_ESSBJBXX>(json);
            ES_QTES_ESSBJBXX.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_QTES_ESSBBLL.SaveES_QTES_ESSBJBXX(jcxx, ES_QTES_ESSBJBXX, photos);
            return Json(result);
        }

        public JsonResult LoadES_QTES_ESSBJBXX()
        {
            string ES_QTES_ESSBJBXXID = Request["ES_QTES_ESSBJBXXID"];
            object result = ES_QTES_ESSBBLL.LoadES_QTES_ESSBJBXX(ES_QTES_ESSBJBXXID);
            return Json(result);
        }
    }
}