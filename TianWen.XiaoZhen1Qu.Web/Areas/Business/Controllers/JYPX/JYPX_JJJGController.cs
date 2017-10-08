using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_JJJGController : BaseController
    {
        public IJYPX_JJJGBLL JYPX_JJJGBLL { get; set; }

        public ActionResult JYPX_JJJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_JJJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_JJJGBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_JJJGJBXX JYPX_JJJGjbxx = JsonHelper.ConvertJsonToObject<JYPX_JJJGJBXX>(json);
            JYPX_JJJGjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_JJJGBLL.SaveJYPX_JJJGJBXX(jcxx, JYPX_JJJGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_JJJGJBXX()
        {
            string JYPX_JJJGJBXXID = Request["JYPX_JJJGJBXXID"];
            object result = JYPX_JJJGBLL.LoadJYPX_JJJGJBXX(JYPX_JJJGJBXXID);
            return Json(result);
        }
    }
}