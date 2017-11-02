using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_ZBYController : BaseController
    {
        public ILYJD_ZBYBLL LYJD_ZBYBLL { get; set; }

        public ActionResult LYJD_ZBY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_ZBYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string fwjs = Request["FWJS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_ZBYJBXX LYJD_ZBYjbxx = JsonHelper.ConvertJsonToObject<LYJD_ZBYJBXX>(json);
            LYJD_ZBYjbxx.FWJS = fwjs;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_ZBYBLL.SaveLYJD_ZBYJBXX(jcxx, LYJD_ZBYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_ZBYJBXX()
        {
            string LYJD_ZBYJBXXID = Request["LYJD_ZBYJBXXID"];
            object result = LYJD_ZBYBLL.LoadLYJD_ZBYJBXX(LYJD_ZBYJBXXID);
            return Json(result);
        }
    }
}