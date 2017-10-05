using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_PHZPController : BaseController
    {
        public ISWFW_PHZPBLL SWFW_PHZPBLL { get; set; }

        public ActionResult SWFW_PHZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_PHZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_PHZPBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_PHZPJBXX SWFW_PHZPjbxx = JsonHelper.ConvertJsonToObject<SWFW_PHZPJBXX>(json);
            SWFW_PHZPjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_PHZPBLL.SaveSWFW_PHZPJBXX(jcxx, SWFW_PHZPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_PHZPJBXX()
        {
            string SWFW_PHZPJBXXID = Request["SWFW_PHZPJBXXID"];
            object result = SWFW_PHZPBLL.LoadSWFW_PHZPJBXX(SWFW_PHZPJBXXID);
            return Json(result);
        }
    }
}