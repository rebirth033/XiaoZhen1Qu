using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_WLFWController : BaseController
    {
        public IZSJM_WLFWBLL ZSJM_WLFWBLL { get; set; }

        public ActionResult ZSJM_WLFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_WLFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + ZSJM_WLFWBLL.GetLBQCByLBID(jcxx.LBID);
            ZSJM_WLFWJBXX ZSJM_WLFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_WLFWJBXX>(json);
            ZSJM_WLFWjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_WLFWBLL.SaveZSJM_WLFWJBXX(jcxx, ZSJM_WLFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_WLFWJBXX()
        {
            string ZSJM_WLFWJBXXID = Request["ZSJM_WLFWJBXXID"];
            object result = ZSJM_WLFWBLL.LoadZSJM_WLFWJBXX(ZSJM_WLFWJBXXID);
            return Json(result);
        }
    }
}