using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_NYController : BaseController
    {
        public IZSJM_NYBLL ZSJM_NYBLL { get; set; }

        public ActionResult ZSJM_NY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_NYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ZSJM_NYBLL.GetLBQCByLBID(jcxx.LBID);
            ZSJM_NYJBXX ZSJM_NYjbxx = JsonHelper.ConvertJsonToObject<ZSJM_NYJBXX>(json);
            ZSJM_NYjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_NYBLL.SaveZSJM_NYJBXX(jcxx, ZSJM_NYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_NYJBXX()
        {
            string ZSJM_NYJBXXID = Request["ZSJM_NYJBXXID"];
            object result = ZSJM_NYBLL.LoadZSJM_NYJBXX(ZSJM_NYJBXXID);
            return Json(result);
        }
    }
}