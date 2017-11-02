using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJC_JZFWController : BaseController
    {
        public IZXJC_JZFWBLL ZXJC_JZFWBLL { get; set; }

        public ActionResult ZXJC_JZFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZXJC_JZFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JZFWJBXX ZXJC_JZFWjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JZFWJBXX>(json);
            ZXJC_JZFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JZFWBLL.SaveZXJC_JZFWJBXX(jcxx, ZXJC_JZFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_JZFWJBXX()
        {
            string ZXJC_JZFWJBXXID = Request["ZXJC_JZFWJBXXID"];
            object result = ZXJC_JZFWBLL.LoadZXJC_JZFWJBXX(ZXJC_JZFWJBXXID);
            return Json(result);
        }
    }
}