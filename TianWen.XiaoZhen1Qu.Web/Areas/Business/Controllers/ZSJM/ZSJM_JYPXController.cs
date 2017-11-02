using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_JYPXController : BaseController
    {
        public IZSJM_JYPXBLL ZSJM_JYPXBLL { get; set; }

        public ActionResult ZSJM_JYPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_JYPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JYPXJBXX ZSJM_JYPXjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JYPXJBXX>(json);
            ZSJM_JYPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JYPXBLL.SaveZSJM_JYPXJBXX(jcxx, ZSJM_JYPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_JYPXJBXX()
        {
            string ZSJM_JYPXJBXXID = Request["ZSJM_JYPXJBXXID"];
            object result = ZSJM_JYPXBLL.LoadZSJM_JYPXJBXX(ZSJM_JYPXJBXXID);
            return Json(result);
        }
    }
}