using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_KQController : BaseController
    {
        public IPFCG_KQBLL PFCG_KQBLL { get; set; }

        public ActionResult PFCG_KQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_KQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_KQJBXX PFCG_KQjbxx = JsonHelper.ConvertJsonToObject<PFCG_KQJBXX>(json);
            PFCG_KQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_KQBLL.SavePFCG_KQJBXX(jcxx, PFCG_KQjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_KQJBXX()
        {
            string PFCG_KQJBXXID = Request["PFCG_KQJBXXID"];
            object result = PFCG_KQBLL.LoadPFCG_KQJBXX(PFCG_KQJBXXID);
            return Json(result);
        }
    }
}