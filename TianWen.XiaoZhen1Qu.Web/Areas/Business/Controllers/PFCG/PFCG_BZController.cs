using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_BZController : BaseController
    {
        public IPFCG_BZBLL PFCG_BZBLL { get; set; }

        public ActionResult PFCG_BZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_BZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_BZBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_BZJBXX PFCG_BZjbxx = JsonHelper.ConvertJsonToObject<PFCG_BZJBXX>(json);
            PFCG_BZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BZBLL.SavePFCG_BZJBXX(jcxx, PFCG_BZjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_BZJBXX()
        {
            string PFCG_BZJBXXID = Request["PFCG_BZJBXXID"];
            object result = PFCG_BZBLL.LoadPFCG_BZJBXX(PFCG_BZJBXXID);
            return Json(result);
        }
    }
}