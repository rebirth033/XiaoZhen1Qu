using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_MYWJController : BaseController
    {
        public IPFCG_MYWJBLL PFCG_MYWJBLL { get; set; }

        public ActionResult PFCG_MYWJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_MYWJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_MYWJBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_MYWJJBXX PFCG_MYWJjbxx = JsonHelper.ConvertJsonToObject<PFCG_MYWJJBXX>(json);
            PFCG_MYWJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_MYWJBLL.SavePFCG_MYWJJBXX(jcxx, PFCG_MYWJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_MYWJJBXX()
        {
            string PFCG_MYWJJBXXID = Request["PFCG_MYWJJBXXID"];
            object result = PFCG_MYWJBLL.LoadPFCG_MYWJJBXX(PFCG_MYWJJBXXID);
            return Json(result);
        }
    }
}