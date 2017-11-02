using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_ZXXYDYController : BaseController
    {
        public IJYPX_ZXXYDYBLL JYPX_ZXXYDYBLL { get; set; }

        public ActionResult JYPX_ZXXYDY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_ZXXYDYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZXXYDYJBXX JYPX_ZXXYDYjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZXXYDYJBXX>(json);
            JYPX_ZXXYDYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ZXXYDYBLL.SaveJYPX_ZXXYDYJBXX(jcxx, JYPX_ZXXYDYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_ZXXYDYJBXX()
        {
            string JYPX_ZXXYDYJBXXID = Request["JYPX_ZXXYDYJBXXID"];
            object result = JYPX_ZXXYDYBLL.LoadJYPX_ZXXYDYJBXX(JYPX_ZXXYDYJBXXID);
            return Json(result);
        }
    }
}