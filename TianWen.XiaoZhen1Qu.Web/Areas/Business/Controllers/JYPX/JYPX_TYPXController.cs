using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_TYPXController : BaseController
    {
        public IJYPX_TYPXBLL JYPX_TYPXBLL { get; set; }

        public ActionResult JYPX_TYPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_TYPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_TYPXJBXX JYPX_TYPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_TYPXJBXX>(json);
            JYPX_TYPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_TYPXBLL.SaveJYPX_TYPXJBXX(jcxx, JYPX_TYPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_TYPXJBXX()
        {
            string JYPX_TYPXJBXXID = Request["JYPX_TYPXJBXXID"];
            object result = JYPX_TYPXBLL.LoadJYPX_TYPXJBXX(JYPX_TYPXJBXXID);
            return Json(result);
        }
    }
}