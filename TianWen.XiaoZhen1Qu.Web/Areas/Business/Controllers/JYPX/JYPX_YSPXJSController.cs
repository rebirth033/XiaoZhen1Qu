using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YSPXJSController : BaseController
    {
        public IJYPX_YSPXJSBLL JYPX_YSPXJSBLL { get; set; }

        public ActionResult JYPX_YSPXJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YSPXJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YSPXJSJBXX JYPX_YSPXJSjbxx = JsonHelper.ConvertJsonToObject<JYPX_YSPXJSJBXX>(json);
            JYPX_YSPXJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YSPXJSBLL.SaveJYPX_YSPXJSJBXX(jcxx, JYPX_YSPXJSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YSPXJSJBXX()
        {
            string JYPX_YSPXJSJBXXID = Request["JYPX_YSPXJSJBXXID"];
            object result = JYPX_YSPXJSBLL.LoadJYPX_YSPXJSJBXX(JYPX_YSPXJSJBXXID);
            return Json(result);
        }
    }
}