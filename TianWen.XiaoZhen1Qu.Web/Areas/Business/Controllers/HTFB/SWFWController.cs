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
    public class SWFWController : BaseController
    {
        public ISWFW_BGSBWXBLL SWFW_BGSBWXBLL { get; set; }
        public ISWFW_BXBLL SWFW_BXBLL { get; set; }
        public ISWFW_CWKJPGBLL SWFW_CWKJPGBLL { get; set; }
        public ISWFW_DBQZQZBLL SWFW_DBQZQZBLL { get; set; }
        public ISWFW_FLZXBLL SWFW_FLZXBLL { get; set; }
        public ISWFW_FYSJBLL SWFW_FYSJBLL { get; set; }
        public ISWFW_GGCMBLL SWFW_GGCMBLL { get; set; }
        public ISWFW_GSZCBLL SWFW_GSZCBLL { get; set; }
        public ISWFW_HYWLBLL SWFW_HYWLBLL { get; set; }
        public ISWFW_HYZXBLL SWFW_HYZXBLL { get; set; }
        public ISWFW_JXSBWXBLL SWFW_JXSBWXBLL { get; set; }
        public ISWFW_JZWXBLL SWFW_JZWXBLL { get; set; }
        public ISWFW_KDBLL SWFW_KDBLL { get; set; }
        public ISWFW_LPDZBLL SWFW_LPDZBLL { get; set; }
        public ISWFW_LYQDBLL SWFW_LYQDBLL { get; set; }
        public ISWFW_PHZPBLL SWFW_PHZPBLL { get; set; }
        public ISWFW_SBZLBLL SWFW_SBZLBLL { get; set; }
        public ISWFW_SJCHBLL SWFW_SJCHBLL { get; set; }
        public ISWFW_SYSXBLL SWFW_SYSXBLL { get; set; }
        public ISWFW_TZDBBLL SWFW_TZDBBLL { get; set; }
        public ISWFW_WLBXWHBLL SWFW_WLBXWHBLL { get; set; }
        public ISWFW_WZJSTGBLL SWFW_WZJSTGBLL { get; set; }
        public ISWFW_YSBZBLL SWFW_YSBZBLL { get; set; }
        public ISWFW_ZHFWBLL SWFW_ZHFWBLL { get; set; }
        public ISWFW_ZKBLL SWFW_ZKBLL { get; set; }
        public ISWFW_ZXFWBLL SWFW_ZXFWBLL { get; set; }
        public ISWFW_ZLBLL SWFW_ZLBLL { get; set; }

        public ActionResult SWFW_BGSBWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_BX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_CWKJPG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_DBQZQZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_FLZX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_FYSJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_GGCM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_GSZC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_HYWL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_HYZX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_JXSBWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_JZWX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_KD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_LPDZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_LYQD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_PHZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_SBZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_SJCH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_SYSX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_TZDB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_WLBXWH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_WZJSTG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_YSBZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_ZHFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_ZK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_ZXFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult SWFW_ZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBSWFW_BGSBWXJBXX()
        {
            YHJBXX yhjbxx = SWFW_BGSBWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_BGSBWXJBXX SWFW_BGSBWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_BGSBWXJBXX>(json);
            SWFW_BGSBWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BGSBWXBLL.SaveSWFW_BGSBWXJBXX(jcxx, SWFW_BGSBWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_BXJBXX()
        {
            YHJBXX yhjbxx = SWFW_BXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_BXJBXX SWFW_BXjbxx = JsonHelper.ConvertJsonToObject<SWFW_BXJBXX>(json);
            SWFW_BXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BXBLL.SaveSWFW_BXJBXX(jcxx, SWFW_BXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_CWKJPGJBXX()
        {
            YHJBXX yhjbxx = SWFW_CWKJPGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_CWKJPGJBXX SWFW_CWKJPGjbxx = JsonHelper.ConvertJsonToObject<SWFW_CWKJPGJBXX>(json);
            SWFW_CWKJPGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_CWKJPGBLL.SaveSWFW_CWKJPGJBXX(jcxx, SWFW_CWKJPGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_DBQZQZJBXX()
        {
            YHJBXX yhjbxx = SWFW_DBQZQZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_DBQZQZJBXX SWFW_DBQZQZjbxx = JsonHelper.ConvertJsonToObject<SWFW_DBQZQZJBXX>(json);
            SWFW_DBQZQZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_DBQZQZBLL.SaveSWFW_DBQZQZJBXX(jcxx, SWFW_DBQZQZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_FLZXJBXX()
        {
            YHJBXX yhjbxx = SWFW_FLZXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_FLZXJBXX SWFW_FLZXjbxx = JsonHelper.ConvertJsonToObject<SWFW_FLZXJBXX>(json);
            SWFW_FLZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_FLZXBLL.SaveSWFW_FLZXJBXX(jcxx, SWFW_FLZXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_FYSJJBXX()
        {
            YHJBXX yhjbxx = SWFW_FYSJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_FYSJJBXX SWFW_FYSJjbxx = JsonHelper.ConvertJsonToObject<SWFW_FYSJJBXX>(json);
            SWFW_FYSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_FYSJBLL.SaveSWFW_FYSJJBXX(jcxx, SWFW_FYSJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_GGCMJBXX()
        {
            YHJBXX yhjbxx = SWFW_GGCMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_GGCMJBXX SWFW_GGCMjbxx = JsonHelper.ConvertJsonToObject<SWFW_GGCMJBXX>(json);
            SWFW_GGCMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_GGCMBLL.SaveSWFW_GGCMJBXX(jcxx, SWFW_GGCMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_GSZCJBXX()
        {
            YHJBXX yhjbxx = SWFW_GSZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_GSZCJBXX SWFW_GSZCjbxx = JsonHelper.ConvertJsonToObject<SWFW_GSZCJBXX>(json);
            SWFW_GSZCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_GSZCBLL.SaveSWFW_GSZCJBXX(jcxx, SWFW_GSZCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_HYZXJBXX()
        {
            YHJBXX yhjbxx = SWFW_HYZXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_HYWLJBXX SWFW_HYWLjbxx = JsonHelper.ConvertJsonToObject<SWFW_HYWLJBXX>(json);
            SWFW_HYWLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_HYWLBLL.SaveSWFW_HYWLJBXX(jcxx, SWFW_HYWLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_HYWLJBXX()
        {
            YHJBXX yhjbxx = SWFW_HYWLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_HYWLJBXX SWFW_HYWLjbxx = JsonHelper.ConvertJsonToObject<SWFW_HYWLJBXX>(json);
            SWFW_HYWLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_HYWLBLL.SaveSWFW_HYWLJBXX(jcxx, SWFW_HYWLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_JXSBWXJBXX()
        {
            YHJBXX yhjbxx = SWFW_JXSBWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_JXSBWXJBXX SWFW_JXSBWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_JXSBWXJBXX>(json);
            SWFW_JXSBWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_JXSBWXBLL.SaveSWFW_JXSBWXJBXX(jcxx, SWFW_JXSBWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_JZWXJBXX()
        {
            YHJBXX yhjbxx = SWFW_JZWXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_JZWXJBXX SWFW_JZWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_JZWXJBXX>(json);
            SWFW_JZWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_JZWXBLL.SaveSWFW_JZWXJBXX(jcxx, SWFW_JZWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_KDJBXX()
        {
            YHJBXX yhjbxx = SWFW_KDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_KDJBXX SWFW_KDjbxx = JsonHelper.ConvertJsonToObject<SWFW_KDJBXX>(json);
            SWFW_KDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_KDBLL.SaveSWFW_KDJBXX(jcxx, SWFW_KDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_LPDZJBXX()
        {
            YHJBXX yhjbxx = SWFW_LPDZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_LPDZJBXX SWFW_LPDZjbxx = JsonHelper.ConvertJsonToObject<SWFW_LPDZJBXX>(json);
            SWFW_LPDZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_LPDZBLL.SaveSWFW_LPDZJBXX(jcxx, SWFW_LPDZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_LYQDJBXX()
        {
            YHJBXX yhjbxx = SWFW_LYQDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_LYQDJBXX SWFW_LYQDjbxx = JsonHelper.ConvertJsonToObject<SWFW_LYQDJBXX>(json);
            SWFW_LYQDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_LYQDBLL.SaveSWFW_LYQDJBXX(jcxx, SWFW_LYQDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_PHZPJBXX()
        {
            YHJBXX yhjbxx = SWFW_PHZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_PHZPJBXX SWFW_PHZPjbxx = JsonHelper.ConvertJsonToObject<SWFW_PHZPJBXX>(json);
            SWFW_PHZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_PHZPBLL.SaveSWFW_PHZPJBXX(jcxx, SWFW_PHZPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_SBZLJBXX()
        {
            YHJBXX yhjbxx = SWFW_SBZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_SBZLJBXX SWFW_SBZLjbxx = JsonHelper.ConvertJsonToObject<SWFW_SBZLJBXX>(json);
            SWFW_SBZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_SBZLBLL.SaveSWFW_SBZLJBXX(jcxx, SWFW_SBZLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_SJCHJBXX()
        {
            YHJBXX yhjbxx = SWFW_SJCHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_SJCHJBXX SWFW_SJCHjbxx = JsonHelper.ConvertJsonToObject<SWFW_SJCHJBXX>(json);
            SWFW_SJCHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_SJCHBLL.SaveSWFW_SJCHJBXX(jcxx, SWFW_SJCHjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_SYSXJBXX()
        {
            YHJBXX yhjbxx = SWFW_SYSXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_SYSXJBXX SWFW_SYSXjbxx = JsonHelper.ConvertJsonToObject<SWFW_SYSXJBXX>(json);
            SWFW_SYSXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_SYSXBLL.SaveSWFW_SYSXJBXX(jcxx, SWFW_SYSXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_TZDBJBXX()
        {
            YHJBXX yhjbxx = SWFW_TZDBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_TZDBJBXX SWFW_TZDBjbxx = JsonHelper.ConvertJsonToObject<SWFW_TZDBJBXX>(json);
            SWFW_TZDBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_TZDBBLL.SaveSWFW_TZDBJBXX(jcxx, SWFW_TZDBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_WLBXJBXX()
        {
            YHJBXX yhjbxx = SWFW_WLBXWHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_WLBXWHJBXX SWFW_WLBXWHjbxx = JsonHelper.ConvertJsonToObject<SWFW_WLBXWHJBXX>(json);
            SWFW_WLBXWHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_WLBXWHBLL.SaveSWFW_WLBXWHJBXX(jcxx, SWFW_WLBXWHjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_WZJSJBXX()
        {
            YHJBXX yhjbxx = SWFW_WZJSTGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_WZJSTGJBXX SWFW_WZJSTGjbxx = JsonHelper.ConvertJsonToObject<SWFW_WZJSTGJBXX>(json);
            SWFW_WZJSTGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_WZJSTGBLL.SaveSWFW_WZJSTGJBXX(jcxx, SWFW_WZJSTGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_YSBZJBXX()
        {
            YHJBXX yhjbxx = SWFW_YSBZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_YSBZJBXX SWFW_YSBZjbxx = JsonHelper.ConvertJsonToObject<SWFW_YSBZJBXX>(json);
            SWFW_YSBZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_YSBZBLL.SaveSWFW_YSBZJBXX(jcxx, SWFW_YSBZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZHFWJBXX()
        {
            YHJBXX yhjbxx = SWFW_ZHFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZHFWJBXX SWFW_ZHFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZHFWJBXX>(json);
            SWFW_ZHFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZHFWBLL.SaveSWFW_ZHFWJBXX(jcxx, SWFW_ZHFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZKJBXX()
        {
            YHJBXX yhjbxx = SWFW_ZKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZKJBXX SWFW_ZKjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZKJBXX>(json);
            SWFW_ZKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZKBLL.SaveSWFW_ZKJBXX(jcxx, SWFW_ZKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZXFWJBXX()
        {
            YHJBXX yhjbxx = SWFW_ZXFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZXFWJBXX SWFW_ZXFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZXFWJBXX>(json);
            SWFW_ZXFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZXFWBLL.SaveSWFW_ZXFWJBXX(jcxx, SWFW_ZXFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZLJBXX()
        {
            YHJBXX yhjbxx = SWFW_ZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZLJBXX SWFW_ZLjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZLJBXX>(json);
            SWFW_ZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZLBLL.SaveSWFW_ZLJBXX(jcxx, SWFW_ZLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_BGSBWXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BGSBWXBLL.LoadSWFW_BGSBWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_BXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BXBLL.LoadSWFW_BXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_CWKJPGJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_CWKJPGBLL.LoadSWFW_CWKJPGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_DBQZQZJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_DBQZQZBLL.LoadSWFW_DBQZQZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_FLZXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_FLZXBLL.LoadSWFW_FLZXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_FYSJJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_FYSJBLL.LoadSWFW_FYSJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_GGCMJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_GGCMBLL.LoadSWFW_GGCMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_GSZCJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_GSZCBLL.LoadSWFW_GSZCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_HYWLJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_HYWLBLL.LoadSWFW_HYWLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_HYZXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_HYZXBLL.LoadSWFW_HYZXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_JXSBWXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_JXSBWXBLL.LoadSWFW_JXSBWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_JZWXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_JZWXBLL.LoadSWFW_JZWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_KDJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_KDBLL.LoadSWFW_KDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_LPDZJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_LPDZBLL.LoadSWFW_LPDZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_LYQDJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_LYQDBLL.LoadSWFW_LYQDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_PHZPJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_PHZPBLL.LoadSWFW_PHZPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_SBZLJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_SBZLBLL.LoadSWFW_SBZLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_SJCHJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_SJCHBLL.LoadSWFW_SJCHJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_SYSXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_SYSXBLL.LoadSWFW_SYSXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_TZDBJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_TZDBBLL.LoadSWFW_TZDBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_WLBXWHJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_WLBXWHBLL.LoadSWFW_WLBXWHJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_WZJSTGJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_WZJSTGBLL.LoadSWFW_WZJSTGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_YSBZJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_YSBZBLL.LoadSWFW_YSBZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZHFWJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_ZHFWBLL.LoadSWFW_ZHFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZKJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_ZKBLL.LoadSWFW_ZKJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZLJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_ZLBLL.LoadSWFW_ZLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZXFWJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_ZXFWBLL.LoadSWFW_ZXFWJBXX(ID);
            return Json(result);
        }
    }
}