using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_ZYJNPXController : BaseController
    {
        public IJYPX_ZYJNPXBLL JYPX_ZYJNPXBLL { get; set; }

        public ActionResult JYPX_ZYJNPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_ZYJNPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_ZYJNPXBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_ZYJNPXJBXX JYPX_ZYJNPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZYJNPXJBXX>(json);
            JYPX_ZYJNPXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ZYJNPXBLL.SaveJYPX_ZYJNPXJBXX(jcxx, JYPX_ZYJNPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_ZYJNPXJBXX()
        {
            string JYPX_ZYJNPXJBXXID = Request["JYPX_ZYJNPXJBXXID"];
            object result = JYPX_ZYJNPXBLL.LoadJYPX_ZYJNPXJBXX(JYPX_ZYJNPXJBXXID);
            return Json(result);
        }
    }
}