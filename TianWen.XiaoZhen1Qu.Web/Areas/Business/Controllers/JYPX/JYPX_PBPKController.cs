using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_PBPKController : BaseController
    {
        public IJYPX_PBPKBLL JYPX_PBPKBLL { get; set; }

        public ActionResult JYPX_PBPK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_PBPKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_PBPKJBXX JYPX_PBPKjbxx = JsonHelper.ConvertJsonToObject<JYPX_PBPKJBXX>(json);
            JYPX_PBPKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_PBPKBLL.SaveJYPX_PBPKJBXX(jcxx, JYPX_PBPKjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_PBPKJBXX()
        {
            string JYPX_PBPKJBXXID = Request["JYPX_PBPKJBXXID"];
            object result = JYPX_PBPKBLL.LoadJYPX_PBPKJBXX(JYPX_PBPKJBXXID);
            return Json(result);
        }
    }
}