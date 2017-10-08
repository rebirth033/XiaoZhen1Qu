using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YYPXController : BaseController
    {
        public IJYPX_YYPXBLL JYPX_YYPXBLL { get; set; }

        public ActionResult JYPX_YYPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YYPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_YYPXBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_YYPXJBXX JYPX_YYPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJBXX>(json);
            JYPX_YYPXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYPXBLL.SaveJYPX_YYPXJBXX(jcxx, JYPX_YYPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YYPXJBXX()
        {
            string JYPX_YYPXJBXXID = Request["JYPX_YYPXJBXXID"];
            object result = JYPX_YYPXBLL.LoadJYPX_YYPXJBXX(JYPX_YYPXJBXXID);
            return Json(result);
        }
    }
}