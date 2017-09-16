using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_QTES_GCQXController : BaseController
    {
        public IES_QTES_GCQXBLL ES_QTES_GCQXBLL { get; set; }

        public ActionResult ES_QTES_GCQX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_QTES_GCQXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_QTES_GCQXBLL.GetLBQCByLBID(jcxx.LBID);
            ES_QTES_GCQXJBXX ES_QTES_GCQXJBXX = JsonHelper.ConvertJsonToObject<ES_QTES_GCQXJBXX>(json);
            ES_QTES_GCQXJBXX.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_QTES_GCQXBLL.SaveES_QTES_GCQXJBXX(jcxx, ES_QTES_GCQXJBXX, photos);
            return Json(result);
        }

        public JsonResult LoadES_QTES_GCQXJBXX()
        {
            string ES_QTES_GCQXJBXXID = Request["ES_QTES_GCQXJBXXID"];
            object result = ES_QTES_GCQXBLL.LoadES_QTES_GCQXJBXX(ES_QTES_GCQXJBXXID);
            return Json(result);
        }
    }
}