using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_QT_ESSBController : BaseController
    {
        public IES_QT_ESSBBLL ES_QT_ESSBBLL { get; set; }

        public ActionResult ES_QT_ESSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_QT_ESSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_QT_ESSBBLL.GetLBQCByLBID(jcxx.LBID);
            ES_QT_ESSBJBXX ES_QT_ESSBjbxx = JsonHelper.ConvertJsonToObject<ES_QT_ESSBJBXX>(json);
            ES_QT_ESSBjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_QT_ESSBBLL.SaveES_QT_ESSBJBXX(jcxx, ES_QT_ESSBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_QT_ESSBJBXX()
        {
            string ES_QT_ESSBJBXXID = Request["ES_QT_ESSBJBXXID"];
            object result = ES_QT_ESSBBLL.LoadES_QT_ESSBJBXX(ES_QT_ESSBJBXXID);
            return Json(result);
        }
    }
}