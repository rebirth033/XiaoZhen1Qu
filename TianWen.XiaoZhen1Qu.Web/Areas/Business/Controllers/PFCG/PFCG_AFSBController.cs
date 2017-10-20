using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_AFSBController : BaseController
    {
        public IPFCG_AFSBBLL PFCG_AFSBBLL { get; set; }

        public ActionResult PFCG_AFSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_AFSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_AFSBBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_AFSBJBXX PFCG_AFSBjbxx = JsonHelper.ConvertJsonToObject<PFCG_AFSBJBXX>(json);
            PFCG_AFSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_AFSBBLL.SavePFCG_AFSBJBXX(jcxx, PFCG_AFSBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_AFSBJBXX()
        {
            string PFCG_AFSBJBXXID = Request["PFCG_AFSBJBXXID"];
            object result = PFCG_AFSBBLL.LoadPFCG_AFSBJBXX(PFCG_AFSBJBXXID);
            return Json(result);
        }
    }
}