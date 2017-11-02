using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CL_JCController : BaseController
    {
        public ICL_JCBLL CL_JCBLL { get; set; }

        public ActionResult CL_JC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CL_JCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_JCJBXX CL_JCjbxx = JsonHelper.ConvertJsonToObject<CL_JCJBXX>(json);
            CL_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_JCBLL.SaveCL_JCJBXX(jcxx, CL_JCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCL_JCJBXX()
        {
            string CL_JCJBXXID = Request["CL_JCJBXXID"];
            object result = CL_JCBLL.LoadCL_JCJBXX(CL_JCJBXXID);
            return Json(result);
        }
    }
}