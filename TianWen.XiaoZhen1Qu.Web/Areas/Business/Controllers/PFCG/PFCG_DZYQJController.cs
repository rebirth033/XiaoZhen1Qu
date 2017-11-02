using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_DZYQJController : BaseController
    {
        public IPFCG_DZYQJBLL PFCG_DZYQJBLL { get; set; }

        public ActionResult PFCG_DZYQJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_DZYQJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DZYQJJBXX PFCG_DZYQJjbxx = JsonHelper.ConvertJsonToObject<PFCG_DZYQJJBXX>(json);
            PFCG_DZYQJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_DZYQJBLL.SavePFCG_DZYQJJBXX(jcxx, PFCG_DZYQJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_DZYQJJBXX()
        {
            string PFCG_DZYQJJBXXID = Request["PFCG_DZYQJJBXXID"];
            object result = PFCG_DZYQJBLL.LoadPFCG_DZYQJJBXX(PFCG_DZYQJJBXXID);
            return Json(result);
        }
    }
}