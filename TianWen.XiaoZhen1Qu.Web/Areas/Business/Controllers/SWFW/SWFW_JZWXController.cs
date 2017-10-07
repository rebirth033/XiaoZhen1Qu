using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_JZWXController : BaseController
    {
        public ISWFW_JZWXBLL SWFW_JZWXBLL { get; set; }

        public ActionResult SWFW_JZWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_JZWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_JZWXBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_JZWXJBXX SWFW_JZWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_JZWXJBXX>(json);
            SWFW_JZWXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_JZWXBLL.SaveSWFW_JZWXJBXX(jcxx, SWFW_JZWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_JZWXJBXX()
        {
            string SWFW_JZWXJBXXID = Request["SWFW_JZWXJBXXID"];
            object result = SWFW_JZWXBLL.LoadSWFW_JZWXJBXX(SWFW_JZWXJBXXID);
            return Json(result);
        }
    }
}