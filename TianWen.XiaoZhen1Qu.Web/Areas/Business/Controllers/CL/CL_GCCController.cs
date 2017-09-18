using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CL_GCCController : BaseController
    {
        public ICL_GCCBLL CL_GCCBLL { get; set; }

        public ActionResult CL_GCC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CL_GCCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CL_GCCBLL.GetLBQCByLBID(jcxx.LBID);
            CL_GCCJBXX CL_GCCjbxx = JsonHelper.ConvertJsonToObject<CL_GCCJBXX>(json);
            CL_GCCjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_GCCBLL.SaveCL_GCCJBXX(jcxx, CL_GCCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCL_GCCJBXX()
        {
            string CL_GCCJBXXID = Request["CL_GCCJBXXID"];
            object result = CL_GCCBLL.LoadCL_GCCJBXX(CL_GCCJBXXID);
            return Json(result);
        }
    }
}