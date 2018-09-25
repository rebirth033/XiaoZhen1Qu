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
        public ISWFW_BLL SWFW_BLL { get; set; }

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
        public ActionResult SWFW_QMFSSM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBSWFW_BGSBWXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_BGSBWXJBXX SWFW_BGSBWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_BGSBWXJBXX>(json);
            SWFW_BGSBWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_BGSBWXJBXX(jcxx, SWFW_BGSBWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_BXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_BXJBXX SWFW_BXjbxx = JsonHelper.ConvertJsonToObject<SWFW_BXJBXX>(json);
            SWFW_BXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_BXJBXX(jcxx, SWFW_BXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_CWKJPGJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_CWKJPGJBXX SWFW_CWKJPGjbxx = JsonHelper.ConvertJsonToObject<SWFW_CWKJPGJBXX>(json);
            SWFW_CWKJPGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_CWKJPGJBXX(jcxx, SWFW_CWKJPGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_DBQZQZJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_DBQZQZJBXX SWFW_DBQZQZjbxx = JsonHelper.ConvertJsonToObject<SWFW_DBQZQZJBXX>(json);
            SWFW_DBQZQZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_DBQZQZJBXX(jcxx, SWFW_DBQZQZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_FLZXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_FLZXJBXX SWFW_FLZXjbxx = JsonHelper.ConvertJsonToObject<SWFW_FLZXJBXX>(json);
            SWFW_FLZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_FLZXJBXX(jcxx, SWFW_FLZXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_FYSJJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_FYSJJBXX SWFW_FYSJjbxx = JsonHelper.ConvertJsonToObject<SWFW_FYSJJBXX>(json);
            SWFW_FYSJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_FYSJJBXX(jcxx, SWFW_FYSJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_GGCMJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_GGCMJBXX SWFW_GGCMjbxx = JsonHelper.ConvertJsonToObject<SWFW_GGCMJBXX>(json);
            SWFW_GGCMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_GGCMJBXX(jcxx, SWFW_GGCMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_GSZCJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_GSZCJBXX SWFW_GSZCjbxx = JsonHelper.ConvertJsonToObject<SWFW_GSZCJBXX>(json);
            SWFW_GSZCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_GSZCJBXX(jcxx, SWFW_GSZCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_HYZXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_HYZXJBXX SWFW_HYZXjbxx = JsonHelper.ConvertJsonToObject<SWFW_HYZXJBXX>(json);
            SWFW_HYZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_HYZXJBXX(jcxx, SWFW_HYZXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_HYWLJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_HYWLJBXX SWFW_HYWLjbxx = JsonHelper.ConvertJsonToObject<SWFW_HYWLJBXX>(json);
            SWFW_HYWLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_HYWLJBXX(jcxx, SWFW_HYWLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_JXSBWXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_JXSBWXJBXX SWFW_JXSBWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_JXSBWXJBXX>(json);
            SWFW_JXSBWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_JXSBWXJBXX(jcxx, SWFW_JXSBWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_JZWXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_JZWXJBXX SWFW_JZWXjbxx = JsonHelper.ConvertJsonToObject<SWFW_JZWXJBXX>(json);
            SWFW_JZWXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_JZWXJBXX(jcxx, SWFW_JZWXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_KDJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_KDJBXX SWFW_KDjbxx = JsonHelper.ConvertJsonToObject<SWFW_KDJBXX>(json);
            SWFW_KDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_KDJBXX(jcxx, SWFW_KDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_LPDZJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_LPDZJBXX SWFW_LPDZjbxx = JsonHelper.ConvertJsonToObject<SWFW_LPDZJBXX>(json);
            SWFW_LPDZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_LPDZJBXX(jcxx, SWFW_LPDZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_LYQDJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_LYQDJBXX SWFW_LYQDjbxx = JsonHelper.ConvertJsonToObject<SWFW_LYQDJBXX>(json);
            SWFW_LYQDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_LYQDJBXX(jcxx, SWFW_LYQDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_PHZPJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_PHZPJBXX SWFW_PHZPjbxx = JsonHelper.ConvertJsonToObject<SWFW_PHZPJBXX>(json);
            SWFW_PHZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_PHZPJBXX(jcxx, SWFW_PHZPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_SBZLJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_SBZLJBXX SWFW_SBZLjbxx = JsonHelper.ConvertJsonToObject<SWFW_SBZLJBXX>(json);
            SWFW_SBZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_SBZLJBXX(jcxx, SWFW_SBZLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_SJCHJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_SJCHJBXX SWFW_SJCHjbxx = JsonHelper.ConvertJsonToObject<SWFW_SJCHJBXX>(json);
            SWFW_SJCHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_SJCHJBXX(jcxx, SWFW_SJCHjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_SYSXJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_SYSXJBXX SWFW_SYSXjbxx = JsonHelper.ConvertJsonToObject<SWFW_SYSXJBXX>(json);
            SWFW_SYSXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_SYSXJBXX(jcxx, SWFW_SYSXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_TZDBJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_TZDBJBXX SWFW_TZDBjbxx = JsonHelper.ConvertJsonToObject<SWFW_TZDBJBXX>(json);
            SWFW_TZDBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_TZDBJBXX(jcxx, SWFW_TZDBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_WLBXWHJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_WLBXWHJBXX SWFW_WLBXWHjbxx = JsonHelper.ConvertJsonToObject<SWFW_WLBXWHJBXX>(json);
            SWFW_WLBXWHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_WLBXWHJBXX(jcxx, SWFW_WLBXWHjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_WZJSTGJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_WZJSTGJBXX SWFW_WZJSTGjbxx = JsonHelper.ConvertJsonToObject<SWFW_WZJSTGJBXX>(json);
            SWFW_WZJSTGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_WZJSTGJBXX(jcxx, SWFW_WZJSTGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_YSBZJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_YSBZJBXX SWFW_YSBZjbxx = JsonHelper.ConvertJsonToObject<SWFW_YSBZJBXX>(json);
            SWFW_YSBZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_YSBZJBXX(jcxx, SWFW_YSBZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZHFWJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_ZHFWJBXX SWFW_ZHFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZHFWJBXX>(json);
            SWFW_ZHFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_ZHFWJBXX(jcxx, SWFW_ZHFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZKJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_ZKJBXX SWFW_ZKjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZKJBXX>(json);
            SWFW_ZKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_ZKJBXX(jcxx, SWFW_ZKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZXFWJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_ZXFWJBXX SWFW_ZXFWjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZXFWJBXX>(json);
            SWFW_ZXFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_ZXFWJBXX(jcxx, SWFW_ZXFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSWFW_ZLJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_ZLJBXX SWFW_ZLjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZLJBXX>(json);
            SWFW_ZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_ZLJBXX(jcxx, SWFW_ZLjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBSWFW_QMFSSMJBXX()
        {
            YHJBXX YHJBXX = SWFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            SWFW_QMFSSMJBXX SWFW_QMFSSMjbxx = JsonHelper.ConvertJsonToObject<SWFW_QMFSSMJBXX>(json);
            SWFW_QMFSSMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_BLL.SaveSWFW_QMFSSMJBXX(jcxx, SWFW_QMFSSMjbxx, photos);
            return Json(result);
        }
        public JsonResult LoadSWFW_BGSBWXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_BGSBWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_BXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_BXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_CWKJPGJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_CWKJPGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_DBQZQZJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_DBQZQZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_FLZXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_FLZXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_FYSJJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_FYSJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_GGCMJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_GGCMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_GSZCJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_GSZCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_HYWLJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_HYWLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_HYZXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_HYZXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_JXSBWXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_JXSBWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_JZWXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_JZWXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_KDJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_KDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_LPDZJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_LPDZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_LYQDJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_LYQDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_PHZPJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_PHZPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_SBZLJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_SBZLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_SJCHJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_SJCHJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_SYSXJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_SYSXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_TZDBJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_TZDBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_WLBXWHJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_WLBXWHJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_WZJSTGJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_WZJSTGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_YSBZJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_YSBZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZHFWJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_ZHFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZKJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_ZKJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZLJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_ZLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_ZXFWJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_ZXFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadSWFW_QMFSSMJBXX()
        {
            string ID = Request["ID"];
            object result = SWFW_BLL.LoadSWFW_QMFSSMJBXX(ID);
            return Json(result);
        }
    }
}