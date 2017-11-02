using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_JCController : BaseController
    {
        public IZSJM_JCBLL ZSJM_JCBLL { get; set; }

        public ActionResult ZSJM_JC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_JCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JCJBXX ZSJM_JCjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JCJBXX>(json);
            ZSJM_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JCBLL.SaveZSJM_JCJBXX(jcxx, ZSJM_JCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_JCJBXX()
        {
            string ZSJM_JCJBXXID = Request["ZSJM_JCJBXXID"];
            object result = ZSJM_JCBLL.LoadZSJM_JCJBXX(ZSJM_JCJBXXID);
            return Json(result);
        }
    }
}