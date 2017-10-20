using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CL_HCController : BaseController
    {
        public ICL_HCBLL CL_HCBLL { get; set; }

        public ActionResult CL_HC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CL_HCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CL_HCBLL.GetLBQCByLBID(jcxx.LBID);
            CL_HCJBXX CL_HCjbxx = JsonHelper.ConvertJsonToObject<CL_HCJBXX>(json);
            CL_HCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_HCBLL.SaveCL_HCJBXX(jcxx, CL_HCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCL_HCJBXX()
        {
            string CL_HCJBXXID = Request["CL_HCJBXXID"];
            object result = CL_HCBLL.LoadCL_HCJBXX(CL_HCJBXXID);
            return Json(result);
        }
    }
}