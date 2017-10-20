using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_TSController : BaseController
    {
        public IPFCG_TSBLL PFCG_TSBLL { get; set; }

        public ActionResult PFCG_TS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_TSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_TSBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_TSJBXX PFCG_TSjbxx = JsonHelper.ConvertJsonToObject<PFCG_TSJBXX>(json);
            PFCG_TSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_TSBLL.SavePFCG_TSJBXX(jcxx, PFCG_TSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_TSJBXX()
        {
            string PFCG_TSJBXXID = Request["PFCG_TSJBXXID"];
            object result = PFCG_TSBLL.LoadPFCG_TSJBXX(PFCG_TSJBXXID);
            return Json(result);
        }
    }
}