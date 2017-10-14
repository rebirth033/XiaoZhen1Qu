using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_LYQDController : BaseController
    {
        public ISWFW_LYQDBLL SWFW_LYQDBLL { get; set; }

        public ActionResult SWFW_LYQD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_LYQDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_LYQDBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_LYQDJBXX SWFW_LYQDjbxx = JsonHelper.ConvertJsonToObject<SWFW_LYQDJBXX>(json);
            SWFW_LYQDjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_LYQDBLL.SaveSWFW_LYQDJBXX(jcxx, SWFW_LYQDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_LYQDJBXX()
        {
            string SWFW_LYQDJBXXID = Request["SWFW_LYQDJBXXID"];
            object result = SWFW_LYQDBLL.LoadSWFW_LYQDJBXX(SWFW_LYQDJBXXID);
            return Json(result);
        }
    }
}