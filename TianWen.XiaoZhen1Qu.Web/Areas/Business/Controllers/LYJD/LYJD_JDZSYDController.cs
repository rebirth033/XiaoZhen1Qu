using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_JDZSYDController : BaseController
    {
        public ILYJD_JDZSYDBLL LYJD_JDZSYDBLL { get; set; }

        public ActionResult LYJD_JDZSYD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_JDZSYDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_JDZSYDJBXX LYJD_JDZSYDjbxx = JsonHelper.ConvertJsonToObject<LYJD_JDZSYDJBXX>(json);
            LYJD_JDZSYDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_JDZSYDBLL.SaveLYJD_JDZSYDJBXX(jcxx, LYJD_JDZSYDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_JDZSYDJBXX()
        {
            string LYJD_JDZSYDJBXXID = Request["LYJD_JDZSYDJBXXID"];
            object result = LYJD_JDZSYDBLL.LoadLYJD_JDZSYDJBXX(LYJD_JDZSYDJBXXID);
            return Json(result);
        }
    }
}