using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_FYSJController : BaseController
    {
        public ISWFW_FYSJBLL SWFW_FYSJBLL { get; set; }

        public ActionResult SWFW_FYSJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_FYSJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_FYSJBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_FYSJJBXX SWFW_FYSJjbxx = JsonHelper.ConvertJsonToObject<SWFW_FYSJJBXX>(json);
            SWFW_FYSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_FYSJBLL.SaveSWFW_FYSJJBXX(jcxx, SWFW_FYSJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_FYSJJBXX()
        {
            string SWFW_FYSJJBXXID = Request["SWFW_FYSJJBXXID"];
            object result = SWFW_FYSJBLL.LoadSWFW_FYSJJBXX(SWFW_FYSJJBXXID);
            return Json(result);
        }
    }
}