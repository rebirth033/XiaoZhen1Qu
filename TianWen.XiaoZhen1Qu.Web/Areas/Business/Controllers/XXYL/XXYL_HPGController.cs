using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_HPGController : BaseController
    {
        public IXXYL_HPGBLL XXYL_HPGBLL { get; set; }

        public ActionResult XXYL_HPG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_HPGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + XXYL_HPGBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_HPGJBXX XXYL_HPGjbxx = JsonHelper.ConvertJsonToObject<XXYL_HPGJBXX>(json);
            XXYL_HPGjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_HPGBLL.SaveXXYL_HPGJBXX(jcxx, XXYL_HPGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_HPGJBXX()
        {
            string XXYL_HPGJBXXID = Request["XXYL_HPGJBXXID"];
            object result = XXYL_HPGBLL.LoadXXYL_HPGJBXX(XXYL_HPGJBXXID);
            return Json(result);
        }
    }
}