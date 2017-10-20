using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_DJZMController : BaseController
    {
        public IPFCG_DJZMBLL PFCG_DJZMBLL { get; set; }

        public ActionResult PFCG_DJZM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_DJZMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_DJZMBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_DJZMJBXX PFCG_DJZMjbxx = JsonHelper.ConvertJsonToObject<PFCG_DJZMJBXX>(json);
            PFCG_DJZMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_DJZMBLL.SavePFCG_DJZMJBXX(jcxx, PFCG_DJZMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_DJZMJBXX()
        {
            string PFCG_DJZMJBXXID = Request["PFCG_DJZMJBXXID"];
            object result = PFCG_DJZMBLL.LoadPFCG_DJZMJBXX(PFCG_DJZMJBXXID);
            return Json(result);
        }
    }
}