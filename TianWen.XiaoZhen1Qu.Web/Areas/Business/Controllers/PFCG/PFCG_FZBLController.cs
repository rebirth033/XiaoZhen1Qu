using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_FZBLController : BaseController
    {
        public IPFCG_FZBLBLL PFCG_FZBLBLL { get; set; }

        public ActionResult PFCG_FZBL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_FZBLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_FZBLBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_FZBLJBXX PFCG_FZBLjbxx = JsonHelper.ConvertJsonToObject<PFCG_FZBLJBXX>(json);
            PFCG_FZBLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_FZBLBLL.SavePFCG_FZBLJBXX(jcxx, PFCG_FZBLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_FZBLJBXX()
        {
            string PFCG_FZBLJBXXID = Request["PFCG_FZBLJBXXID"];
            object result = PFCG_FZBLBLL.LoadPFCG_FZBLJBXX(PFCG_FZBLJBXXID);
            return Json(result);
        }
    }
}