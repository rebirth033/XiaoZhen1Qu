using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_BXController : BaseController
    {
        public ISWFW_BXBLL SWFW_BXBLL { get; set; }

        public ActionResult SWFW_BX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_BXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_BXJBXX SWFW_BXjbxx = JsonHelper.ConvertJsonToObject<SWFW_BXJBXX>(json);
            SWFW_BXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BXBLL.SaveSWFW_BXJBXX(jcxx, SWFW_BXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_BXJBXX()
        {
            string SWFW_BXJBXXID = Request["SWFW_BXJBXXID"];
            object result = SWFW_BXBLL.LoadSWFW_BXJBXX(SWFW_BXJBXXID);
            return Json(result);
        }
    }
}