using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_LPDZController : BaseController
    {
        public ISWFW_LPDZBLL SWFW_LPDZBLL { get; set; }

        public ActionResult SWFW_LPDZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_LPDZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_LPDZJBXX SWFW_LPDZjbxx = JsonHelper.ConvertJsonToObject<SWFW_LPDZJBXX>(json);
            SWFW_LPDZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_LPDZBLL.SaveSWFW_LPDZJBXX(jcxx, SWFW_LPDZjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_LPDZJBXX()
        {
            string SWFW_LPDZJBXXID = Request["SWFW_LPDZJBXXID"];
            object result = SWFW_LPDZBLL.LoadSWFW_LPDZJBXX(SWFW_LPDZJBXXID);
            return Json(result);
        }
    }
}