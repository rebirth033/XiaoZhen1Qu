using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_SCSBController : BaseController
    {
        public IPFCG_SCSBBLL PFCG_SCSBBLL { get; set; }

        public ActionResult PFCG_SCSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_SCSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_SCSBBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_SCSBJBXX PFCG_SCSBjbxx = JsonHelper.ConvertJsonToObject<PFCG_SCSBJBXX>(json);
            PFCG_SCSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_SCSBBLL.SavePFCG_SCSBJBXX(jcxx, PFCG_SCSBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_SCSBJBXX()
        {
            string PFCG_SCSBJBXXID = Request["PFCG_SCSBJBXXID"];
            object result = PFCG_SCSBBLL.LoadPFCG_SCSBJBXX(PFCG_SCSBJBXXID);
            return Json(result);
        }
    }
}