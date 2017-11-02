using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YMController : BaseController
    {
        public IJYPX_YMBLL JYPX_YMBLL { get; set; }

        public ActionResult JYPX_YM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YMJBXX JYPX_YMjbxx = JsonHelper.ConvertJsonToObject<JYPX_YMJBXX>(json);
            JYPX_YMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YMBLL.SaveJYPX_YMJBXX(jcxx, JYPX_YMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YMJBXX()
        {
            string JYPX_YMJBXXID = Request["JYPX_YMJBXXID"];
            object result = JYPX_YMBLL.LoadJYPX_YMJBXX(JYPX_YMJBXXID);
            return Json(result);
        }
    }
}