using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_SJCHController : BaseController
    {
        public ISWFW_SJCHBLL SWFW_SJCHBLL { get; set; }

        public ActionResult SWFW_SJCH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_SJCHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_SJCHBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_SJCHJBXX SWFW_SJCHjbxx = JsonHelper.ConvertJsonToObject<SWFW_SJCHJBXX>(json);
            SWFW_SJCHjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_SJCHBLL.SaveSWFW_SJCHJBXX(jcxx, SWFW_SJCHjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_SJCHJBXX()
        {
            string SWFW_SJCHJBXXID = Request["SWFW_SJCHJBXXID"];
            object result = SWFW_SJCHBLL.LoadSWFW_SJCHJBXX(SWFW_SJCHJBXXID);
            return Json(result);
        }
    }
}