using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_HWYDController : BaseController
    {
        public IPFCG_HWYDBLL PFCG_HWYDBLL { get; set; }

        public ActionResult PFCG_HWYD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_HWYDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_HWYDBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_HWYDJBXX PFCG_HWYDjbxx = JsonHelper.ConvertJsonToObject<PFCG_HWYDJBXX>(json);
            PFCG_HWYDjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_HWYDBLL.SavePFCG_HWYDJBXX(jcxx, PFCG_HWYDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_HWYDJBXX()
        {
            string PFCG_HWYDJBXXID = Request["PFCG_HWYDJBXXID"];
            object result = PFCG_HWYDBLL.LoadPFCG_HWYDJBXX(PFCG_HWYDJBXXID);
            return Json(result);
        }
    }
}