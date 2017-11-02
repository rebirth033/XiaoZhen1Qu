using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_CWKJPGController : BaseController
    {
        public ISWFW_CWKJPGBLL SWFW_CWKJPGBLL { get; set; }

        public ActionResult SWFW_CWKJPG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_CWKJPGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_CWKJPGJBXX SWFW_CWKJPGjbxx = JsonHelper.ConvertJsonToObject<SWFW_CWKJPGJBXX>(json);
            SWFW_CWKJPGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_CWKJPGBLL.SaveSWFW_CWKJPGJBXX(jcxx, SWFW_CWKJPGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_CWKJPGJBXX()
        {
            string SWFW_CWKJPGJBXXID = Request["SWFW_CWKJPGJBXXID"];
            object result = SWFW_CWKJPGBLL.LoadSWFW_CWKJPGJBXX(SWFW_CWKJPGJBXXID);
            return Json(result);
        }
    }
}