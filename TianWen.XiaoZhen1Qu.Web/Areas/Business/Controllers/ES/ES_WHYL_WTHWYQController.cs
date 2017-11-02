using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_WHYL_WTHWYQController : BaseController
    {
        public IES_WHYL_WTHWYQBLL ES_WHYL_WTHWYQBLL { get; set; }

        public ActionResult ES_WHYL_WTHWYQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_WHYL_WTHWYQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_WHYL_WTHWYQJBXX ES_WHYL_WTHWYQjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_WTHWYQJBXX>(json);
            ES_WHYL_WTHWYQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_WTHWYQBLL.SaveES_WHYL_WTHWYQJBXX(jcxx, ES_WHYL_WTHWYQjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_WHYL_WTHWYQJBXX()
        {
            string ES_WHYL_WTHWYQJBXXID = Request["ES_WHYL_WTHWYQJBXXID"];
            object result = ES_WHYL_WTHWYQBLL.LoadES_WHYL_WTHWYQJBXX(ES_WHYL_WTHWYQJBXXID);
            return Json(result);
        }
    }
}