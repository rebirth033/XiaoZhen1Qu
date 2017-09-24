using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PWKQ_DYPController : BaseController
    {
        public IPWKQ_DYPBLL PWKQ_DYPBLL { get; set; }

        public ActionResult PWKQ_DYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PWKQ_DYPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PWKQ_DYPBLL.GetLBQCByLBID(jcxx.LBID);
            PWKQ_DYPJBXX PWKQ_DYPjbxx = JsonHelper.ConvertJsonToObject<PWKQ_DYPJBXX>(json);
            PWKQ_DYPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PWKQ_DYPBLL.SavePWKQ_DYPJBXX(jcxx, PWKQ_DYPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPWKQ_DYPJBXX()
        {
            string PWKQ_DYPJBXXID = Request["PWKQ_DYPJBXXID"];
            object result = PWKQ_DYPBLL.LoadPWKQ_DYPJBXX(PWKQ_DYPJBXXID);
            return Json(result);
        }
    }
}