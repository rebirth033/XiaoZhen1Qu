using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_WHYL_WYXNWPController : BaseController
    {
        public IES_WHYL_WYXNWPBLL ES_WHYL_WYXNWPBLL { get; set; }

        public ActionResult ES_WHYL_WYXNWP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_WHYL_WYXNWPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_WHYL_WYXNWPJBXX ES_WHYL_WYXNWPjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_WYXNWPJBXX>(json);
            ES_WHYL_WYXNWPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_WYXNWPBLL.SaveES_WHYL_WYXNWPJBXX(jcxx, ES_WHYL_WYXNWPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_WHYL_WYXNWPJBXX()
        {
            string ES_WHYL_WYXNWPJBXXID = Request["ES_WHYL_WYXNWPJBXXID"];
            object result = ES_WHYL_WYXNWPBLL.LoadES_WHYL_WYXNWPJBXX(ES_WHYL_WYXNWPJBXXID);
            return Json(result);
        }
    }
}