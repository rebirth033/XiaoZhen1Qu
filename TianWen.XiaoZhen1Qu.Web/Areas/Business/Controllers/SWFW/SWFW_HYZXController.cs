using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_HYZXController : BaseController
    {
        public ISWFW_HYZXBLL SWFW_HYZXBLL { get; set; }

        public ActionResult SWFW_HYZX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_HYZXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_HYZXBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_HYZXJBXX SWFW_HYZXjbxx = JsonHelper.ConvertJsonToObject<SWFW_HYZXJBXX>(json);
            SWFW_HYZXjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_HYZXBLL.SaveSWFW_HYZXJBXX(jcxx, SWFW_HYZXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_HYZXJBXX()
        {
            string SWFW_HYZXJBXXID = Request["SWFW_HYZXJBXXID"];
            object result = SWFW_HYZXBLL.LoadSWFW_HYZXJBXX(SWFW_HYZXJBXXID);
            return Json(result);
        }
    }
}