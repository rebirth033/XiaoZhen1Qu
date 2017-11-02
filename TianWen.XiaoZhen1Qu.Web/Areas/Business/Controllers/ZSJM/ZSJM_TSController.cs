using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_TSController : BaseController
    {
        public IZSJM_TSBLL ZSJM_TSBLL { get; set; }

        public ActionResult ZSJM_TS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_TSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_TSJBXX ZSJM_TSjbxx = JsonHelper.ConvertJsonToObject<ZSJM_TSJBXX>(json);
            ZSJM_TSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_TSBLL.SaveZSJM_TSJBXX(jcxx, ZSJM_TSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_TSJBXX()
        {
            string ZSJM_TSJBXXID = Request["ZSJM_TSJBXXID"];
            object result = ZSJM_TSBLL.LoadZSJM_TSJBXX(ZSJM_TSJBXXID);
            return Json(result);
        }
    }
}