﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJMController : BaseController
    {
        public IZSJM_CYBLL ZSJM_CYBLL { get; set; }
        public IZSJM_FZXBBLL ZSJM_FZXBBLL { get; set; }
        public IZSJM_JCBLL ZSJM_JCBLL { get; set; }
        public IZSJM_JJHBBLL ZSJM_JJHBBLL { get; set; }
        public IZSJM_JXBLL ZSJM_JXBLL { get; set; }
        public IZSJM_JYPXBLL ZSJM_JYPXBLL { get; set; }
        public IZSJM_LPXSPBLL ZSJM_LPXSPBLL { get; set; }
        public IZSJM_MRBJBLL ZSJM_MRBJBLL { get; set; }
        public IZSJM_NYBLL ZSJM_NYBLL { get; set; }
        public IZSJM_QCFWBLL ZSJM_QCFWBLL { get; set; }
        public IZSJM_SHFWBLL ZSJM_SHFWBLL { get; set; }
        public IZSJM_TSBLL ZSJM_TSBLL { get; set; }
        public IZSJM_WLFWBLL ZSJM_WLFWBLL { get; set; }
        public IZSJM_WTMYETBLL ZSJM_WTMYETBLL { get; set; }

        public ActionResult ZSJM_CY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_FZXB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_JC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_JJHB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_JX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_JYPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_LPXSP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_MRBJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_NY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_QCFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_SHFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_TS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_WLFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_WTMYET()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBZSJM_CYJBXX()
        {
            YHJBXX yhjbxx = ZSJM_CYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_CYJBXX ZSJM_CYjbxx = JsonHelper.ConvertJsonToObject<ZSJM_CYJBXX>(json);
            ZSJM_CYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_CYBLL.SaveZSJM_CYJBXX(jcxx, ZSJM_CYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_FZXBJBXX()
        {
            YHJBXX yhjbxx = ZSJM_FZXBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_FZXBJBXX ZSJM_FZXBjbxx = JsonHelper.ConvertJsonToObject<ZSJM_FZXBJBXX>(json);
            ZSJM_FZXBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_FZXBBLL.SaveZSJM_FZXBJBXX(jcxx, ZSJM_FZXBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JCJBXX()
        {
            YHJBXX yhjbxx = ZSJM_JCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JCJBXX ZSJM_JCjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JCJBXX>(json);
            ZSJM_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JCBLL.SaveZSJM_JCJBXX(jcxx, ZSJM_JCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JJHBJBXX()
        {
            YHJBXX yhjbxx = ZSJM_JJHBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JJHBJBXX ZSJM_JJHBjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JJHBJBXX>(json);
            ZSJM_JJHBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JJHBBLL.SaveZSJM_JJHBJBXX(jcxx, ZSJM_JJHBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JXJBXX()
        {
            YHJBXX yhjbxx = ZSJM_JXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JXJBXX ZSJM_JXjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JXJBXX>(json);
            ZSJM_JXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JXBLL.SaveZSJM_JXJBXX(jcxx, ZSJM_JXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JYPXJBXX()
        {
            YHJBXX yhjbxx = ZSJM_JYPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JYPXJBXX ZSJM_JYPXjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JYPXJBXX>(json);
            ZSJM_JYPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JYPXBLL.SaveZSJM_JYPXJBXX(jcxx, ZSJM_JYPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_LPXSPJBXX()
        {
            YHJBXX yhjbxx = ZSJM_LPXSPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_LPXSPJBXX ZSJM_LPXSPjbxx = JsonHelper.ConvertJsonToObject<ZSJM_LPXSPJBXX>(json);
            ZSJM_LPXSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_LPXSPBLL.SaveZSJM_LPXSPJBXX(jcxx, ZSJM_LPXSPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_MRBJJBXX()
        {
            YHJBXX yhjbxx = ZSJM_MRBJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_MRBJJBXX ZSJM_MRBJjbxx = JsonHelper.ConvertJsonToObject<ZSJM_MRBJJBXX>(json);
            ZSJM_MRBJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_MRBJBLL.SaveZSJM_MRBJJBXX(jcxx, ZSJM_MRBJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_NYJBXX()
        {
            YHJBXX yhjbxx = ZSJM_NYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_NYJBXX ZSJM_NYjbxx = JsonHelper.ConvertJsonToObject<ZSJM_NYJBXX>(json);
            ZSJM_NYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_NYBLL.SaveZSJM_NYJBXX(jcxx, ZSJM_NYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_QCFWJBXX()
        {
            YHJBXX yhjbxx = ZSJM_QCFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_QCFWJBXX ZSJM_QCFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_QCFWJBXX>(json);
            ZSJM_QCFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_QCFWBLL.SaveZSJM_QCFWJBXX(jcxx, ZSJM_QCFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_SHFWJBXX()
        {
            YHJBXX yhjbxx = ZSJM_SHFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_SHFWJBXX ZSJM_SHFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_SHFWJBXX>(json);
            ZSJM_SHFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_SHFWBLL.SaveZSJM_SHFWJBXX(jcxx, ZSJM_SHFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_TSJBXX()
        {
            YHJBXX yhjbxx = ZSJM_TSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_TSJBXX ZSJM_TSjbxx = JsonHelper.ConvertJsonToObject<ZSJM_TSJBXX>(json);
            ZSJM_TSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_TSBLL.SaveZSJM_TSJBXX(jcxx, ZSJM_TSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_WLFWJBXX()
        {
            YHJBXX yhjbxx = ZSJM_WLFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_WLFWJBXX ZSJM_WLFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_WLFWJBXX>(json);
            ZSJM_WLFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_WLFWBLL.SaveZSJM_WLFWJBXX(jcxx, ZSJM_WLFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_WTMYETJBXX()
        {
            YHJBXX yhjbxx = ZSJM_WTMYETBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_WTMYETJBXX ZSJM_WTMYETjbxx = JsonHelper.ConvertJsonToObject<ZSJM_WTMYETJBXX>(json);
            ZSJM_WTMYETjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_WTMYETBLL.SaveZSJM_WTMYETJBXX(jcxx, ZSJM_WTMYETjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_CYJBXX()
        {
            string ZSJM_CYJBXXID = Request["ZSJM_CYJBXXID"];
            object result = ZSJM_CYBLL.LoadZSJM_CYJBXX(ZSJM_CYJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_FZXBJBXX()
        {
            string ZSJM_FZXBJBXXID = Request["ZSJM_FZXBJBXXID"];
            object result = ZSJM_FZXBBLL.LoadZSJM_FZXBJBXX(ZSJM_FZXBJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JCJBXX()
        {
            string ZSJM_JCJBXXID = Request["ZSJM_JCJBXXID"];
            object result = ZSJM_JCBLL.LoadZSJM_JCJBXX(ZSJM_JCJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JJHBJBXX()
        {
            string ZSJM_JJHBJBXXID = Request["ZSJM_JJHBJBXXID"];
            object result = ZSJM_JJHBBLL.LoadZSJM_JJHBJBXX(ZSJM_JJHBJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JXJBXX()
        {
            string ZSJM_JXJBXXID = Request["ZSJM_JXJBXXID"];
            object result = ZSJM_JXBLL.LoadZSJM_JXJBXX(ZSJM_JXJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JYPXJBXX()
        {
            string ZSJM_JYPXJBXXID = Request["ZSJM_JYPXJBXXID"];
            object result = ZSJM_JYPXBLL.LoadZSJM_JYPXJBXX(ZSJM_JYPXJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_LPXSPJBXX()
        {
            string ZSJM_LPXSPJBXXID = Request["ZSJM_LPXSPJBXXID"];
            object result = ZSJM_LPXSPBLL.LoadZSJM_LPXSPJBXX(ZSJM_LPXSPJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_MRBJJBXX()
        {
            string ZSJM_MRBJJBXXID = Request["ZSJM_MRBJJBXXID"];
            object result = ZSJM_MRBJBLL.LoadZSJM_MRBJJBXX(ZSJM_MRBJJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_NYJBXX()
        {
            string ZSJM_NYJBXXID = Request["ZSJM_NYJBXXID"];
            object result = ZSJM_NYBLL.LoadZSJM_NYJBXX(ZSJM_NYJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_QCFWJBXX()
        {
            string ZSJM_QCFWJBXXID = Request["ZSJM_QCFWJBXXID"];
            object result = ZSJM_QCFWBLL.LoadZSJM_QCFWJBXX(ZSJM_QCFWJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_SHFWJBXX()
        {
            string ZSJM_SHFWJBXXID = Request["ZSJM_SHFWJBXXID"];
            object result = ZSJM_SHFWBLL.LoadZSJM_SHFWJBXX(ZSJM_SHFWJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_TSJBXX()
        {
            string ZSJM_TSJBXXID = Request["ZSJM_TSJBXXID"];
            object result = ZSJM_TSBLL.LoadZSJM_TSJBXX(ZSJM_TSJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_WLFWJBXX()
        {
            string ZSJM_WLFWJBXXID = Request["ZSJM_WLFWJBXXID"];
            object result = ZSJM_WLFWBLL.LoadZSJM_WLFWJBXX(ZSJM_WLFWJBXXID);
            return Json(result);
        }
        public JsonResult LoadZSJM_WTMYETJBXX()
        {
            string ZSJM_WTMYETJBXXID = Request["ZSJM_WTMYETJBXXID"];
            object result = ZSJM_WTMYETBLL.LoadZSJM_WTMYETJBXX(ZSJM_WTMYETJBXXID);
            return Json(result);
        }
    }
}