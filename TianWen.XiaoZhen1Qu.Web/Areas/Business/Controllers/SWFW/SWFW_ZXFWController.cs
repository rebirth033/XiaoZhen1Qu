using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_ZXFWController : BaseController
    {
        public ISWFW_ZXFWBLL SWFW_ZXFWBLL { get; set; }

        public ActionResult SWFW_ZXFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_ZXFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_ZXFWBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_ZXFWJBXX SWFW_ZXFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZXFWJBXX>(json);
            SWFW_ZXFWjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZXFWBLL.SaveSWFW_ZXFWJBXX(jcxx, SWFW_ZXFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_ZXFWJBXX()
        {
            string SWFW_ZXFWJBXXID = Request["SWFW_ZXFWJBXXID"];
            object result = SWFW_ZXFWBLL.LoadSWFW_ZXFWJBXX(SWFW_ZXFWJBXXID);
            return Json(result);
        }
    }
}