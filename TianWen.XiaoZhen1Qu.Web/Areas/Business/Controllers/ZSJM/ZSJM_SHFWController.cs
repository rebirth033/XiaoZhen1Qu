using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_SHFWController : BaseController
    {
        public IZSJM_SHFWBLL ZSJM_SHFWBLL { get; set; }

        public ActionResult ZSJM_SHFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_SHFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_SHFWJBXX ZSJM_SHFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_SHFWJBXX>(json);
            ZSJM_SHFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_SHFWBLL.SaveZSJM_SHFWJBXX(jcxx, ZSJM_SHFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_SHFWJBXX()
        {
            string ZSJM_SHFWJBXXID = Request["ZSJM_SHFWJBXXID"];
            object result = ZSJM_SHFWBLL.LoadZSJM_SHFWJBXX(ZSJM_SHFWJBXXID);
            return Json(result);
        }
    }
}