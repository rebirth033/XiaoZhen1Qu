using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_JXSBWXController : BaseController
    {
        public ISWFW_JXSBWXBLL SWFW_JXSBWXBLL { get; set; }

        public ActionResult SWFW_JXSBWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_JXSBWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_JXSBWXBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_JXSBWXJBXX SWFW_JXSBWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_JXSBWXJBXX>(json);
            SWFW_JXSBWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_JXSBWXBLL.SaveSWFW_JXSBWXJBXX(jcxx, SWFW_JXSBWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_JXSBWXJBXX()
        {
            string SWFW_JXSBWXJBXXID = Request["SWFW_JXSBWXJBXXID"];
            object result = SWFW_JXSBWXBLL.LoadSWFW_JXSBWXJBXX(SWFW_JXSBWXJBXXID);
            return Json(result);
        }
    }
}