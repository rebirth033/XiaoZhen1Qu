using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_SPController : BaseController
    {
        public IPFCG_SPBLL PFCG_SPBLL { get; set; }

        public ActionResult PFCG_SP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_SPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_SPBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_SPJBXX PFCG_SPjbxx = JsonHelper.ConvertJsonToObject<PFCG_SPJBXX>(json);
            PFCG_SPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_SPBLL.SavePFCG_SPJBXX(jcxx, PFCG_SPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_SPJBXX()
        {
            string PFCG_SPJBXXID = Request["PFCG_SPJBXXID"];
            object result = PFCG_SPBLL.LoadPFCG_SPJBXX(PFCG_SPJBXXID);
            return Json(result);
        }
    }
}