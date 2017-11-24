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
    public class SHFWController : BaseController
    {
        public ISHFW_BLL SHFW_BLL { get; set; }

        public ActionResult SHFW_CLFW_DJSJWP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_GHSPNJYC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_JX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_QCGZFH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_QCMRZS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_QCPL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_QCWXBY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_CLFW_ZC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_BJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_BJQX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_BMYS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_BZMD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_GDSTQL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_KSHSXS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHFW_SHPS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_WXFW_DNWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_WXFW_FWWXDK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_WXFW_JDWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_WXFW_JJWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_WXFW_SJSMWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_DJSJWPJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_DJSJWPJBXX SHFW_CLFW_DJSJWPjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_DJSJWPJBXX>(json);
            SHFW_CLFW_DJSJWPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_DJSJWPJBXX(jcxx, SHFW_CLFW_DJSJWPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_GHSPNJYCJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_GHSPNJYCJBXX>(json);
            SHFW_CLFW_GHSPNJYCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_GHSPNJYCJBXX(jcxx, SHFW_CLFW_GHSPNJYCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_JXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_JXJBXX SHFW_CLFW_JXjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_JXJBXX>(json);
            SHFW_CLFW_JXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_JXJBXX(jcxx, SHFW_CLFW_JXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCGZFHJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCGZFHJBXX>(json);
            SHFW_CLFW_QCGZFHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_QCGZFHJBXX(jcxx, SHFW_CLFW_QCGZFHjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCMRZSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCMRZSJBXX>(json);
            SHFW_CLFW_QCMRZSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_QCMRZSJBXX(jcxx, SHFW_CLFW_QCMRZSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCPLJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCPLJBXX>(json);
            SHFW_CLFW_QCPLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_QCPLJBXX(jcxx, SHFW_CLFW_QCPLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCWXBYJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCWXBYJBXX SHFW_CLFW_QCWXBYjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCWXBYJBXX>(json);
            SHFW_CLFW_QCWXBYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_QCWXBYJBXX(jcxx, SHFW_CLFW_QCWXBYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_ZCJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_ZCJBXX SHFW_CLFW_ZCjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_ZCJBXX>(json);
            SHFW_CLFW_ZCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_CLFW_ZCJBXX(jcxx, SHFW_CLFW_ZCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BJJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BJJBXX SHFW_SHFW_BJjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BJJBXX>(json);
            SHFW_SHFW_BJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_BJJBXX(jcxx, SHFW_SHFW_BJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BJQXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BJQXJBXX SHFW_SHFW_BJQXjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BJQXJBXX>(json);
            SHFW_SHFW_BJQXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_BJQXJBXX(jcxx, SHFW_SHFW_BJQXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BMYSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BMYSJBXX SHFW_SHFW_BMYSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BMYSJBXX>(json);
            SHFW_SHFW_BMYSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_BMYSJBXX(jcxx, SHFW_SHFW_BMYSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BZMDJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BZMDJBXX>(json);
            SHFW_SHFW_BZMDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_BZMDJBXX(jcxx, SHFW_SHFW_BZMDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_GDSTQLJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_GDSTQLJBXX>(json);
            SHFW_SHFW_GDSTQLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_GDSTQLJBXX(jcxx, SHFW_SHFW_GDSTQLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_KSHSXSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_KSHSXSJBXX SHFW_SHFW_KSHSXSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_KSHSXSJBXX>(json);
            SHFW_SHFW_KSHSXSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_KSHSXSJBXX(jcxx, SHFW_SHFW_KSHSXSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_SHPSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_SHPSJBXX SHFW_SHFW_SHPSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_SHPSJBXX>(json);
            SHFW_SHFW_SHPSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHFW_SHPSJBXX(jcxx, SHFW_SHFW_SHPSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_DNWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_DNWXJBXX>(json);
            SHFW_WXFW_DNWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_WXFW_DNWXJBXX(jcxx, SHFW_WXFW_DNWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_FWWXDKJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_FWWXDKJBXX>(json);
            SHFW_WXFW_FWWXDKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_WXFW_FWWXDKJBXX(jcxx, SHFW_WXFW_FWWXDKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_JDWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_JDWXJBXX SHFW_WXFW_JDWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_JDWXJBXX>(json);
            SHFW_WXFW_JDWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_WXFW_JDWXJBXX(jcxx, SHFW_WXFW_JDWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_JJWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_JJWXJBXX SHFW_WXFW_JJWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_JJWXJBXX>(json);
            SHFW_WXFW_JJWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_WXFW_JJWXJBXX(jcxx, SHFW_WXFW_JJWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_SJSMWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_SJSMWXJBXX SHFW_WXFW_SJSMWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_SJSMWXJBXX>(json);
            SHFW_WXFW_SJSMWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_WXFW_SJSMWXJBXX(jcxx, SHFW_WXFW_SJSMWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_DJSJWPJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_DJSJWPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_GHSPNJYCJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_GHSPNJYCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_JXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_JXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCGZFHJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_QCGZFHJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCMRZSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_QCMRZSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCPLJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_QCPLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCWXBYJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_QCWXBYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_ZCJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_CLFW_ZCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BJJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_BJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BZMDJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_BZMDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BMYSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_BMYSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BJQXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_BJQXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_GDSTQLJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_GDSTQLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_KSHSXSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_KSHSXSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_SHPSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHFW_SHPSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_DNWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_WXFW_DNWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_FWWXDKJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_WXFW_FWWXDKJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_JDWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_WXFW_JDWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_JJWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_WXFW_JJWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_SJSMWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_WXFW_SJSMWXJBXX(ID);
            return Json(result);
        }
    }
}