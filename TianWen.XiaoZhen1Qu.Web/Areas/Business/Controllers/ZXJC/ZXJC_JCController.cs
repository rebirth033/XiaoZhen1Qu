using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJC_JCController : BaseController
    {
        public IZXJC_JCBLL ZXJC_JCBLL { get; set; }

        public ActionResult ZXJC_JC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZXJC_JCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JCJBXX ZXJC_JCjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JCJBXX>(json);
            ZXJC_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JCBLL.SaveZXJC_JCJBXX(jcxx, ZXJC_JCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_JCJBXX()
        {
            string ZXJC_JCJBXXID = Request["ZXJC_JCJBXXID"];
            object result = ZXJC_JCBLL.LoadZXJC_JCJBXX(ZXJC_JCJBXXID);
            return Json(result);
        }
    }
}