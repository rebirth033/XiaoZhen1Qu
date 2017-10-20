using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CL_ZXCDDCSLCController : BaseController
    {
        public ICL_ZXCDDCSLCBLL CL_ZXCDDCSLCBLL { get; set; }

        public ActionResult CL_ZXCDDCSLC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CL_ZXCDDCSLCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CL_ZXCDDCSLCBLL.GetLBQCByLBID(jcxx.LBID);
            CL_ZXCDDCSLCJBXX CL_ZXCDDCSLCjbxx = JsonHelper.ConvertJsonToObject<CL_ZXCDDCSLCJBXX>(json);
            CL_ZXCDDCSLCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_ZXCDDCSLCBLL.SaveCL_ZXCDDCSLCJBXX(jcxx, CL_ZXCDDCSLCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCL_ZXCDDCSLCJBXX()
        {
            string CL_ZXCDDCSLCJBXXID = Request["CL_ZXCDDCSLCJBXXID"];
            object result = CL_ZXCDDCSLCBLL.LoadCL_ZXCDDCSLCJBXX(CL_ZXCDDCSLCJBXXID);
            return Json(result);
        }
    }
}