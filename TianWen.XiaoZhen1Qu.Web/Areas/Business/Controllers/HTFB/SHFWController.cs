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

        public ActionResult SHFW_DJSJWP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_GHSPNJYC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_JX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_QCMRZS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_QCPL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_QCWXBY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_ZC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_BJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_BJQX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_BMYS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_BZMD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_GDSTQL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_KSHSXS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SHPS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_DNWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_FWWXDK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_JDWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_JJWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SHFW_SJSMWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBSHFW_DJSJWPJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_DJSJWPJBXX SHFW_DJSJWPJBXX = JsonHelper.ConvertJsonToObject<SHFW_DJSJWPJBXX>(json);
            SHFW_DJSJWPJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_DJSJWPJBXX(jcxx, SHFW_DJSJWPJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_GHSPNJYCJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_GHSPNJYCJBXX SHFW_GHSPNJYCJBXX = JsonHelper.ConvertJsonToObject<SHFW_GHSPNJYCJBXX>(json);
            SHFW_GHSPNJYCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_GHSPNJYCJBXX(jcxx, SHFW_GHSPNJYCJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_JXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_JXJBXX SHFW_JXJBXX = JsonHelper.ConvertJsonToObject<SHFW_JXJBXX>(json);
            SHFW_JXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_JXJBXX(jcxx, SHFW_JXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_QCGZFHJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_QCGZFHJBXX SHFW_QCGZFHJBXX = JsonHelper.ConvertJsonToObject<SHFW_QCGZFHJBXX>(json);
            SHFW_QCGZFHJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_QCGZFHJBXX(jcxx, SHFW_QCGZFHJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_QCMRZSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_QCMRZSJBXX SHFW_QCMRZSJBXX = JsonHelper.ConvertJsonToObject<SHFW_QCMRZSJBXX>(json);
            SHFW_QCMRZSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_QCMRZSJBXX(jcxx, SHFW_QCMRZSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_QCPLJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_QCPLJBXX SHFW_QCPLJBXX = JsonHelper.ConvertJsonToObject<SHFW_QCPLJBXX>(json);
            SHFW_QCPLJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_QCPLJBXX(jcxx, SHFW_QCPLJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_QCWXBYJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_QCWXBYJBXX SHFW_QCWXBYJBXX = JsonHelper.ConvertJsonToObject<SHFW_QCWXBYJBXX>(json);
            SHFW_QCWXBYJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_QCWXBYJBXX(jcxx, SHFW_QCWXBYJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_ZCJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_ZCJBXX SHFW_ZCJBXX = JsonHelper.ConvertJsonToObject<SHFW_ZCJBXX>(json);
            SHFW_ZCJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_ZCJBXX(jcxx, SHFW_ZCJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BJJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BJJBXX SHFW_BJJBXX = JsonHelper.ConvertJsonToObject<SHFW_BJJBXX>(json);
            SHFW_BJJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BJJBXX(jcxx, SHFW_BJJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BJQXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BJQXJBXX SHFW_BJQXJBXX = JsonHelper.ConvertJsonToObject<SHFW_BJQXJBXX>(json);
            SHFW_BJQXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BJQXJBXX(jcxx, SHFW_BJQXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BMYSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BMYSJBXX SHFW_BMYSJBXX = JsonHelper.ConvertJsonToObject<SHFW_BMYSJBXX>(json);
            SHFW_BMYSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BMYSJBXX(jcxx, SHFW_BMYSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BZMDJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BZMDJBXX SHFW_BZMDJBXX = JsonHelper.ConvertJsonToObject<SHFW_BZMDJBXX>(json);
            SHFW_BZMDJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BZMDJBXX(jcxx, SHFW_BZMDJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_GDSTQLJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_GDSTQLJBXX SHFW_GDSTQLJBXX = JsonHelper.ConvertJsonToObject<SHFW_GDSTQLJBXX>(json);
            SHFW_GDSTQLJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_GDSTQLJBXX(jcxx, SHFW_GDSTQLJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_KSHSXSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_KSHSXSJBXX SHFW_KSHSXSJBXX = JsonHelper.ConvertJsonToObject<SHFW_KSHSXSJBXX>(json);
            SHFW_KSHSXSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_KSHSXSJBXX(jcxx, SHFW_KSHSXSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHPSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHPSJBXX SHFW_SHPSJBXX = JsonHelper.ConvertJsonToObject<SHFW_SHPSJBXX>(json);
            SHFW_SHPSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHPSJBXX(jcxx, SHFW_SHPSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_DNWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_DNWXJBXX SHFW_DNWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_DNWXJBXX>(json);
            SHFW_DNWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_DNWXJBXX(jcxx, SHFW_DNWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_FWWXDKJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_FWWXDKJBXX SHFW_FWWXDKJBXX = JsonHelper.ConvertJsonToObject<SHFW_FWWXDKJBXX>(json);
            SHFW_FWWXDKJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_FWWXDKJBXX(jcxx, SHFW_FWWXDKJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_JDWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_JDWXJBXX SHFW_JDWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_JDWXJBXX>(json);
            SHFW_JDWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_JDWXJBXX(jcxx, SHFW_JDWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_JJWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_JJWXJBXX SHFW_JJWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_JJWXJBXX>(json);
            SHFW_JJWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_JJWXJBXX(jcxx, SHFW_JJWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SJSMWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SJSMWXJBXX SHFW_SJSMWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_SJSMWXJBXX>(json);
            SHFW_SJSMWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SJSMWXJBXX(jcxx, SHFW_SJSMWXJBXX, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_DJSJWPJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_DJSJWPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_GHSPNJYCJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_GHSPNJYCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_JXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_JXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_QCGZFHJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_QCGZFHJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_QCMRZSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_QCMRZSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_QCPLJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_QCPLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_QCWXBYJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_QCWXBYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_ZCJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_ZCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_BJJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_BJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_BZMDJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_BZMDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_BMYSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_BMYSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_BJQXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_BJQXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_GDSTQLJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_GDSTQLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_KSHSXSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_KSHSXSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SHPSJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SHPSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_DNWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_DNWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_FWWXDKJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_FWWXDKJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_JDWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_JDWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_JJWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_JJWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSHFW_SJSMWXJBXX()
        {
            string ID = Request["ID"];
            object result = SHFW_BLL.LoadSHFW_SJSMWXJBXX(ID);
            return Json(result);
        }
    }
}