using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_ZLController : BaseController
    {
        public ISWFW_ZLBLL SWFW_ZLBLL { get; set; }

        public ActionResult SWFW_ZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_ZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_ZLBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_ZLJBXX SWFW_ZLjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZLJBXX>(json);
            SWFW_ZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZLBLL.SaveSWFW_ZLJBXX(jcxx, SWFW_ZLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_ZLJBXX()
        {
            string SWFW_ZLJBXXID = Request["SWFW_ZLJBXXID"];
            object result = SWFW_ZLBLL.LoadSWFW_ZLJBXX(SWFW_ZLJBXXID);
            return Json(result);
        }
    }
}