using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_WTMYETController : BaseController
    {
        public IZSJM_WTMYETBLL ZSJM_WTMYETBLL { get; set; }

        public ActionResult ZSJM_WTMYET()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_WTMYETBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_WTMYETJBXX ZSJM_WTMYETjbxx = JsonHelper.ConvertJsonToObject<ZSJM_WTMYETJBXX>(json);
            ZSJM_WTMYETjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_WTMYETBLL.SaveZSJM_WTMYETJBXX(jcxx, ZSJM_WTMYETjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_WTMYETJBXX()
        {
            string ZSJM_WTMYETJBXXID = Request["ZSJM_WTMYETJBXXID"];
            object result = ZSJM_WTMYETBLL.LoadZSJM_WTMYETJBXX(ZSJM_WTMYETJBXXID);
            return Json(result);
        }
    }
}