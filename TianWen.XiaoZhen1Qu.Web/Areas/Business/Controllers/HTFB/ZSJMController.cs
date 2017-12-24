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
        public IZSJM_BLL ZSJM_BLL { get; set; }

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
        public ActionResult ZSJM_LS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZSJM_HBCP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBZSJM_CYJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_CYJBXX ZSJM_CYjbxx = JsonHelper.ConvertJsonToObject<ZSJM_CYJBXX>(json);
            ZSJM_CYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_CYJBXX(jcxx, ZSJM_CYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_FZXBJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_FZXBJBXX ZSJM_FZXBjbxx = JsonHelper.ConvertJsonToObject<ZSJM_FZXBJBXX>(json);
            ZSJM_FZXBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_FZXBJBXX(jcxx, ZSJM_FZXBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JCJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JCJBXX ZSJM_JCjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JCJBXX>(json);
            ZSJM_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_JCJBXX(jcxx, ZSJM_JCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JJHBJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JJHBJBXX ZSJM_JJHBjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JJHBJBXX>(json);
            ZSJM_JJHBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_JJHBJBXX(jcxx, ZSJM_JJHBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JXJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JXJBXX ZSJM_JXjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JXJBXX>(json);
            ZSJM_JXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_JXJBXX(jcxx, ZSJM_JXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_JYPXJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_JYPXJBXX ZSJM_JYPXjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JYPXJBXX>(json);
            ZSJM_JYPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_JYPXJBXX(jcxx, ZSJM_JYPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_LPXSPJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_LPXSPJBXX ZSJM_LPXSPjbxx = JsonHelper.ConvertJsonToObject<ZSJM_LPXSPJBXX>(json);
            ZSJM_LPXSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_LPXSPJBXX(jcxx, ZSJM_LPXSPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_MRBJJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_MRBJJBXX ZSJM_MRBJjbxx = JsonHelper.ConvertJsonToObject<ZSJM_MRBJJBXX>(json);
            ZSJM_MRBJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_MRBJJBXX(jcxx, ZSJM_MRBJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_NYJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_NYJBXX ZSJM_NYjbxx = JsonHelper.ConvertJsonToObject<ZSJM_NYJBXX>(json);
            ZSJM_NYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_NYJBXX(jcxx, ZSJM_NYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_QCFWJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_QCFWJBXX ZSJM_QCFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_QCFWJBXX>(json);
            ZSJM_QCFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_QCFWJBXX(jcxx, ZSJM_QCFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_SHFWJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_SHFWJBXX ZSJM_SHFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_SHFWJBXX>(json);
            ZSJM_SHFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_SHFWJBXX(jcxx, ZSJM_SHFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_TSJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_TSJBXX ZSJM_TSjbxx = JsonHelper.ConvertJsonToObject<ZSJM_TSJBXX>(json);
            ZSJM_TSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_TSJBXX(jcxx, ZSJM_TSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_WLFWJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_WLFWJBXX ZSJM_WLFWjbxx = JsonHelper.ConvertJsonToObject<ZSJM_WLFWJBXX>(json);
            ZSJM_WLFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_WLFWJBXX(jcxx, ZSJM_WLFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_WTMYETJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_WTMYETJBXX ZSJM_WTMYETjbxx = JsonHelper.ConvertJsonToObject<ZSJM_WTMYETJBXX>(json);
            ZSJM_WTMYETjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_WTMYETJBXX(jcxx, ZSJM_WTMYETjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_LSJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_LSJBXX ZSJM_LSjbxx = JsonHelper.ConvertJsonToObject<ZSJM_LSJBXX>(json);
            ZSJM_LSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_LSJBXX(jcxx, ZSJM_LSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZSJM_HBCPJBXX()
        {
            YHJBXX yhjbxx = ZSJM_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_HBCPJBXX ZSJM_HBCPjbxx = JsonHelper.ConvertJsonToObject<ZSJM_HBCPJBXX>(json);
            ZSJM_HBCPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_BLL.SaveZSJM_HBCPJBXX(jcxx, ZSJM_HBCPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_CYJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_CYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_FZXBJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_FZXBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JCJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_JCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JJHBJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_JJHBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JXJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_JXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_JYPXJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_JYPXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_LPXSPJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_LPXSPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_MRBJJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_MRBJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_NYJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_NYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_QCFWJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_QCFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_SHFWJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_SHFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_TSJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_TSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_WLFWJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_WLFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_WTMYETJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_WTMYETJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_LSJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_LSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZSJM_HBCPJBXX()
        {
            string ID = Request["ID"];
            object result = ZSJM_BLL.LoadZSJM_HBCPJBXX(ID);
            return Json(result);
        }
    }
}