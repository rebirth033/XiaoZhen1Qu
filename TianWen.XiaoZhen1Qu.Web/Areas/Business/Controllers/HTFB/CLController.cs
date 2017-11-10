using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Interface.HTFB;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CLController : BaseController
    {
        public ICL_BLL CL_BLL { get; set; }

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
            YHJBXX yhjbxx = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_GCCJBXX CL_GCCjbxx = JsonHelper.ConvertJsonToObject<CL_GCCJBXX>(json);
            CL_GCCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_GCCJBXX(jcxx, CL_GCCjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBCL_HCJBXX()
        {
            YHJBXX yhjbxx = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_HCJBXX CL_HCjbxx = JsonHelper.ConvertJsonToObject<CL_HCJBXX>(json);
            CL_HCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_HCJBXX(jcxx, CL_HCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_JCJBXX()
        {
            YHJBXX yhjbxx = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_JCJBXX CL_JCjbxx = JsonHelper.ConvertJsonToObject<CL_JCJBXX>(json);
            CL_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_JCJBXX(jcxx, CL_JCjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBCL_KCJBXX()
        {
            YHJBXX yhjbxx = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_KCJBXX CL_KCjbxx = JsonHelper.ConvertJsonToObject<CL_KCJBXX>(json);
            CL_KCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_KCJBXX(jcxx, CL_KCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_MTCJBXX()
        {
            YHJBXX yhjbxx = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_MTCJBXX CL_MTCjbxx = JsonHelper.ConvertJsonToObject<CL_MTCJBXX>(json);
            CL_MTCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_MTCJBXX(jcxx, CL_MTCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_ZXCDDCSLCJBXX()
        {
            YHJBXX yhjbxx = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CL_ZXCDDCSLCJBXX CL_ZXCDDCSLCjbxx = JsonHelper.ConvertJsonToObject<CL_ZXCDDCSLCJBXX>(json);
            CL_ZXCDDCSLCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_ZXCDDCSLCJBXX(jcxx, CL_ZXCDDCSLCjbxx, photos);
            return Json(result);
        }
        public JsonResult LoadCL_GCCJBXX()
        {
            string ID = Request["ID"];
            object result = CL_BLL.LoadCL_GCCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCL_HCJBXX()
        {
            string ID = Request["ID"];
            object result = CL_BLL.LoadCL_HCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCL_JCJBXX()
        {
            string ID = Request["ID"];
            object result = CL_BLL.LoadCL_JCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCL_KCJBXX()
        {
            string ID = Request["ID"];
            object result = CL_BLL.LoadCL_KCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCL_MTCJBXX()
        {
            string ID = Request["ID"];
            object result = CL_BLL.LoadCL_MTCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCL_ZXCDDCSLCJBXX()
        {
            string ID = Request["ID"];
            object result = CL_BLL.LoadCL_ZXCDDCSLCJBXX(ID);
            return Json(result);
        }
    }
}