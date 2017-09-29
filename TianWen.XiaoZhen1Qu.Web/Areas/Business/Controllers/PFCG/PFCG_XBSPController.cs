using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_XBSPController : BaseController
    {
        public IPFCG_XBSPBLL PFCG_XBSPBLL { get; set; }

        public ActionResult PFCG_XBSP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_XBSPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_XBSPBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_XBSPJBXX PFCG_XBSPjbxx = JsonHelper.ConvertJsonToObject<PFCG_XBSPJBXX>(json);
            PFCG_XBSPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_XBSPBLL.SavePFCG_XBSPJBXX(jcxx, PFCG_XBSPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_XBSPJBXX()
        {
            string PFCG_XBSPJBXXID = Request["PFCG_XBSPJBXXID"];
            object result = PFCG_XBSPBLL.LoadPFCG_XBSPJBXX(PFCG_XBSPJBXXID);
            return Json(result);
        }
    }
}