using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_FLZXController : BaseController
    {
        public ISWFW_FLZXBLL SWFW_FLZXBLL { get; set; }

        public ActionResult SWFW_FLZX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_FLZXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_FLZXBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_FLZXJBXX SWFW_FLZXjbxx = JsonHelper.ConvertJsonToObject<SWFW_FLZXJBXX>(json);
            SWFW_FLZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_FLZXBLL.SaveSWFW_FLZXJBXX(jcxx, SWFW_FLZXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_FLZXJBXX()
        {
            string SWFW_FLZXJBXXID = Request["SWFW_FLZXJBXXID"];
            object result = SWFW_FLZXBLL.LoadSWFW_FLZXJBXX(SWFW_FLZXJBXXID);
            return Json(result);
        }
    }
}