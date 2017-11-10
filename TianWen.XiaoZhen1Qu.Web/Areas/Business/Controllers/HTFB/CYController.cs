using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface.HTFB;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CYController : BaseController
    {
        public ICY_BLL CY_BLL { get; set; }

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
            YHJBXX yhjbxx = CY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CY_KCTSJBXX CY_KCTSjbxx = JsonHelper.ConvertJsonToObject<CY_KCTSJBXX>(json);
            CY_KCTSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_BLL.SaveCY_KCTSJBXX(jcxx, CY_KCTSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCY_MSJBXX()
        {
            YHJBXX yhjbxx = CY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CY_MSJBXX CY_MSjbxx = JsonHelper.ConvertJsonToObject<CY_MSJBXX>(json);
            CY_MSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_BLL.SaveCY_MSJBXX(jcxx, CY_MSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCY_WMJBXX()
        {
            YHJBXX yhjbxx = CY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CY_WMJBXX CY_WMjbxx = JsonHelper.ConvertJsonToObject<CY_WMJBXX>(json);
            CY_WMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_BLL.SaveCY_WMJBXX(jcxx, CY_WMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCY_KCTSJBXX()
        {
            string ID = Request["ID"];
            object result = CY_BLL.LoadCY_KCTSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCY_MSJBXX()
        {
            string ID = Request["ID"];
            object result = CY_BLL.LoadCY_MSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCY_WMJBXX()
        {
            string ID = Request["ID"];
            object result = CY_BLL.LoadCY_WMJBXX(ID);
            return Json(result);
        }
    }
}