using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_KDController : BaseController
    {
        public ISWFW_KDBLL SWFW_KDBLL { get; set; }

        public ActionResult SWFW_KD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_KDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_KDJBXX SWFW_KDjbxx = JsonHelper.ConvertJsonToObject<SWFW_KDJBXX>(json);
            SWFW_KDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_KDBLL.SaveSWFW_KDJBXX(jcxx, SWFW_KDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_KDJBXX()
        {
            string SWFW_KDJBXXID = Request["SWFW_KDJBXXID"];
            object result = SWFW_KDBLL.LoadSWFW_KDJBXX(SWFW_KDJBXXID);
            return Json(result);
        }
    }
}