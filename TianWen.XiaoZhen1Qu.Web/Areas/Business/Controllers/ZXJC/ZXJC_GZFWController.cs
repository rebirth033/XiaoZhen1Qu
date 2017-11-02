using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJC_GZFWController : BaseController
    {
        public IZXJC_GZFWBLL ZXJC_GZFWBLL { get; set; }

        public ActionResult ZXJC_GZFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZXJC_GZFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_GZFWJBXX ZXJC_GZFWjbxx = JsonHelper.ConvertJsonToObject<ZXJC_GZFWJBXX>(json);
            ZXJC_GZFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_GZFWBLL.SaveZXJC_GZFWJBXX(jcxx, ZXJC_GZFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_GZFWJBXX()
        {
            string ZXJC_GZFWJBXXID = Request["ZXJC_GZFWJBXXID"];
            object result = ZXJC_GZFWBLL.LoadZXJC_GZFWJBXX(ZXJC_GZFWJBXXID);
            return Json(result);
        }
    }
}