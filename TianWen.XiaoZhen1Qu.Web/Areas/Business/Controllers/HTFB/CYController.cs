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
    public class CYController : BaseController
    {
        public ICY_KCTSBLL CY_KCTSBLL { get; set; }
        public ICY_MSBLL CY_MSBLL { get; set; }
        public ICY_WMBLL CY_WMBLL { get; set; }

        public ActionResult CY_KCTS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CY_MS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CY_WM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBCY_KCTSJBXX()
        {
            YHJBXX yhjbxx = CY_KCTSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CY_KCTSJBXX CY_KCTSjbxx = JsonHelper.ConvertJsonToObject<CY_KCTSJBXX>(json);
            CY_KCTSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_KCTSBLL.SaveCY_KCTSJBXX(jcxx, CY_KCTSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCY_MSJBXX()
        {
            YHJBXX yhjbxx = CY_MSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CY_MSJBXX CY_MSjbxx = JsonHelper.ConvertJsonToObject<CY_MSJBXX>(json);
            CY_MSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_MSBLL.SaveCY_MSJBXX(jcxx, CY_MSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCY_WMJBXX()
        {
            YHJBXX yhjbxx = CY_WMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CY_WMJBXX CY_WMjbxx = JsonHelper.ConvertJsonToObject<CY_WMJBXX>(json);
            CY_WMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_WMBLL.SaveCY_WMJBXX(jcxx, CY_WMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCY_KCTSJBXX()
        {
            string CY_KCTSJBXXID = Request["CY_KCTSJBXXID"];
            object result = CY_KCTSBLL.LoadCY_KCTSJBXX(CY_KCTSJBXXID);
            return Json(result);
        }
        public JsonResult LoadCY_MSJBXX()
        {
            string CY_MSJBXXID = Request["CY_MSJBXXID"];
            object result = CY_MSBLL.LoadCY_MSJBXX(CY_MSJBXXID);
            return Json(result);
        }
        public JsonResult LoadCY_WMJBXX()
        {
            string CY_WMJBXXID = Request["CY_WMJBXXID"];
            object result = CY_WMBLL.LoadCY_WMJBXX(CY_WMJBXXID);
            return Json(result);
        }
    }
}