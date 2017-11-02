using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_ZHFWController : BaseController
    {
        public ISWFW_ZHFWBLL SWFW_ZHFWBLL { get; set; }

        public ActionResult SWFW_ZHFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_ZHFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZHFWJBXX SWFW_ZHFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZHFWJBXX>(json);
            SWFW_ZHFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZHFWBLL.SaveSWFW_ZHFWJBXX(jcxx, SWFW_ZHFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_ZHFWJBXX()
        {
            string SWFW_ZHFWJBXXID = Request["SWFW_ZHFWJBXXID"];
            object result = SWFW_ZHFWBLL.LoadSWFW_ZHFWJBXX(SWFW_ZHFWJBXXID);
            return Json(result);
        }
    }
}