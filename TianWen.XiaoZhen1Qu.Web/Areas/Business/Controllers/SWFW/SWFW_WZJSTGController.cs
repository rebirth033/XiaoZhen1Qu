using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_WZJSTGController : BaseController
    {
        public ISWFW_WZJSTGBLL SWFW_WZJSTGBLL { get; set; }

        public ActionResult SWFW_WZJSTG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_WZJSTGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_WZJSTGJBXX SWFW_WZJSTGjbxx = JsonHelper.ConvertJsonToObject<SWFW_WZJSTGJBXX>(json);
            SWFW_WZJSTGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_WZJSTGBLL.SaveSWFW_WZJSTGJBXX(jcxx, SWFW_WZJSTGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_WZJSTGJBXX()
        {
            string SWFW_WZJSTGJBXXID = Request["SWFW_WZJSTGJBXXID"];
            object result = SWFW_WZJSTGBLL.LoadSWFW_WZJSTGJBXX(SWFW_WZJSTGJBXXID);
            return Json(result);
        }
    }
}