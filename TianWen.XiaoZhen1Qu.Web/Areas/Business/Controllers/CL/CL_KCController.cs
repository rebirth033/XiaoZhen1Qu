using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CL_KCController : BaseController
    {
        public ICL_KCBLL CL_KCBLL { get; set; }

        public ActionResult CL_KC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CL_KCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CL_KCBLL.GetLBQCByLBID(jcxx.LBID);
            CL_KCJBXX CL_KCjbxx = JsonHelper.ConvertJsonToObject<CL_KCJBXX>(json);
            CL_KCjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_KCBLL.SaveCL_KCJBXX(jcxx, CL_KCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCL_KCJBXX()
        {
            string CL_KCJBXXID = Request["CL_KCJBXXID"];
            object result = CL_KCBLL.LoadCL_KCJBXX(CL_KCJBXXID);
            return Json(result);
        }
    }
}