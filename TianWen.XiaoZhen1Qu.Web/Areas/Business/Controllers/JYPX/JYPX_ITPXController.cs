using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_ITPXController : BaseController
    {
        public IJYPX_ITPXBLL JYPX_ITPXBLL { get; set; }

        public ActionResult JYPX_ITPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_ITPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ITPXJBXX JYPX_ITPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_ITPXJBXX>(json);
            JYPX_ITPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ITPXBLL.SaveJYPX_ITPXJBXX(jcxx, JYPX_ITPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_ITPXJBXX()
        {
            string JYPX_ITPXJBXXID = Request["JYPX_ITPXJBXXID"];
            object result = JYPX_ITPXBLL.LoadJYPX_ITPXJBXX(JYPX_ITPXJBXXID);
            return Json(result);
        }
    }
}