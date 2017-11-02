using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_JJGRController : BaseController
    {
        public IJYPX_JJGRBLL JYPX_JJGRBLL { get; set; }

        public ActionResult JYPX_JJGR()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_JJGRBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_JJGRJBXX JYPX_JJGRjbxx = JsonHelper.ConvertJsonToObject<JYPX_JJGRJBXX>(json);
            JYPX_JJGRjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_JJGRBLL.SaveJYPX_JJGRJBXX(jcxx, JYPX_JJGRjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_JJGRJBXX()
        {
            string JYPX_JJGRJBXXID = Request["JYPX_JJGRJBXXID"];
            object result = JYPX_JJGRBLL.LoadJYPX_JJGRJBXX(JYPX_JJGRJBXXID);
            return Json(result);
        }
    }
}