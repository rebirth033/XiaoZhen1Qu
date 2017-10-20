using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PWKQ_YCMPController : BaseController
    {
        public IPWKQ_YCMPBLL PWKQ_YCMPBLL { get; set; }

        public ActionResult PWKQ_YCMP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PWKQ_YCMPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + PWKQ_YCMPBLL.GetLBQCByLBID(jcxx.LBID);
            PWKQ_YCMPJBXX PWKQ_YCMPjbxx = JsonHelper.ConvertJsonToObject<PWKQ_YCMPJBXX>(json);
            PWKQ_YCMPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_YCMPBLL.SavePWKQ_YCMPJBXX(jcxx, PWKQ_YCMPjbxx);
            return Json(result);
        }

        public JsonResult LoadPWKQ_YCMPJBXX()
        {
            string PWKQ_YCMPJBXXID = Request["PWKQ_YCMPJBXXID"];
            object result = PWKQ_YCMPBLL.LoadPWKQ_YCMPJBXX(PWKQ_YCMPJBXXID);
            return Json(result);
        }
    }
}