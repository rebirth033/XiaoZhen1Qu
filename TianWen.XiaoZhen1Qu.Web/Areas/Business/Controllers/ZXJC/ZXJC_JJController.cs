using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJC_JJController : BaseController
    {
        public IZXJC_JJBLL ZXJC_JJBLL { get; set; }

        public ActionResult ZXJC_JJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZXJC_JJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JJJBXX ZXJC_JJjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JJJBXX>(json);
            ZXJC_JJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JJBLL.SaveZXJC_JJJBXX(jcxx, ZXJC_JJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_JJJBXX()
        {
            string ZXJC_JJJBXXID = Request["ZXJC_JJJBXXID"];
            object result = ZXJC_JJBLL.LoadZXJC_JJJBXX(ZXJC_JJJBXXID);
            return Json(result);
        }
    }
}