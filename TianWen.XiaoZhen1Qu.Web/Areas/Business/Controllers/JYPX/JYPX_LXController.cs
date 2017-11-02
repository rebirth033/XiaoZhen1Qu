using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_LXController : BaseController
    {
        public IJYPX_LXBLL JYPX_LXBLL { get; set; }

        public ActionResult JYPX_LX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_LXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_LXJBXX JYPX_LXjbxx = JsonHelper.ConvertJsonToObject<JYPX_LXJBXX>(json);
            JYPX_LXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_LXBLL.SaveJYPX_LXJBXX(jcxx, JYPX_LXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_LXJBXX()
        {
            string JYPX_LXJBXXID = Request["JYPX_LXJBXXID"];
            object result = JYPX_LXBLL.LoadJYPX_LXJBXX(JYPX_LXJBXXID);
            return Json(result);
        }
    }
}