using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_SJPXController : BaseController
    {
        public IJYPX_SJPXBLL JYPX_SJPXBLL { get; set; }

        public ActionResult JYPX_SJPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_SJPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_SJPXBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_SJPXJBXX JYPX_SJPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_SJPXJBXX>(json);
            JYPX_SJPXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_SJPXBLL.SaveJYPX_SJPXJBXX(jcxx, JYPX_SJPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_SJPXJBXX()
        {
            string JYPX_SJPXJBXXID = Request["JYPX_SJPXJBXXID"];
            object result = JYPX_SJPXBLL.LoadJYPX_SJPXJBXX(JYPX_SJPXJBXXID);
            return Json(result);
        }
    }
}