using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_TYJLController : BaseController
    {
        public IJYPX_TYJLBLL JYPX_TYJLBLL { get; set; }

        public ActionResult JYPX_TYJL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_TYJLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_TYJLJBXX JYPX_TYJLjbxx = JsonHelper.ConvertJsonToObject<JYPX_TYJLJBXX>(json);
            JYPX_TYJLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_TYJLBLL.SaveJYPX_TYJLJBXX(jcxx, JYPX_TYJLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_TYJLJBXX()
        {
            string JYPX_TYJLJBXXID = Request["JYPX_TYJLJBXXID"];
            object result = JYPX_TYJLBLL.LoadJYPX_TYJLJBXX(JYPX_TYJLJBXXID);
            return Json(result);
        }
    }
}