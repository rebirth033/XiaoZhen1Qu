using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJC_FWGZController : BaseController
    {
        public IZXJC_FWGZBLL ZXJC_FWGZBLL { get; set; }

        public ActionResult ZXJC_FWGZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZXJC_FWGZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_FWGZJBXX ZXJC_FWGZjbxx = JsonHelper.ConvertJsonToObject<ZXJC_FWGZJBXX>(json);
            ZXJC_FWGZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_FWGZBLL.SaveZXJC_FWGZJBXX(jcxx, ZXJC_FWGZjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_FWGZJBXX()
        {
            string ZXJC_FWGZJBXXID = Request["ZXJC_FWGZJBXXID"];
            object result = ZXJC_FWGZBLL.LoadZXJC_FWGZJBXX(ZXJC_FWGZJBXXID);
            return Json(result);
        }
    }
}