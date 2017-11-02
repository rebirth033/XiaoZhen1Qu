using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YYPXJSController : BaseController
    {
        public IJYPX_YYPXJSBLL JYPX_YYPXJSBLL { get; set; }

        public ActionResult JYPX_YYPXJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YYPXJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYPXJSJBXX JYPX_YYPXJSjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJSJBXX>(json);
            JYPX_YYPXJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYPXJSBLL.SaveJYPX_YYPXJSJBXX(jcxx, JYPX_YYPXJSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YYPXJSJBXX()
        {
            string JYPX_YYPXJSJBXXID = Request["JYPX_YYPXJSJBXXID"];
            object result = JYPX_YYPXJSBLL.LoadJYPX_YYPXJSJBXX(JYPX_YYPXJSJBXXID);
            return Json(result);
        }
    }
}