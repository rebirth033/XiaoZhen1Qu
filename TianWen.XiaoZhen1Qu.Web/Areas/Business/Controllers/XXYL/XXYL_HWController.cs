using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_HWController : BaseController
    {
        public IXXYL_HWBLL XXYL_HWBLL { get; set; }

        public ActionResult XXYL_HW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_HWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_HWJBXX XXYL_HWjbxx = JsonHelper.ConvertJsonToObject<XXYL_HWJBXX>(json);
            XXYL_HWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_HWBLL.SaveXXYL_HWJBXX(jcxx, XXYL_HWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_HWJBXX()
        {
            string XXYL_HWJBXXID = Request["XXYL_HWJBXXID"];
            object result = XXYL_HWBLL.LoadXXYL_HWJBXX(XXYL_HWJBXXID);
            return Json(result);
        }
    }
}