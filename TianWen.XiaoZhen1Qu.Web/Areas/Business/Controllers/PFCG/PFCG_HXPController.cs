using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_HXPController : BaseController
    {
        public IPFCG_HXPBLL PFCG_HXPBLL { get; set; }

        public ActionResult PFCG_HXP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_HXPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HXPJBXX PFCG_HXPjbxx = JsonHelper.ConvertJsonToObject<PFCG_HXPJBXX>(json);
            PFCG_HXPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_HXPBLL.SavePFCG_HXPJBXX(jcxx, PFCG_HXPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_HXPJBXX()
        {
            string PFCG_HXPJBXXID = Request["PFCG_HXPJBXXID"];
            object result = PFCG_HXPBLL.LoadPFCG_HXPJBXX(PFCG_HXPJBXXID);
            return Json(result);
        }
    }
}