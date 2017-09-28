using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_LPController : BaseController
    {
        public IPFCG_LPBLL PFCG_LPBLL { get; set; }

        public ActionResult PFCG_LP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_LPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_LPBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_LPJBXX PFCG_LPjbxx = JsonHelper.ConvertJsonToObject<PFCG_LPJBXX>(json);
            PFCG_LPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_LPBLL.SavePFCG_LPJBXX(jcxx, PFCG_LPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_LPJBXX()
        {
            string PFCG_LPJBXXID = Request["PFCG_LPJBXXID"];
            object result = PFCG_LPBLL.LoadPFCG_LPJBXX(PFCG_LPJBXXID);
            return Json(result);
        }
    }
}