using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_YXController : BaseController
    {
        public IPFCG_YXBLL PFCG_YXBLL { get; set; }

        public ActionResult PFCG_YX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_YXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_YXBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_YXJBXX PFCG_YXjbxx = JsonHelper.ConvertJsonToObject<PFCG_YXJBXX>(json);
            PFCG_YXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_YXBLL.SavePFCG_YXJBXX(jcxx, PFCG_YXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_YXJBXX()
        {
            string PFCG_YXJBXXID = Request["PFCG_YXJBXXID"];
            object result = PFCG_YXBLL.LoadPFCG_YXJBXX(PFCG_YXJBXXID);
            return Json(result);
        }
    }
}