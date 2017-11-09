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
    public class ESController : BaseController
    {
        public IES_JDJJBG_BGSBBLL ES_JDJJBG_BGSBBLL { get; set; }
        public IES_JDJJBG_ESJDBLL ES_JDJJBG_ESJDBLL { get; set; }
        public IES_JDJJBG_ESJJBLL ES_JDJJBG_ESJJBLL { get; set; }
        public IES_JDJJBG_JJRYBLL ES_JDJJBG_JJRYBLL { get; set; }
        public IES_MYFZMR_FZXMXBBLL ES_MYFZMR_FZXMXBBLL { get; set; }
        public IES_MYFZMR_MRBJBLL ES_MYFZMR_MRBJBLL { get; set; }
        public IES_MYFZMR_MYETYPWJBLL ES_MYFZMR_MYETYPWJBLL { get; set; }
        public IES_QTES_CRYPBLL ES_QTES_CRYPBLL { get; set; }
        public IES_QTES_ESSBBLL ES_QTES_ESSBBLL { get; set; }
        public IES_SJSM_BJBDNBLL ES_SJSM_BJBDNBLL { get; set; }
        public IES_SJSM_ESSJBLL ES_SJSM_ESSJBLL { get; set; }
        public IES_SJSM_PBDNBLL ES_SJSM_PBDNBLL { get; set; }
        public IES_SJSM_SMCPBLL ES_SJSM_SMCPBLL { get; set; }
        public IES_SJSM_TSJBLL ES_SJSM_TSJBLL { get; set; }
        public IES_WHYL_TSYXRJBLL ES_WHYL_TSYXRJBLL { get; set; }
        public IES_WHYL_WTHWYQBLL ES_WHYL_WTHWYQBLL { get; set; }
        public IES_WHYL_WYXNWPBLL ES_WHYL_WYXNWPBLL { get; set; }
        public IES_WHYL_YSPSCPBLL ES_WHYL_YSPSCPBLL { get; set; }
        public ActionResult ES_JDJJBG_BGSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_JDJJBG_ESJD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_JDJJBG_ESJJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_JDJJBG_JJRY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_MYFZMR_FZXMXB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_MYFZMR_MRBJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_MYFZMR_MYETYPWJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_QTES_CRYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        public ActionResult ES_QTES_ESSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_SJSM_BJBDN()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_SJSM_ESSJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_SJSM_PBDN()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_SJSM_SMCP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_SJSM_TSJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_WHYL_TSYXRJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_WHYL_WTHWYQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_WHYL_WYXNWP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_WHYL_YSPSCP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBES_JDJJBG_BGSBJBXX()
        {
            YHJBXX yhjbxx = ES_JDJJBG_BGSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_JDJJBG_BGSBJBXX ES_JDJJBG_BGSBjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_BGSBJBXX>(json);
            ES_JDJJBG_BGSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_BGSBBLL.SaveES_JDJJBG_BGSBJBXX(jcxx, ES_JDJJBG_BGSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_JDJJBG_ESJDJBXX()
        {
            YHJBXX yhjbxx = ES_JDJJBG_ESJDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_JDJJBG_ESJDJBXX ES_JDJJBG_ESJDjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_ESJDJBXX>(json);
            ES_JDJJBG_ESJDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_ESJDBLL.SaveES_JDJJBG_ESJDJBXX(jcxx, ES_JDJJBG_ESJDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_JDJJBG_ESJJJBXX()
        {
            YHJBXX yhjbxx = ES_JDJJBG_ESJJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_JDJJBG_ESJJJBXX ES_JDJJBG_ESJJjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_ESJJJBXX>(json);
            ES_JDJJBG_ESJJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_ESJJBLL.SaveES_JDJJBG_ESJJJBXX(jcxx, ES_JDJJBG_ESJJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_JDJJBG_JJRYJBXX()
        {
            YHJBXX yhjbxx = ES_JDJJBG_JJRYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_JDJJBG_JJRYJBXX ES_JDJJBG_JJRYjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_JJRYJBXX>(json);
            ES_JDJJBG_JJRYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_JJRYBLL.SaveES_JDJJBG_JJRYJBXX(jcxx, ES_JDJJBG_JJRYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_MYFZMR_FZXMXBJBXX()
        {
            YHJBXX yhjbxx = ES_MYFZMR_FZXMXBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_MYFZMR_FZXMXBJBXX ES_MYFZMR_FZXMXBjbxx = JsonHelper.ConvertJsonToObject<ES_MYFZMR_FZXMXBJBXX>(json);
            ES_MYFZMR_FZXMXBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_MYFZMR_FZXMXBBLL.SaveES_MYFZMR_FZXMXBJBXX(jcxx, ES_MYFZMR_FZXMXBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_MYFZMR_MRBJJBXX()
        {
            YHJBXX yhjbxx = ES_MYFZMR_MRBJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_MYFZMR_MRBJJBXX ES_MYFZMR_MRBJjbxx = JsonHelper.ConvertJsonToObject<ES_MYFZMR_MRBJJBXX>(json);
            ES_MYFZMR_MRBJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_MYFZMR_MRBJBLL.SaveES_MYFZMR_MRBJJBXX(jcxx, ES_MYFZMR_MRBJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_MYFZMR_MYETYPWJJBXX()
        {
            YHJBXX yhjbxx = ES_MYFZMR_MYETYPWJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_MYFZMR_MYETYPWJJBXX ES_MYFZMR_MYETYPWJjbxx = JsonHelper.ConvertJsonToObject<ES_MYFZMR_MYETYPWJJBXX>(json);
            ES_MYFZMR_MYETYPWJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_MYFZMR_MYETYPWJBLL.SaveES_MYFZMR_MYETYPWJJBXX(jcxx, ES_MYFZMR_MYETYPWJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_QTES_CRYPJBXX()
        {
            YHJBXX yhjbxx = ES_QTES_CRYPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_QTES_CRYPJBXX ES_QTES_CRYPJBXX = JsonHelper.ConvertJsonToObject<ES_QTES_CRYPJBXX>(json);
            ES_QTES_CRYPJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_QTES_CRYPBLL.SaveES_QTES_CRYPJBXX(jcxx, ES_QTES_CRYPJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_QTES_ESSBJBXX()
        {
            YHJBXX yhjbxx = ES_QTES_ESSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_QTES_ESSBJBXX ES_QTES_ESSBJBXX = JsonHelper.ConvertJsonToObject<ES_QTES_ESSBJBXX>(json);
            ES_QTES_ESSBJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_QTES_ESSBBLL.SaveES_QTES_ESSBJBXX(jcxx, ES_QTES_ESSBJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_SJSM_BJBDNJBXX()
        {
            YHJBXX yhjbxx = ES_SJSM_BJBDNBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_BJBDNJBXX ES_SJSM_BJBDNjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_BJBDNJBXX>(json);
            ES_SJSM_BJBDNjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_BJBDNBLL.SaveES_SJSM_BJBDNJBXX(jcxx, ES_SJSM_BJBDNjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_SJSM_ESSJJBXX()
        {
            YHJBXX yhjbxx = ES_SJSM_ESSJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_ESSJJBXX ES_SJSM_ESSJjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_ESSJJBXX>(json);
            ES_SJSM_ESSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_ESSJBLL.SaveES_SJSM_ESSJJBXX(jcxx, ES_SJSM_ESSJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_SJSM_PBDNJBXX()
        {
            YHJBXX yhjbxx = ES_SJSM_PBDNBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_PBDNJBXX ES_SJSM_PBDNjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_PBDNJBXX>(json);
            ES_SJSM_PBDNjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_PBDNBLL.SaveES_SJSM_PBDNJBXX(jcxx, ES_SJSM_PBDNjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_SJSM_SMCPJBXX()
        {
            YHJBXX yhjbxx = ES_SJSM_SMCPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_SMCPJBXX ES_SJSM_SMCPjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_SMCPJBXX>(json);
            ES_SJSM_SMCPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_SMCPBLL.SaveES_SJSM_SMCPJBXX(jcxx, ES_SJSM_SMCPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_SJSM_TSJJBXX()
        {
            YHJBXX yhjbxx = ES_SJSM_TSJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_SJSM_TSJJBXX ES_SJSM_TSJjbxx = JsonHelper.ConvertJsonToObject<ES_SJSM_TSJJBXX>(json);
            ES_SJSM_TSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_SJSM_TSJBLL.SaveES_SJSM_TSJJBXX(jcxx, ES_SJSM_TSJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_WHYL_TSYXRJJBXX()
        {
            YHJBXX yhjbxx = ES_WHYL_TSYXRJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_WHYL_TSYXRJJBXX ES_WHYL_TSYXRJjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_TSYXRJJBXX>(json);
            ES_WHYL_TSYXRJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_TSYXRJBLL.SaveES_WHYL_TSYXRJJBXX(jcxx, ES_WHYL_TSYXRJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_WHYL_WTHWYQJBXX()
        {
            YHJBXX yhjbxx = ES_WHYL_WTHWYQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_WHYL_WTHWYQJBXX ES_WHYL_WTHWYQjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_WTHWYQJBXX>(json);
            ES_WHYL_WTHWYQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_WTHWYQBLL.SaveES_WHYL_WTHWYQJBXX(jcxx, ES_WHYL_WTHWYQjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_WHYL_WYXNWPJBXX()
        {
            YHJBXX yhjbxx = ES_WHYL_WYXNWPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_WHYL_WYXNWPJBXX ES_WHYL_WYXNWPjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_WYXNWPJBXX>(json);
            ES_WHYL_WYXNWPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_WYXNWPBLL.SaveES_WHYL_WYXNWPJBXX(jcxx, ES_WHYL_WYXNWPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_WHYL_YSPSCPJBXX()
        {
            YHJBXX yhjbxx = ES_WHYL_YSPSCPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_WHYL_YSPSCPJBXX ES_WHYL_YSPSCPjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_YSPSCPJBXX>(json);
            ES_WHYL_YSPSCPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_YSPSCPBLL.SaveES_WHYL_YSPSCPJBXX(jcxx, ES_WHYL_YSPSCPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_JDJJBG_BGSBJBXX()
        {
            string ID = Request["ID"];
            object result = ES_JDJJBG_BGSBBLL.LoadES_JDJJBG_BGSBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_JDJJBG_ESJDJBXX()
        {
            string ID = Request["ID"];
            object result = ES_JDJJBG_ESJDBLL.LoadES_JDJJBG_ESJDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_JDJJBG_ESJJJBXX()
        {
            string ID = Request["ID"];
            object result = ES_JDJJBG_ESJJBLL.LoadES_JDJJBG_ESJJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_JDJJBG_JJRYJBXX()
        {
            string ID = Request["ID"];
            object result = ES_JDJJBG_JJRYBLL.LoadES_JDJJBG_JJRYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_MYFZMR_FZXMXBJBXX()
        {
            string ID = Request["ID"];
            object result = ES_MYFZMR_FZXMXBBLL.LoadES_MYFZMR_FZXMXBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_MYFZMR_MRBJJBXX()
        {
            string ID = Request["ID"];
            object result = ES_MYFZMR_MRBJBLL.LoadES_MYFZMR_MRBJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_MYFZMR_MYETYPWJJBXX()
        {
            string ID = Request["ID"];
            object result = ES_MYFZMR_MYETYPWJBLL.LoadES_MYFZMR_MYETYPWJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_QTES_CRYPJBXX()
        {
            string ID = Request["ID"];
            object result = ES_QTES_CRYPBLL.LoadES_QTES_CRYPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_QTES_ESSBJBXX()
        {
            string ID = Request["ID"];
            object result = ES_QTES_ESSBBLL.LoadES_QTES_ESSBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_SJSM_BJBDNJBXX()
        {
            string ID = Request["ID"];
            object result = ES_SJSM_BJBDNBLL.LoadES_SJSM_BJBDNJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_SJSM_ESSJJBXX()
        {
            string ID = Request["ID"];
            object result = ES_SJSM_ESSJBLL.LoadES_SJSM_ESSJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_SJSM_PBDNJBXX()
        {
            string ID = Request["ID"];
            object result = ES_SJSM_PBDNBLL.LoadES_SJSM_PBDNJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_SJSM_SMCPJBXX()
        {
            string ID = Request["ID"];
            object result = ES_SJSM_SMCPBLL.LoadES_SJSM_SMCPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_SJSM_TSJJBXX()
        {
            string ID = Request["ID"];
            object result = ES_SJSM_TSJBLL.LoadES_SJSM_TSJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_WHYL_TSYXRJJBXX()
        {
            string ID = Request["ID"];
            object result = ES_WHYL_TSYXRJBLL.LoadES_WHYL_TSYXRJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_WHYL_WTHWYQJBXX()
        {
            string ID = Request["ID"];
            object result = ES_WHYL_WTHWYQBLL.LoadES_WHYL_WTHWYQJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_WHYL_WYXNWPJBXX()
        {
            string ID = Request["ID"];
            object result = ES_WHYL_WYXNWPBLL.LoadES_WHYL_WYXNWPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_WHYL_YSPSCPJBXX()
        {
            string ID = Request["ID"];
            object result = ES_WHYL_YSPSCPBLL.LoadES_WHYL_YSPSCPJBXX(ID);
            return Json(result);
        }
    }
}