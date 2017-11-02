using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_CYController : BaseController
    {
        public IZSJM_CYBLL ZSJM_CYBLL { get; set; }

        public ActionResult ZSJM_CY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_CYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_CYJBXX ZSJM_CYjbxx = JsonHelper.ConvertJsonToObject<ZSJM_CYJBXX>(json);
            ZSJM_CYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_CYBLL.SaveZSJM_CYJBXX(jcxx, ZSJM_CYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_CYJBXX()
        {
            string ZSJM_CYJBXXID = Request["ZSJM_CYJBXXID"];
            object result = ZSJM_CYBLL.LoadZSJM_CYJBXX(ZSJM_CYJBXXID);
            return Json(result);
        }
    }
}