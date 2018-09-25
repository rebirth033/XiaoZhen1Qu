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
    public class LRController : BaseController
    {
        public ILR_BLL LR_BLL { get; set; }

        public ActionResult LR_KQHL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_MFHF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_MJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_MRHF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_MTSS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_SPA()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_TJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_WD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_WS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LR_YJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBLR_KQHLJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_KQHLJBXX LR_KQHLjbxx = JsonHelper.ConvertJsonToObject<LR_KQHLJBXX>(json);
            LR_KQHLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_KQHLJBXX(jcxx, LR_KQHLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_MFHFJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_MFHFJBXX LR_MFHFjbxx = JsonHelper.ConvertJsonToObject<LR_MFHFJBXX>(json);
            LR_MFHFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_MFHFJBXX(jcxx, LR_MFHFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_MJJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_MJJBXX LR_MJjbxx = JsonHelper.ConvertJsonToObject<LR_MJJBXX>(json);
            LR_MJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_MJJBXX(jcxx, LR_MJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_MRHFJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_MRHFJBXX LR_MRHFjbxx = JsonHelper.ConvertJsonToObject<LR_MRHFJBXX>(json);
            LR_MRHFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_MRHFJBXX(jcxx, LR_MRHFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_MTSSJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_MTSSJBXX LR_MTSSjbxx = JsonHelper.ConvertJsonToObject<LR_MTSSJBXX>(json);
            LR_MTSSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_MTSSJBXX(jcxx, LR_MTSSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_SPAJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_SPAJBXX LR_SPAjbxx = JsonHelper.ConvertJsonToObject<LR_SPAJBXX>(json);
            LR_SPAjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_SPAJBXX(jcxx, LR_SPAjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_TJJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_TJJBXX LR_TJjbxx = JsonHelper.ConvertJsonToObject<LR_TJJBXX>(json);
            LR_TJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_TJJBXX(jcxx, LR_TJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_WDJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_WDJBXX LR_WDjbxx = JsonHelper.ConvertJsonToObject<LR_WDJBXX>(json);
            LR_WDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_WDJBXX(jcxx, LR_WDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_WSJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_WSJBXX LR_WSjbxx = JsonHelper.ConvertJsonToObject<LR_WSJBXX>(json);
            LR_WSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_WSJBXX(jcxx, LR_WSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLR_YJJBXX()
        {
            YHJBXX YHJBXX = LR_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            LR_YJJBXX LR_YJjbxx = JsonHelper.ConvertJsonToObject<LR_YJJBXX>(json);
            LR_YJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_BLL.SaveLR_YJJBXX(jcxx, LR_YJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_KQHLJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_KQHLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_MFHFJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_MFHFJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_MJJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_MJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_MRHFJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_MRHFJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_MTSSJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_MTSSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_SPAJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_SPAJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_TJJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_TJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_WDJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_WDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_WSJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_WSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLR_YJJBXX()
        {
            string ID = Request["ID"];
            object result = LR_BLL.LoadLR_YJJBXX(ID);
            return Json(result);
        }
    }
}