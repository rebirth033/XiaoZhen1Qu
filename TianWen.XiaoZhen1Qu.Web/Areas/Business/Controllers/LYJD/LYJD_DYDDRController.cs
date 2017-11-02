using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_DYDDRController : BaseController
    {
        public ILYJD_DYDDRBLL LYJD_DYDDRBLL { get; set; }

        public ActionResult LYJD_DYDDR()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_DYDDRBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_DYDDRJBXX LYJD_DYDDRjbxx = JsonHelper.ConvertJsonToObject<LYJD_DYDDRJBXX>(json);
            LYJD_DYDDRjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_DYDDRBLL.SaveLYJD_DYDDRJBXX(jcxx, LYJD_DYDDRjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_DYDDRJBXX()
        {
            string LYJD_DYDDRJBXXID = Request["LYJD_DYDDRJBXXID"];
            object result = LYJD_DYDDRBLL.LoadLYJD_DYDDRJBXX(LYJD_DYDDRJBXXID);
            return Json(result);
        }
    }
}