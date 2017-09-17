using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CL_MTCController : BaseController
    {
        public ICL_MTCBLL CL_MTCBLL { get; set; }

        public ActionResult CL_MTC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CL_MTCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CL_MTCBLL.GetLBQCByLBID(jcxx.LBID);
            CL_MTCJBXX CL_MTCjbxx = JsonHelper.ConvertJsonToObject<CL_MTCJBXX>(json);
            CL_MTCjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_MTCBLL.SaveCL_MTCJBXX(jcxx, CL_MTCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCL_MTCJBXX()
        {
            string CL_MTCJBXXID = Request["CL_MTCJBXXID"];
            object result = CL_MTCBLL.LoadCL_MTCJBXX(CL_MTCJBXXID);
            return Json(result);
        }
    }
}