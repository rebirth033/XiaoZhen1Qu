using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_WLBXWHController : BaseController
    {
        public ISWFW_WLBXWHBLL SWFW_WLBXWHBLL { get; set; }

        public ActionResult SWFW_WLBXWH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_WLBXWHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_WLBXWHBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_WLBXWHJBXX SWFW_WLBXWHjbxx = JsonHelper.ConvertJsonToObject<SWFW_WLBXWHJBXX>(json);
            SWFW_WLBXWHjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_WLBXWHBLL.SaveSWFW_WLBXWHJBXX(jcxx, SWFW_WLBXWHjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_WLBXWHJBXX()
        {
            string SWFW_WLBXWHJBXXID = Request["SWFW_WLBXWHJBXXID"];
            object result = SWFW_WLBXWHBLL.LoadSWFW_WLBXWHJBXX(SWFW_WLBXWHJBXXID);
            return Json(result);
        }
    }
}