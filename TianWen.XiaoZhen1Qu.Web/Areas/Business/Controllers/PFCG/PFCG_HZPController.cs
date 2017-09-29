using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_HZPController : BaseController
    {
        public IPFCG_HZPBLL PFCG_HZPBLL { get; set; }

        public ActionResult PFCG_HZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_HZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_HZPBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_HZPJBXX PFCG_HZPjbxx = JsonHelper.ConvertJsonToObject<PFCG_HZPJBXX>(json);
            PFCG_HZPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_HZPBLL.SavePFCG_HZPJBXX(jcxx, PFCG_HZPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_HZPJBXX()
        {
            string PFCG_HZPJBXXID = Request["PFCG_HZPJBXXID"];
            object result = PFCG_HZPBLL.LoadPFCG_HZPJBXX(PFCG_HZPJBXXID);
            return Json(result);
        }
    }
}