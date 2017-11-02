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
        public ISHFW_CLFW_DJSJWPBLL SHFW_CLFW_DJSJWPBLL { get; set; }
        public ISHFW_CLFW_GHSPNJYCBLL SHFW_CLFW_GHSPNJYCBLL { get; set; }
        public ISHFW_CLFW_JXBLL SHFW_CLFW_JXBLL { get; set; }
        public ISHFW_CLFW_QCGZFHBLL SHFW_CLFW_QCGZFHBLL { get; set; }
        public ISHFW_CLFW_QCMRZSBLL SHFW_CLFW_QCMRZSBLL { get; set; }
        public ISHFW_CLFW_QCPLBLL SHFW_CLFW_QCPLBLL { get; set; }
        public ISHFW_CLFW_QCWXBYBLL SHFW_CLFW_QCWXBYBLL { get; set; }
        public ISHFW_CLFW_ZCBLL SHFW_CLFW_ZCBLL { get; set; }
        public ISHFW_SHFW_BJBLL SHFW_SHFW_BJBLL { get; set; }
        public ISHFW_SHFW_BJQXBLL SHFW_SHFW_BJQXBLL { get; set; }
        public ISHFW_SHFW_BMYSBLL SHFW_SHFW_BMYSBLL { get; set; }
        public ISHFW_SHFW_BZMDBLL SHFW_SHFW_BZMDBLL { get; set; }
        public ISHFW_SHFW_GDSTQLBLL SHFW_SHFW_GDSTQLBLL { get; set; }
        public ISHFW_SHFW_KSHSXSBLL SHFW_SHFW_KSHSXSBLL { get; set; }
        public ISHFW_SHFW_QMFSSMBLL SHFW_SHFW_QMFSSMBLL { get; set; }
        public ISHFW_SHFW_SHPSBLL SHFW_SHFW_SHPSBLL { get; set; }
        public ISHFW_WXFW_DNWXBLL SHFW_WXFW_DNWXBLL { get; set; }
        public ISHFW_WXFW_FWWXDKBLL SHFW_WXFW_FWWXDKBLL { get; set; }
        public ISHFW_WXFW_JDWXBLL SHFW_WXFW_JDWXBLL { get; set; }
        public ISHFW_WXFW_JJWXBLL SHFW_WXFW_JJWXBLL { get; set; }
        public ISHFW_WXFW_SJSMWXBLL SHFW_WXFW_SJSMWXBLL { get; set; }

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
        public ActionResult SHFW_SHFW_QMFSSM()
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
            YHJBXX yhjbxx = SHFW_CLFW_DJSJWPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_DJSJWPJBXX SHFW_CLFW_DJSJWPjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_DJSJWPJBXX>(json);
            SHFW_CLFW_DJSJWPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_DJSJWPBLL.SaveSHFW_CLFW_DJSJWPJBXX(jcxx, SHFW_CLFW_DJSJWPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_GHSPNJYCJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_GHSPNJYCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_GHSPNJYCJBXX>(json);
            SHFW_CLFW_GHSPNJYCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_GHSPNJYCBLL.SaveSHFW_CLFW_GHSPNJYCJBXX(jcxx, SHFW_CLFW_GHSPNJYCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_JXJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_JXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_JXJBXX SHFW_CLFW_JXjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_JXJBXX>(json);
            SHFW_CLFW_JXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_JXBLL.SaveSHFW_CLFW_JXJBXX(jcxx, SHFW_CLFW_JXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCGZFHJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCGZFHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCGZFHJBXX>(json);
            SHFW_CLFW_QCGZFHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCGZFHBLL.SaveSHFW_CLFW_QCGZFHJBXX(jcxx, SHFW_CLFW_QCGZFHjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCMRZSJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCMRZSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCMRZSJBXX>(json);
            SHFW_CLFW_QCMRZSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCMRZSBLL.SaveSHFW_CLFW_QCMRZSJBXX(jcxx, SHFW_CLFW_QCMRZSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCPLJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCPLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCPLJBXX>(json);
            SHFW_CLFW_QCPLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCPLBLL.SaveSHFW_CLFW_QCPLJBXX(jcxx, SHFW_CLFW_QCPLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_QCWXBYJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_QCWXBYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_QCWXBYJBXX SHFW_CLFW_QCWXBYjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_QCWXBYJBXX>(json);
            SHFW_CLFW_QCWXBYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_QCWXBYBLL.SaveSHFW_CLFW_QCWXBYJBXX(jcxx, SHFW_CLFW_QCWXBYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_CLFW_ZCJBXX()
        {
            YHJBXX yhjbxx = SHFW_CLFW_ZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_CLFW_ZCJBXX SHFW_CLFW_ZCjbxx = JsonHelper.ConvertJsonToObject<SHFW_CLFW_ZCJBXX>(json);
            SHFW_CLFW_ZCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_CLFW_ZCBLL.SaveSHFW_CLFW_ZCJBXX(jcxx, SHFW_CLFW_ZCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BJJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BJJBXX SHFW_SHFW_BJjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BJJBXX>(json);
            SHFW_SHFW_BJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BJBLL.SaveSHFW_SHFW_BJJBXX(jcxx, SHFW_SHFW_BJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BJQXJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BJQXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BJQXJBXX SHFW_SHFW_BJQXjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BJQXJBXX>(json);
            SHFW_SHFW_BJQXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BJQXBLL.SaveSHFW_SHFW_BJQXJBXX(jcxx, SHFW_SHFW_BJQXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BMYSJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BMYSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BMYSJBXX SHFW_SHFW_BMYSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BMYSJBXX>(json);
            SHFW_SHFW_BMYSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BMYSBLL.SaveSHFW_SHFW_BMYSJBXX(jcxx, SHFW_SHFW_BMYSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_BZMDJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_BZMDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_BZMDJBXX>(json);
            SHFW_SHFW_BZMDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_BZMDBLL.SaveSHFW_SHFW_BZMDJBXX(jcxx, SHFW_SHFW_BZMDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_GDSTQLJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_GDSTQLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_GDSTQLJBXX>(json);
            SHFW_SHFW_GDSTQLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_GDSTQLBLL.SaveSHFW_SHFW_GDSTQLJBXX(jcxx, SHFW_SHFW_GDSTQLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_KSHSXSJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_KSHSXSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_KSHSXSJBXX SHFW_SHFW_KSHSXSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_KSHSXSJBXX>(json);
            SHFW_SHFW_KSHSXSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_KSHSXSBLL.SaveSHFW_SHFW_KSHSXSJBXX(jcxx, SHFW_SHFW_KSHSXSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_QMFSSMJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_QMFSSMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_QMFSSMJBXX SHFW_SHFW_QMFSSMjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_QMFSSMJBXX>(json);
            SHFW_SHFW_QMFSSMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_QMFSSMBLL.SaveSHFW_SHFW_QMFSSMJBXX(jcxx, SHFW_SHFW_QMFSSMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHFW_SHPSJBXX()
        {
            YHJBXX yhjbxx = SHFW_SHFW_SHPSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHFW_SHPSJBXX SHFW_SHFW_SHPSjbxx = JsonHelper.ConvertJsonToObject<SHFW_SHFW_SHPSJBXX>(json);
            SHFW_SHFW_SHPSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_SHFW_SHPSBLL.SaveSHFW_SHFW_SHPSJBXX(jcxx, SHFW_SHFW_SHPSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_DNWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_WXFW_DNWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_DNWXJBXX>(json);
            SHFW_WXFW_DNWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_DNWXBLL.SaveSHFW_WXFW_DNWXJBXX(jcxx, SHFW_WXFW_DNWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_FWWXDKJBXX()
        {
            YHJBXX yhjbxx = SHFW_WXFW_FWWXDKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_FWWXDKJBXX>(json);
            SHFW_WXFW_FWWXDKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_FWWXDKBLL.SaveSHFW_WXFW_FWWXDKJBXX(jcxx, SHFW_WXFW_FWWXDKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_JDWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_WXFW_JDWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_JDWXJBXX SHFW_WXFW_JDWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_JDWXJBXX>(json);
            SHFW_WXFW_JDWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_JDWXBLL.SaveSHFW_WXFW_JDWXJBXX(jcxx, SHFW_WXFW_JDWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_JJWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_WXFW_JJWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_JJWXJBXX SHFW_WXFW_JJWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_JJWXJBXX>(json);
            SHFW_WXFW_JJWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_JJWXBLL.SaveSHFW_WXFW_JJWXJBXX(jcxx, SHFW_WXFW_JJWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_WXFW_SJSMWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_WXFW_SJSMWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_WXFW_SJSMWXJBXX SHFW_WXFW_SJSMWXjbxx = JsonHelper.ConvertJsonToObject<SHFW_WXFW_SJSMWXJBXX>(json);
            SHFW_WXFW_SJSMWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_WXFW_SJSMWXBLL.SaveSHFW_WXFW_SJSMWXJBXX(jcxx, SHFW_WXFW_SJSMWXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_CLFW_DJSJWPJBXX()
        {
            string SHFW_CLFW_DJSJWPJBXXID = Request["SHFW_CLFW_DJSJWPJBXXID"];
            object result = SHFW_CLFW_DJSJWPBLL.LoadSHFW_CLFW_DJSJWPJBXX(SHFW_CLFW_DJSJWPJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_GHSPNJYCJBXX()
        {
            string SHFW_CLFW_GHSPNJYCJBXXID = Request["SHFW_CLFW_GHSPNJYCJBXXID"];
            object result = SHFW_CLFW_GHSPNJYCBLL.LoadSHFW_CLFW_GHSPNJYCJBXX(SHFW_CLFW_GHSPNJYCJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_JXJBXX()
        {
            string SHFW_CLFW_JXJBXXID = Request["SHFW_CLFW_JXJBXXID"];
            object result = SHFW_CLFW_JXBLL.LoadSHFW_CLFW_JXJBXX(SHFW_CLFW_JXJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCGZFHJBXX()
        {
            string SHFW_CLFW_QCGZFHJBXXID = Request["SHFW_CLFW_QCGZFHJBXXID"];
            object result = SHFW_CLFW_QCGZFHBLL.LoadSHFW_CLFW_QCGZFHJBXX(SHFW_CLFW_QCGZFHJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCMRZSJBXX()
        {
            string SHFW_CLFW_QCMRZSJBXXID = Request["SHFW_CLFW_QCMRZSJBXXID"];
            object result = SHFW_CLFW_QCMRZSBLL.LoadSHFW_CLFW_QCMRZSJBXX(SHFW_CLFW_QCMRZSJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCPLJBXX()
        {
            string SHFW_CLFW_QCPLJBXXID = Request["SHFW_CLFW_QCPLJBXXID"];
            object result = SHFW_CLFW_QCPLBLL.LoadSHFW_CLFW_QCPLJBXX(SHFW_CLFW_QCPLJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_QCWXBYJBXX()
        {
            string SHFW_CLFW_QCWXBYJBXXID = Request["SHFW_CLFW_QCWXBYJBXXID"];
            object result = SHFW_CLFW_QCWXBYBLL.LoadSHFW_CLFW_QCWXBYJBXX(SHFW_CLFW_QCWXBYJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_CLFW_ZCJBXX()
        {
            string SHFW_CLFW_ZCJBXXID = Request["SHFW_CLFW_ZCJBXXID"];
            object result = SHFW_CLFW_ZCBLL.LoadSHFW_CLFW_ZCJBXX(SHFW_CLFW_ZCJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BJJBXX()
        {
            string SHFW_SHFW_BJJBXXID = Request["SHFW_SHFW_BJJBXXID"];
            object result = SHFW_SHFW_BJBLL.LoadSHFW_SHFW_BJJBXX(SHFW_SHFW_BJJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BZMDJBXX()
        {
            string SHFW_SHFW_BZMDJBXXID = Request["SHFW_SHFW_BZMDJBXXID"];
            object result = SHFW_SHFW_BZMDBLL.LoadSHFW_SHFW_BZMDJBXX(SHFW_SHFW_BZMDJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BMYSJBXX()
        {
            string SHFW_SHFW_BMYSJBXXID = Request["SHFW_SHFW_BMYSJBXXID"];
            object result = SHFW_SHFW_BMYSBLL.LoadSHFW_SHFW_BMYSJBXX(SHFW_SHFW_BMYSJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_BJQXJBXX()
        {
            string SHFW_SHFW_BJQXJBXXID = Request["SHFW_SHFW_BJQXJBXXID"];
            object result = SHFW_SHFW_BJQXBLL.LoadSHFW_SHFW_BJQXJBXX(SHFW_SHFW_BJQXJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_GDSTQLJBXX()
        {
            string SHFW_SHFW_GDSTQLJBXXID = Request["SHFW_SHFW_GDSTQLJBXXID"];
            object result = SHFW_SHFW_GDSTQLBLL.LoadSHFW_SHFW_GDSTQLJBXX(SHFW_SHFW_GDSTQLJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_KSHSXSJBXX()
        {
            string SHFW_SHFW_KSHSXSJBXXID = Request["SHFW_SHFW_KSHSXSJBXXID"];
            object result = SHFW_SHFW_KSHSXSBLL.LoadSHFW_SHFW_KSHSXSJBXX(SHFW_SHFW_KSHSXSJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_QMFSSMJBXX()
        {
            string SHFW_SHFW_QMFSSMJBXXID = Request["SHFW_SHFW_QMFSSMJBXXID"];
            object result = SHFW_SHFW_QMFSSMBLL.LoadSHFW_SHFW_QMFSSMJBXX(SHFW_SHFW_QMFSSMJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHFW_SHPSJBXX()
        {
            string SHFW_SHFW_SHPSJBXXID = Request["SHFW_SHFW_SHPSJBXXID"];
            object result = SHFW_SHFW_SHPSBLL.LoadSHFW_SHFW_SHPSJBXX(SHFW_SHFW_SHPSJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_DNWXJBXX()
        {
            string SHFW_WXFW_DNWXJBXXID = Request["SHFW_WXFW_DNWXJBXXID"];
            object result = SHFW_WXFW_DNWXBLL.LoadSHFW_WXFW_DNWXJBXX(SHFW_WXFW_DNWXJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_FWWXDKJBXX()
        {
            string SHFW_WXFW_FWWXDKJBXXID = Request["SHFW_WXFW_FWWXDKJBXXID"];
            object result = SHFW_WXFW_FWWXDKBLL.LoadSHFW_WXFW_FWWXDKJBXX(SHFW_WXFW_FWWXDKJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_JDWXJBXX()
        {
            string SHFW_WXFW_JDWXJBXXID = Request["SHFW_WXFW_JDWXJBXXID"];
            object result = SHFW_WXFW_JDWXBLL.LoadSHFW_WXFW_JDWXJBXX(SHFW_WXFW_JDWXJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_JJWXJBXX()
        {
            string SHFW_WXFW_JJWXJBXXID = Request["SHFW_WXFW_JJWXJBXXID"];
            object result = SHFW_WXFW_JJWXBLL.LoadSHFW_WXFW_JJWXJBXX(SHFW_WXFW_JJWXJBXXID);
            return Json(result);
        }
        public JsonResult LoadSHFW_WXFW_SJSMWXJBXX()
        {
            string SHFW_WXFW_SJSMWXJBXXID = Request["SHFW_WXFW_SJSMWXJBXXID"];
            object result = SHFW_WXFW_SJSMWXBLL.LoadSHFW_WXFW_SJSMWXJBXX(SHFW_WXFW_SJSMWXJBXXID);
            return Json(result);
        }
    }
}