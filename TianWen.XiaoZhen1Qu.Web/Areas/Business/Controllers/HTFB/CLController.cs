using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CLController : BaseController
    {
        public ICL_GCCBLL CL_GCCBLL { get; set; }
        public ICL_HCBLL CL_HCBLL { get; set; }
        public ICL_JCBLL CL_JCBLL { get; set; }
        public ICL_KCBLL CL_KCBLL { get; set; }
        public ICL_MTCBLL CL_MTCBLL { get; set; }
        public ICL_ZXCDDCSLCBLL CL_ZXCDDCSLCBLL { get; set; }

        public ActionResult CL_GCC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CL_HC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CL_JC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CL_KC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CL_MTC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CL_ZXCDDCSLC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBCL_GCCJBXX()
        {
            YHJBXX yhjbxx = CL_GCCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_GCCJBXX CL_GCCjbxx = JsonHelper.ConvertJsonToObject<CL_GCCJBXX>(json);
            CL_GCCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_GCCBLL.SaveCL_GCCJBXX(jcxx, CL_GCCjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBCL_HCJBXX()
        {
            YHJBXX yhjbxx = CL_HCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_HCJBXX CL_HCjbxx = JsonHelper.ConvertJsonToObject<CL_HCJBXX>(json);
            CL_HCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_HCBLL.SaveCL_HCJBXX(jcxx, CL_HCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_JCJBXX()
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

        [ValidateInput(false)]
        public JsonResult FBCL_KCJBXX()
        {
            YHJBXX yhjbxx = CL_KCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_KCJBXX CL_KCjbxx = JsonHelper.ConvertJsonToObject<CL_KCJBXX>(json);
            CL_KCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_KCBLL.SaveCL_KCJBXX(jcxx, CL_KCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_MTCJBXX()
        {
            YHJBXX yhjbxx = CL_MTCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_MTCJBXX CL_MTCjbxx = JsonHelper.ConvertJsonToObject<CL_MTCJBXX>(json);
            CL_MTCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_MTCBLL.SaveCL_MTCJBXX(jcxx, CL_MTCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_ZXCDDCSLCJBXX()
        {
            YHJBXX yhjbxx = CL_ZXCDDCSLCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_ZXCDDCSLCJBXX CL_ZXCDDCSLCjbxx = JsonHelper.ConvertJsonToObject<CL_ZXCDDCSLCJBXX>(json);
            CL_ZXCDDCSLCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_ZXCDDCSLCBLL.SaveCL_ZXCDDCSLCJBXX(jcxx, CL_ZXCDDCSLCjbxx, photos);
            return Json(result);
        }
        public JsonResult LoadCL_GCCJBXX()
        {
            string CL_GCCJBXXID = Request["CL_GCCJBXXID"];
            object result = CL_GCCBLL.LoadCL_GCCJBXX(CL_GCCJBXXID);
            return Json(result);
        }
        public JsonResult LoadCL_HCJBXX()
        {
            string CL_HCJBXXID = Request["CL_HCJBXXID"];
            object result = CL_HCBLL.LoadCL_HCJBXX(CL_HCJBXXID);
            return Json(result);
        }
        public JsonResult LoadCL_JCJBXX()
        {
            string CL_JCJBXXID = Request["CL_JCJBXXID"];
            object result = CL_JCBLL.LoadCL_JCJBXX(CL_JCJBXXID);
            return Json(result);
        }
        public JsonResult LoadCL_KCJBXX()
        {
            string CL_KCJBXXID = Request["CL_KCJBXXID"];
            object result = CL_KCBLL.LoadCL_KCJBXX(CL_KCJBXXID);
            return Json(result);
        }
        public JsonResult LoadCL_MTCJBXX()
        {
            string CL_MTCJBXXID = Request["CL_MTCJBXXID"];
            object result = CL_MTCBLL.LoadCL_MTCJBXX(CL_MTCJBXXID);
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