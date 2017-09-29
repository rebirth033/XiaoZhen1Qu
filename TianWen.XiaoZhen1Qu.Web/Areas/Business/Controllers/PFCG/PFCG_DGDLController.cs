using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_DGDLController : BaseController
    {
        public IPFCG_DGDLBLL PFCG_DGDLBLL { get; set; }

        public ActionResult PFCG_DGDL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_DGDLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_DGDLBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_DGDLJBXX PFCG_DGDLjbxx = JsonHelper.ConvertJsonToObject<PFCG_DGDLJBXX>(json);
            PFCG_DGDLjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_DGDLBLL.SavePFCG_DGDLJBXX(jcxx, PFCG_DGDLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_DGDLJBXX()
        {
            string PFCG_DGDLJBXXID = Request["PFCG_DGDLJBXXID"];
            object result = PFCG_DGDLBLL.LoadPFCG_DGDLJBXX(PFCG_DGDLJBXXID);
            return Json(result);
        }
    }
}