using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_SJSMController : BaseController
    {
        public IPFCG_SJSMBLL PFCG_SJSMBLL { get; set; }

        public ActionResult PFCG_SJSM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_SJSMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SJSMJBXX PFCG_SJSMjbxx = JsonHelper.ConvertJsonToObject<PFCG_SJSMJBXX>(json);
            PFCG_SJSMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_SJSMBLL.SavePFCG_SJSMJBXX(jcxx, PFCG_SJSMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_SJSMJBXX()
        {
            string PFCG_SJSMJBXXID = Request["PFCG_SJSMJBXXID"];
            object result = PFCG_SJSMBLL.LoadPFCG_SJSMJBXX(PFCG_SJSMJBXXID);
            return Json(result);
        }
    }
}