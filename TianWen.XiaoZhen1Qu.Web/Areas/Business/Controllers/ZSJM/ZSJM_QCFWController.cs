using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_QCFWController : BaseController
    {
        public IZSJM_QCFWBLL ZSJM_QCFWBLL { get; set; }

        public ActionResult ZSJM_QCFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_QCFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_QCFWJBXX ZSJM_QCFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_QCFWJBXX>(json);
            ZSJM_QCFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_QCFWBLL.SaveZSJM_QCFWJBXX(jcxx, ZSJM_QCFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_QCFWJBXX()
        {
            string ZSJM_QCFWJBXXID = Request["ZSJM_QCFWJBXXID"];
            object result = ZSJM_QCFWBLL.LoadZSJM_QCFWJBXX(ZSJM_QCFWJBXXID);
            return Json(result);
        }
    }
}