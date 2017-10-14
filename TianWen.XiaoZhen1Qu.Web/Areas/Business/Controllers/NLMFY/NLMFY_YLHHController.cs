using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_YLHHController : BaseController
    {
        public INLMFY_YLHHBLL NLMFY_YLHHBLL { get; set; }

        public ActionResult NLMFY_YLHH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_YLHHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_YLHHBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_YLHHJBXX NLMFY_YLHHjbxx = JsonHelper.ConvertJsonToObject<NLMFY_YLHHJBXX>(json);
            NLMFY_YLHHjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_YLHHBLL.SaveNLMFY_YLHHJBXX(jcxx, NLMFY_YLHHjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_YLHHJBXX()
        {
            string NLMFY_YLHHJBXXID = Request["NLMFY_YLHHJBXXID"];
            object result = NLMFY_YLHHBLL.LoadNLMFY_YLHHJBXX(NLMFY_YLHHJBXXID);
            return Json(result);
        }
    }
}