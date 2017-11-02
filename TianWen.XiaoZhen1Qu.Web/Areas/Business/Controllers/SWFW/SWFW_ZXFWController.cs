using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_ZXFWController : BaseController
    {
        public ISWFW_ZXFWBLL SWFW_ZXFWBLL { get; set; }

        public ActionResult SWFW_ZXFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_ZXFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZXFWJBXX SWFW_ZXFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZXFWJBXX>(json);
            SWFW_ZXFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZXFWBLL.SaveSWFW_ZXFWJBXX(jcxx, SWFW_ZXFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_ZXFWJBXX()
        {
            string SWFW_ZXFWJBXXID = Request["SWFW_ZXFWJBXXID"];
            object result = SWFW_ZXFWBLL.LoadSWFW_ZXFWJBXX(SWFW_ZXFWJBXXID);
            return Json(result);
        }
    }
}