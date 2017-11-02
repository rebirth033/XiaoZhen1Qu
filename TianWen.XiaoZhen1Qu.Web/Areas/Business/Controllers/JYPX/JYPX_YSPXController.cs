using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YSPXController : BaseController
    {
        public IJYPX_YSPXBLL JYPX_YSPXBLL { get; set; }

        public ActionResult JYPX_YSPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YSPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YSPXJBXX JYPX_YSPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_YSPXJBXX>(json);
            JYPX_YSPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YSPXBLL.SaveJYPX_YSPXJBXX(jcxx, JYPX_YSPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YSPXJBXX()
        {
            string JYPX_YSPXJBXXID = Request["JYPX_YSPXJBXXID"];
            object result = JYPX_YSPXBLL.LoadJYPX_YSPXJBXX(JYPX_YSPXJBXXID);
            return Json(result);
        }
    }
}