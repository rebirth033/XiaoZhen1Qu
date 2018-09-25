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
        public ActionResult CL_GCC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_HC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_JC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_KC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_MTC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_ZXC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_DDC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_SLC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_DJ() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_QCGZFH() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_GHSPNJYC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_JX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["XZQDM"] = Session["XZQDM"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_QCMRZS() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_QCPL() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_QCWXBY() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_QCPJ() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult CL_ZC() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }

        [ValidateInput(false)]
        public JsonResult FBCL_GCCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_GCCJBXX CL_GCCjbxx = JsonHelper.ConvertJsonToObject<CL_GCCJBXX>(json);
            CL_GCCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_GCCJBXX(jcxx, CL_GCCjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBCL_HCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_HCJBXX CL_HCjbxx = JsonHelper.ConvertJsonToObject<CL_HCJBXX>(json);
            CL_HCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_HCJBXX(jcxx, CL_HCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_JCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_JCJBXX CL_JCjbxx = JsonHelper.ConvertJsonToObject<CL_JCJBXX>(json);
            CL_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_JCJBXX(jcxx, CL_JCjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBCL_KCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_KCJBXX CL_KCjbxx = JsonHelper.ConvertJsonToObject<CL_KCJBXX>(json);
            CL_KCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_KCJBXX(jcxx, CL_KCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_MTCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_MTCJBXX CL_MTCjbxx = JsonHelper.ConvertJsonToObject<CL_MTCJBXX>(json);
            CL_MTCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_MTCJBXX(jcxx, CL_MTCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_ZXCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_ZXCJBXX CL_ZXCJBXX = JsonHelper.ConvertJsonToObject<CL_ZXCJBXX>(json);
            CL_ZXCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_ZXCJBXX(jcxx, CL_ZXCJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_DDCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_DDCJBXX CL_DDCJBXX = JsonHelper.ConvertJsonToObject<CL_DDCJBXX>(json);
            CL_DDCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_DDCJBXX(jcxx, CL_DDCJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_SLCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_SLCJBXX CL_SLCJBXX = JsonHelper.ConvertJsonToObject<CL_SLCJBXX>(json);
            CL_SLCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_SLCJBXX(jcxx, CL_SLCJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_DJJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_DJJBXX CL_DJJBXX = JsonHelper.ConvertJsonToObject<CL_DJJBXX>(json);
            CL_DJJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_DJJBXX(jcxx, CL_DJJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_GHSPNJYCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_GHSPNJYCJBXX CL_GHSPNJYCJBXX = JsonHelper.ConvertJsonToObject<CL_GHSPNJYCJBXX>(json);
            CL_GHSPNJYCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_GHSPNJYCJBXX(jcxx, CL_GHSPNJYCJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_JXJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_JXJBXX CL_JXJBXX = JsonHelper.ConvertJsonToObject<CL_JXJBXX>(json);
            CL_JXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_JXJBXX(jcxx, CL_JXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_QCGZFHJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_QCGZFHJBXX CL_QCGZFHJBXX = JsonHelper.ConvertJsonToObject<CL_QCGZFHJBXX>(json);
            CL_QCGZFHJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_QCGZFHJBXX(jcxx, CL_QCGZFHJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_QCMRZSJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_QCMRZSJBXX CL_QCMRZSJBXX = JsonHelper.ConvertJsonToObject<CL_QCMRZSJBXX>(json);
            CL_QCMRZSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_QCMRZSJBXX(jcxx, CL_QCMRZSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_QCPLJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_QCPLJBXX CL_QCPLJBXX = JsonHelper.ConvertJsonToObject<CL_QCPLJBXX>(json);
            CL_QCPLJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_QCPLJBXX(jcxx, CL_QCPLJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_QCWXBYJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_QCWXBYJBXX CL_QCWXBYJBXX = JsonHelper.ConvertJsonToObject<CL_QCWXBYJBXX>(json);
            CL_QCWXBYJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_QCWXBYJBXX(jcxx, CL_QCWXBYJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_QCPJJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_QCPJJBXX CL_QCPJJBXX = JsonHelper.ConvertJsonToObject<CL_QCPJJBXX>(json);
            CL_QCPJJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_QCPJJBXX(jcxx, CL_QCPJJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCL_ZCJBXX()
        {
            YHJBXX YHJBXX = CL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            CL_ZCJBXX CL_ZCJBXX = JsonHelper.ConvertJsonToObject<CL_ZCJBXX>(json);
            CL_ZCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CL_BLL.SaveCL_ZCJBXX(jcxx, CL_ZCJBXX, photos);
            return Json(result);
        }

        public JsonResult LoadCL_GCCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_GCCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_HCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_HCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_JCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_JCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_KCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_KCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_MTCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_MTCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_ZXCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_ZXCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_DDCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_DDCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_SLCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_SLCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_DJJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_DJJBXX(ID); return Json(result); }
        public JsonResult LoadCL_GHSPNJYCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_GHSPNJYCJBXX(ID); return Json(result); }
        public JsonResult LoadCL_JXJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_JXJBXX(ID); return Json(result); }
        public JsonResult LoadCL_QCGZFHJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_QCGZFHJBXX(ID); return Json(result); }
        public JsonResult LoadCL_QCMRZSJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_QCMRZSJBXX(ID); return Json(result); }
        public JsonResult LoadCL_QCPLJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_QCPLJBXX(ID); return Json(result); }
        public JsonResult LoadCL_QCWXBYJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_QCWXBYJBXX(ID); return Json(result); }
        public JsonResult LoadCL_QCPJJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_QCPJJBXX(ID); return Json(result); }
        public JsonResult LoadCL_ZCJBXX() { string ID = Request["ID"]; object result = CL_BLL.LoadCL_ZCJBXX(ID); return Json(result); }
    }
}