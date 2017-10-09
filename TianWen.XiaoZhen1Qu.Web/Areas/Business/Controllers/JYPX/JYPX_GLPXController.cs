using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_GLPXController : BaseController
    {
        public IJYPX_GLPXBLL JYPX_GLPXBLL { get; set; }

        public ActionResult JYPX_GLPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_GLPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_GLPXBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_GLPXJBXX JYPX_GLPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_GLPXJBXX>(json);
            JYPX_GLPXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_GLPXBLL.SaveJYPX_GLPXJBXX(jcxx, JYPX_GLPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_GLPXJBXX()
        {
            string JYPX_GLPXJBXXID = Request["JYPX_GLPXJBXXID"];
            object result = JYPX_GLPXBLL.LoadJYPX_GLPXJBXX(JYPX_GLPXJBXXID);
            return Json(result);
        }
    }
}